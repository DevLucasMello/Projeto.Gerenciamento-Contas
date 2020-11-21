using SantosConta.ApplicationService;
using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantosConta.UI.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        IContaCorrenteAppService correnteApp;        
        private Usuario usuario;

        public ContaCorrenteController(IContaCorrenteAppService correnteAppServiceInstance)
        {
            this.correnteApp = correnteAppServiceInstance;
            usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Excluir(string id)
        {
            var contaCorrente = correnteApp.ObterPorId(id);
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            correnteApp.Excluir(id);
            return RedirectToAction("Inicio");
        }


        public ActionResult Alterar(string id)
        {
            var contaCorrente = correnteApp.ObterPorId(id);

            return View(contaCorrente);

        }

        [HttpPost]
        public ActionResult Alterar(ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição deve ser informada");
            }

            if (ModelState.IsValid)
            {
                correnteApp.Alterar(contaCorrente);
                return RedirectToAction("Inicio");
            }

            return View(contaCorrente);

        }


        public ActionResult Incluir()
        {
            var contaCorrente = new ContaCorrente();
            return View(contaCorrente);

        }

        [HttpPost]
        public ActionResult Incluir(ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição deve ser informada");
            }
            if (ModelState.IsValid)
            {
                contaCorrente.Id = Guid.NewGuid().ToString();
                contaCorrente.UsuarioId = usuario.Id;
                correnteApp.Incluir(contaCorrente);
                return RedirectToAction("Inicio");
            }

            return View(contaCorrente);

        }
        
        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var lista = correnteApp.ObterTodos(usuario.Id);
            return View(lista);
        }
    }
}
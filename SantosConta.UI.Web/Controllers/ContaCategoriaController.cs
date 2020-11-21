using SantosConta.ApplicationService;
using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantosConta.UI.Web.Controllers
{
    public class ContaCategoriaController : Controller
    {
        IContaCategoriaAppService categoriaApp;
        private Usuario usuario;

        public ContaCategoriaController(IContaCategoriaAppService categoriaAppServiceInstance)
        {
            this.categoriaApp = categoriaAppServiceInstance;
            usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Excluir(string id)
        {
            var contaCategoria = categoriaApp.ObterPorId(id);
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            categoriaApp.Excluir(id);
            return RedirectToAction("Inicio");
        }


        public ActionResult Alterar(string id)
        {
            var contaCategoria = categoriaApp.ObterPorId(id);

            return View(contaCategoria);

        }

        [HttpPost]
        public ActionResult Alterar(ContaCategoria contaCategoria)
        {
            if (string.IsNullOrEmpty(contaCategoria.Nome))
            {
                ModelState.AddModelError("Nome", "A nome deve ser informada");
            }

            if (ModelState.IsValid)
            {
                categoriaApp.Alterar(contaCategoria);
                return RedirectToAction("Inicio");
            }

            return View(contaCategoria);

        }


        public ActionResult Incluir()
        {
            var contaCategoria = new ContaCategoria();
            return View(contaCategoria);

        }

        [HttpPost]
        public ActionResult Incluir(ContaCategoria contaCategoria)
        {
            if (string.IsNullOrEmpty(contaCategoria.Nome))
            {
                ModelState.AddModelError("Nome", "O Nome deve ser informada");
            }
            if (ModelState.IsValid)
            {
                contaCategoria.Id = Guid.NewGuid().ToString();
                contaCategoria.UsuarioId = usuario.Id;
                categoriaApp.Incluir(contaCategoria);
                return RedirectToAction("Inicio");
            }

            return View(contaCategoria);

        }
        
        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var lista = categoriaApp.ObterTodos(usuario.Id);
            return View(lista);
        }
    }
}
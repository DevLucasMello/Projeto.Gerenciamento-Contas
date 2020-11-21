using SantosConta.ApplicationService;
using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantosConta.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        IContaAppService contaApp;
        IContaCategoriaAppService categoriaApp;
        IContaCorrenteAppService correnteApp;
        IContatoAppService contatoApp;
        private Usuario usuario;

        public ContaController(IContaAppService contaAppServiceInstance, IContaCategoriaAppService categoriaAppServiceInstance, 
            IContaCorrenteAppService correnteAppServiceInstance, IContatoAppService contatoAppServiceInstance)
        {
            this.contaApp = contaAppServiceInstance;
            this.categoriaApp = categoriaAppServiceInstance;
            this.correnteApp = correnteAppServiceInstance;
            this.contatoApp = contatoAppServiceInstance;
            usuario = AppHelper.ObterUsuarioLogado();            
        }

        public ActionResult Excluir(string id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var conta = contaApp.ObterExibirPorId(id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            contaApp.Excluir(id);
            return RedirectToAction("Inicio");
        }

        public ActionResult Alterar(string id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();
            viewModel.ContaInstancia = contaApp.ObterPorId(id);
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Alterar(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                contaApp.Alterar(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }




        public ActionResult Incluir()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                viewModel.ContaInstancia.Id = Guid.NewGuid().ToString();
                contaApp.Incluir(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        private void PreencherViewModel(ContaViewModel viewModel)
        {
            viewModel.ContaCorrenteList = correnteApp.ObterTodos(usuario.Id).ToList();
            
            viewModel.ContaCategoriaList = categoriaApp.ObterTodos(usuario.Id).ToList();
            
            viewModel.ContatoList = contatoApp.ObterTodos(usuario.Id).ToList();

        }

        [HttpPost]
        public ActionResult Inicio(ContaListViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            viewModel.Filtro.UsuarioId = usuario.Id;
            viewModel.ContaList = contaApp.ObterPorFiltro(viewModel.Filtro).ToList();
            PreencherContaListViewModel(viewModel);
            return View(viewModel);

        }

        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            var viewModel = new ContaListViewModel();
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            viewModel.Filtro.DataFinal = DateTime.Now;
            viewModel.Filtro.UsuarioId = usuario.Id;
            viewModel.ContaList = contaApp.ObterPorFiltro(viewModel.Filtro).ToList();

            PreencherContaListViewModel(viewModel);

            return View(viewModel);

        }

        private void PreencherContaListViewModel(ContaListViewModel viewModel)
        {
            viewModel.CategoriaList = categoriaApp.ObterTodos(usuario.Id).ToList();
            
            viewModel.ContaCorrenteList = correnteApp.ObterTodos(usuario.Id).ToList();

            viewModel.CategoriaList.Insert(0, new ContaCategoria() { Id = string.Empty, Nome = string.Empty });
            viewModel.ContaCorrenteList.Insert(0, new ContaCorrente() { Id = string.Empty, Descricao = string.Empty });
        }
    }
}
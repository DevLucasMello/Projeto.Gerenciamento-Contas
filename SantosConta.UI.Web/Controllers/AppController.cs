using SantosConta.ApplicationService;
using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantosConta.UI.Web.Controllers
{
    public class AppController : Controller
    {
        IUsuarioAppService usuarioApp;

        public AppController(IUsuarioAppService usuarioAppServiceInstance)
        {
            this.usuarioApp = usuarioAppServiceInstance;
        }
        
        public ActionResult LogOff()
        {
            AppHelper.LogOff();
            return View();
        }

        public ActionResult Registro()
        {
            var registro = new RegistroViewModel();

            return View(registro);
        }


        [HttpPost]
        public ActionResult Registro(RegistroViewModel registro)
        {
            if (string.IsNullOrEmpty(registro.Email))
            {
                ModelState.AddModelError("Email", "O email deve ser informado");
            }

            if (string.IsNullOrEmpty(registro.Senha))
            {
                ModelState.AddModelError("Senha", "A senha deve ser informado");
            }
            else
            {
                if (registro.Senha != registro.ConfirmarSenha)
                {
                    ModelState.AddModelError("ConfirmarSenha", "A confirmação deve ser igual a senha");
                }
            }
            if (ModelState.IsValid)
            {
                //Criando um usuario
                var usuario = new Usuario();
                usuario.Email = registro.Email;
                usuario.Senha = registro.Senha;
                usuario.Nome = registro.Nome;
                usuario.Id = Guid.NewGuid().ToString();

                //Gravando                
                usuarioApp.Incluir(usuario);

                //Registrando
                AppHelper.RegistrarUsuario(usuario);

                //Redirecionando
                return RedirectToAction("Inicio");

            }
            return View(registro);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            Usuario usuario = usuarioApp.ObterPorEmailSenha(loginViewModel.Email, loginViewModel.Senha);
            if (usuario == null)
            {
                loginViewModel.Mensagem = "Usuário ou senha inexistente";
            }
            else
            {
                AppHelper.RegistrarUsuario(usuario);
                return RedirectToAction("Inicio");
            }


            return View(loginViewModel);
        }


        /// <summary>
        /// Tela Inicial
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Inicio()
        {
            //var usuario = AppHelper.ObterUsuarioLogado();
            //if (usuario == null)
            //{
            //     return RedirectToAction("Login");
            // }

            return View();
        }



        /// <summary>
        /// Sobre este aplicativo
        /// </summary>
        /// <returns></returns>
        public ActionResult Sobre()
        {
            return View();
        }
    }
}
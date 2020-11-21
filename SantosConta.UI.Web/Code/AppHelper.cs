using SantosConta.Domain;
using SantosConta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SantosConta.UI.Web
{
    public static class AppHelper
    {
        public static void LogOff()
        {
            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;
            autenticador.SignOut();

        }


        public static Usuario ObterUsuarioLogado()
        {
            //return (Usuario)HttpContext.Current.Session["usuario"];

            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;

            var usuarioCookie = autenticador.User;

            var usuario = new Usuario()
            {
                Id = usuarioCookie.Claims.First(m => m.Type == "UsuarioId").Value,
                Nome = usuarioCookie.Identity.Name
            };

            return usuario;

        }


        public static void RegistrarUsuario(Usuario usuario)
        {
            var identidade = new ClaimsIdentity("autenticacaoPorCookies");
            var claimNome = new Claim(ClaimTypes.Name, usuario.Nome);
            var claimId = new Claim("UsuarioId", usuario.Id);
            identidade.AddClaim(claimNome);
            identidade.AddClaim(claimId);



            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;
            autenticador.SignIn(identidade);

            //HttpContext.Current.Session["usuario"] = usuario;
        }
    }
}
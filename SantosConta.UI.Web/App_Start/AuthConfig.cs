﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(SantosConta.UI.Web.AuthConfig))]

namespace SantosConta.UI.Web
{
    public class AuthConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/App/Login"),
                AuthenticationType = "autenticacaoPorCookies"
            };

            app.UseCookieAuthentication(cookieOptions);

        }
    }
}
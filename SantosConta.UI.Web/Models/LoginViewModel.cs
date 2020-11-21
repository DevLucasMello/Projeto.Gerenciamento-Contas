using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantosConta.UI.Web
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Mensagem { get; set; }
    }
}
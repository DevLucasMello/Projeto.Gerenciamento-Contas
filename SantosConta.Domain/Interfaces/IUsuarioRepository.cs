using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.Domain
{
    public interface IUsuarioRepository:IRepository<Usuario>
    {
        Usuario ObterPorEmailSenha(string email, string senha);
    }
}

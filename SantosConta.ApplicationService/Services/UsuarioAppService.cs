using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.ApplicationService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private IUsuarioRepository usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepositoryInstance)
        {
            this.usuarioRepository = usuarioRepositoryInstance;
        }
        
        public void Alterar(Usuario usuario)
        {
            usuarioRepository.Alterar(usuario);
        }

        public void Excluir(string id)
        {
            usuarioRepository.Excluir(id);
        }

        public void Incluir(Usuario usuario)
        {
            usuarioRepository.Incluir(usuario);
        }

        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            return usuarioRepository.ObterPorEmailSenha(email, senha);
        }

        public Usuario ObterPorId(string id)
        {
            return usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos(string usuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

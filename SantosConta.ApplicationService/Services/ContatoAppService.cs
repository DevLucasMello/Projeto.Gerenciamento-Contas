using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.ApplicationService
{
    public class ContatoAppService : IContatoAppService
    {
        private IContatoRepository contatoRepository;

        public ContatoAppService(IContatoRepository contatoRepositoryInstance)
        {
            this.contatoRepository = contatoRepositoryInstance;
        }
        
        public void Alterar(Contato contato)
        {
            contatoRepository.Alterar(contato);
        }

        public void Excluir(string id)
        {
            contatoRepository.Excluir(id);
        }

        public void Incluir(Contato contato)
        {
            contatoRepository.Incluir(contato);
        }

        public Contato ObterPorId(string id)
        {
            return contatoRepository.ObterPorId(id);
        }

        public IEnumerable<Contato> ObterTodos(string usuarioId)
        {
            return contatoRepository.ObterTodos(usuarioId);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

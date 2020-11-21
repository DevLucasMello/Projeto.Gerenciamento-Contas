using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.ApplicationService
{
    public class ContaCategoriaAppService : IContaCategoriaAppService
    {
        private IContaCategoriaRepository contaCategoriaRepository;

        public ContaCategoriaAppService(IContaCategoriaRepository contaCategoriaRepositoryInstance)
        {
            this.contaCategoriaRepository = contaCategoriaRepositoryInstance;
        }
        
        public void Alterar(ContaCategoria contaCategoria)
        {
            contaCategoriaRepository.Alterar(contaCategoria);
        }

        public void Excluir(string id)
        {
            contaCategoriaRepository.Excluir(id);
        }

        public void Incluir(ContaCategoria contaCategoria)
        {
            contaCategoriaRepository.Incluir(contaCategoria);
        }

        public ContaCategoria ObterPorId(string id)
        {
            return contaCategoriaRepository.ObterPorId(id);
        }

        public IEnumerable<ContaCategoria> ObterTodos(string usuarioId)
        {
            return contaCategoriaRepository.ObterTodos(usuarioId);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

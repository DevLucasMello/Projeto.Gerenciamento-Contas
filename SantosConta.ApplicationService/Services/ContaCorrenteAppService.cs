using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.ApplicationService
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private IContaCorrenteRepository contaCorrenteRepository;

        public ContaCorrenteAppService(IContaCorrenteRepository contaCorrenteRepositoryInstance)
        {
            this.contaCorrenteRepository = contaCorrenteRepositoryInstance;
        }
        public void Alterar(ContaCorrente contaCorrente)
        {
            contaCorrenteRepository.Alterar(contaCorrente);
        }

        public void Excluir(string id)
        {
            contaCorrenteRepository.Excluir(id);
        }

        public void Incluir(ContaCorrente contaCorrente)
        {
            contaCorrenteRepository.Incluir(contaCorrente);
        }

        public ContaCorrente ObterPorId(string id)
        {
            return contaCorrenteRepository.ObterPorId(id);
        }

        public IEnumerable<ContaCorrente> ObterTodos(string usuarioId)
        {
            return contaCorrenteRepository.ObterTodos(usuarioId);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

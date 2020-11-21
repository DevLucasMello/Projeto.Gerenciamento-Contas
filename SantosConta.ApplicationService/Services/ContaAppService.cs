using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.ApplicationService
{
    public class ContaAppService : IContaAppService
    {
        private IContaRepository contaRepository;

        public ContaAppService(IContaRepository contaRepositoryInstance)
        {
            this.contaRepository = contaRepositoryInstance;
        }

        public void Alterar(Conta conta)
        {
            contaRepository.Alterar(conta);
        }

        public void Excluir(string id)
        {
            contaRepository.Excluir(id);
        }

        public void Incluir(Conta conta)
        {
            contaRepository.Incluir(conta);
        }

        public ContaExibirViewModel ObterExibirPorId(string id)
        {
            return contaRepository.ObterExibirPorId(id);
        }

        public IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro)
        {
            return contaRepository.ObterPorFiltro(filtro);
        }

        public Conta ObterPorId(string id)
        {
            return contaRepository.ObterPorId(id);
        }

        public IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId)
        {
            return contaRepository.ObterPorUsuario(usuarioId);
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return contaRepository.ObterTodos(usuarioId);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

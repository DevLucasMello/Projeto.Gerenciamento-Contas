using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.Domain
{
    public interface IContaRepository:IRepository<Conta>
    {
        ContaExibirViewModel ObterExibirPorId(string id);

        IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId);

        IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro);
    }
}

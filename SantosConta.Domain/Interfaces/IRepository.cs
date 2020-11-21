using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.Domain
{
    public interface IRepository<T>
    {
        void Incluir(T entidade);
        void Alterar(T entidade);
        void Excluir(string id);
        T ObterPorId(string id);
        IEnumerable<T> ObterTodos(string usuarioId);

        IEnumerable<string> Validar();
    }
}

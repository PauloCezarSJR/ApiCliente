using ApiCliente.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCliente.Repository
{
    public interface IEnderecoRepository
    {
        Task<Endereco> Atualizar(Endereco endereco);
        void Excluir(Endereco endereco);
        Task<IList<Endereco>> ListarTodos();
        Task<Endereco> BuscarPorID(int idEndereco);
    }
}

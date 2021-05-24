using ApiCliente.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCliente.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> Adicionar(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<object> Excluir(int idCliente);
        Task<List<Cliente>> ListarTodos();
        Task<Cliente> BuscarPorID(int idCliente);
    }
}

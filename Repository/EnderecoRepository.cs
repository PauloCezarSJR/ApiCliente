using ApiCliente.Data;
using ApiCliente.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCliente.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private DataContext _context = new DataContext(new DbContextOptions<DataContext>());
        public EnderecoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Endereco> Atualizar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }
        public async void Excluir(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }
        public async Task<IList<Endereco>> ListarTodos()
        {
            var endereco = await _context.Enderecos.ToListAsync();
            return endereco;
        }
        public async Task<Endereco> BuscarPorID(int idEndereco)
        {
            var endereco = await _context.Enderecos.Where(x => x.id == idEndereco).FirstOrDefaultAsync();
            return endereco;
        }
    }
}

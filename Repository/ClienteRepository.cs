using ApiCliente.Data;
using ApiCliente.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCliente.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private DataContext _context = new DataContext(new DbContextOptions<DataContext>());
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            cliente.Validate();
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            cliente.Validate();
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<Object> Excluir(int idCliente)
        {
            _context.Clientes.Remove(_context.Clientes.Where(x => x.id == idCliente).FirstOrDefault());
            await _context.SaveChangesAsync();
            return new { mensagem = "Cliente excluido com sucesso"};

        }
        public async Task<List<Cliente>>  ListarTodos()
        {
            var clientes = await _context.Clientes.Include(x => x.Endereco).ToListAsync();
            return clientes;
        }
        public async Task<Cliente> BuscarPorID(int idCliente)
        {
            var cliente = await _context.Clientes.Where(x=>x.id == idCliente).Include(x => x.Endereco).FirstOrDefaultAsync();
            return cliente;
        }
    }
}

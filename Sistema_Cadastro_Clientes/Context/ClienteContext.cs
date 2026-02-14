using Microsoft.EntityFrameworkCore;
using Sistema_Cadastro_Clientes.Classes;

namespace Sistema_Cadastro_Clientes.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) 
        {
        
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}

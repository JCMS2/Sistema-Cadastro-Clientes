using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sistema_Cadastro_Clientes.Context
{
    public class ClienteContextFactory : IDesignTimeDbContextFactory<ClienteContext>
    {
        public ClienteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClienteContext>();

            // Configuração para ler o arquivo JSON
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("ConecaoPadrao");

            // Validação simples
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("A string de conexão 'ConecaoPadrao' não foi encontrada no appsettings.json.");
            }

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new ClienteContext(optionsBuilder.Options);
        }
    }
}
using Loja.Dominio;
using Loja.Repositorios.SqlServer.EF.Migrations;
using Loja.Repositorios.SqlServer.EF.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorios.SqlServer.EF
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("name=lojaConnectionString")
        {
            //Database.SetInitializer(new LojaDbInitializer());

            //1. Enable-Migrations - digitar no console do Nuget.
            //2. Update-Database

            Database.SetInitializer(new 
                MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
        }
    }
}

namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorios.SqlServer.EF.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.EF.LojaDbContext";
        }

        protected override void Seed(Loja.Repositorios.SqlServer.EF.LojaDbContext context)
        {

        }
    }
}
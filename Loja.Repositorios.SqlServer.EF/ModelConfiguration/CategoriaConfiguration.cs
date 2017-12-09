using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
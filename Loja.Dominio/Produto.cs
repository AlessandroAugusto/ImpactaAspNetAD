using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public virtual Categoria Categoria { get; set; }
        public String Nome { get; set; }
        public Decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}

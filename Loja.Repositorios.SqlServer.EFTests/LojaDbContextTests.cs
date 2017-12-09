using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Dominio;
using System.Diagnostics;
using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _db = new LojaDbContext();

        [ClassInitialize]
        public static void InicializarTestes(TestContext contexto)
        {
            _db.Database.Log = LogarQueries;
        }

        private static void LogarQueries(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirPapelariaTest()
        {
            using (var db = new LojaDbContext())
            {
                if (!db.Categorias.Any(c => c.Nome == "Papelaria"))
                {
                    var papelaria = new Categoria();
                    papelaria.Nome = "Papelaria";

                    db.Categorias.Add(papelaria);

                    db.SaveChanges(); 
                }
            }

            InserirProdutoTeste();
            EditarProdutoTeste();
            ExcluirProdutoTeste();
        }
        
        public void InserirProdutoTeste()
        {
            var caneta = new Produto();
            caneta.Estoque = 5;
            caneta.Nome = "Caneta";
            caneta.Preco = 22.06m;
            caneta.Categoria = _db.Categorias
                .Where(c => c.Nome == "Papelaria").Single();

            _db.Produtos.Add(caneta);
            _db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            if (!_db.Produtos.Any(p => p.Nome == "Barbeador"))
            {
                var barbeador = new Produto();
                barbeador.Nome = "Barbeador";
                barbeador.Estoque = 33;
                barbeador.Preco = 22.34m;
                barbeador.Categoria = new Categoria { Nome = "Perfumaria" };

                _db.Produtos.Add(barbeador);
                _db.SaveChanges(); 
            }
        }
                
        public void EditarProdutoTeste()
        {
            var caneta = _db.Produtos.Single(p => p.Nome == "Caneta");
            caneta.Preco = 51;
            _db.SaveChanges();
        }
                
        public void ExcluirProdutoTeste()
        {
            var caneta = _db.Produtos.Single(p => p.Nome == "Caneta");
            _db.Produtos.Remove(caneta);
            _db.SaveChanges();

            Assert.IsFalse(_db.Produtos.Any(p => p.Nome == "Caneta"));
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            // usar modificador virtual 
            //para a propriedade Categoria.

            //var barbeador = _db.Produtos.Single(p => p.Nome == "Barbeador");

            //Assert.IsNull(barbeador.Categoria);
        }

        [TestMethod]
        public void LazyLoadLigadoTeste()
        {
            // usar modificador virtual 
            //para a propriedade Categoria.

            var barbeador = _db.Produtos.Single(p => p.Nome == "Barbeador");

            Assert.AreEqual(barbeador.Categoria.Nome, "Perfumaria");
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var barbeador = _db.Produtos
                .Include(p => p.Categoria)
                .Single(p => p.Nome == "Barbeador");

            Assert.AreEqual(barbeador.Categoria.Nome, "Perfumaria");
        }

        [TestMethod]
        public void QueryableTeste()
        {
            var query = _db.Produtos.Where(p => p.Preco > 10);

            if (true)
            {
                query = query.Where(p => p.Estoque > 5);
            }

            query = query.OrderByDescending(p => p.Preco);

            var primeiro = query.First();
            //var ultimo = query.AsEnumerable().Last();
            //var unico = query.Single();
            var todos = query.ToList();
        }

        [ClassCleanup]
        public static void FinalizarTestes()
        {
            _db.Dispose();
        }
    }
}
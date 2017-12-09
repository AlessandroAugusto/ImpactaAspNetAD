using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AW.Wcf.Testes.ProdutosServiceReference;
using AW.Wcf.Testes.GeocodeServiceReference;

namespace AW.Wcf.Testes
{
    [TestClass]
    public class ProdutosTeste
    {
        [TestMethod]
        public void SelecionarTeste()
        {
            using (var produtosClient = new ProdutosClient())
            {
                var produto = produtosClient.Selecionar(316);

                Assert.AreEqual(produto.Name, "Blade");
            }
        }

        [TestMethod]
        public void SelecionarPorNomeTeste()
        {
            using (var produtosClient = new ProdutosClient())
            {
                var produtos = produtosClient.SelecionarPorNome("mountain");

                Assert.AreEqual(produtos.Length, 94);
            }
        }
    }
}

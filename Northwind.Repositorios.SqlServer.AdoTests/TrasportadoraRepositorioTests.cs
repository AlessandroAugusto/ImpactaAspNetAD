using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using System;


namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class TrasportadoraRepositorioTests
    {
        TransportadoraRepositorio _rep = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {

            var transportadoras = _rep.Selecionar();

            Assert.AreNotEqual(0, transportadoras.Count);

            foreach (var transportadora in transportadoras)
            {
                Console.WriteLine($"{transportadora.Id} - {transportadora.Nome}");
            }


        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            var transportadora = _rep.Selecionar(2);
            Assert.IsNotNull(transportadora);

            transportadora = _rep.Selecionar(0);
            Assert.IsNull(transportadora);


        }

        [TestMethod()]
        public void CudTest()
        {
            //Create
            var transportadora = new Transportadora();
            transportadora.Nome = $"Trans_{DateTime.Now.ToString("HHmmss")}";
            transportadora.Telefone = $"Trans_{DateTime.Now.ToString("HHmmss")}";
            _rep.Inserir(transportadora);

            //Update
            String novoNome = $"Trans{DateTime.Now.ToString("HHmmss")}_Editado";
            transportadora.Nome = novoNome;
            _rep.Atualizar(transportadora);

            transportadora = _rep.Selecionar(transportadora.Id);

            Assert.IsTrue(transportadora.Nome==novoNome);

            _rep.Excluir(transportadora.Id);

            transportadora = _rep.Selecionar(transportadora.Id);

            Assert.IsNull(transportadora);


        }
    }
}
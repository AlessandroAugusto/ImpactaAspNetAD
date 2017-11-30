using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class TransportadoraRepositorioTests
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var transportadoras = _repositorio.Selecionar();

            Assert.AreNotEqual(0, transportadoras.Count);

            foreach (var transportadora in transportadoras)
            {
                Console.WriteLine($"{transportadora.Nome} - {transportadora.Telefone}");
            }
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            var transportadora = _repositorio.Selecionar(1);
            Assert.IsNotNull(transportadora);

            transportadora = _repositorio.Selecionar(4);
            Assert.IsNull(transportadora);
        }
    }
}
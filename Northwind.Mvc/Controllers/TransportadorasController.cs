using Northwind.Dominio;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc.Controllers
{
    public class TransportadorasController : Controller
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        // GET: Transportadoras
        public ActionResult Index()
        {
            return View(_repositorio.Selecionar());
        }

        // GET: Transportadoras/Details/5
        public ActionResult Details(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // GET: Transportadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadoras/Create
        [HttpPost]
        public ActionResult Create(Transportadora transportadora)
        {
            try
            {
                _repositorio.Inserir(transportadora);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transportadoras/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // POST: Transportadoras/Edit/5
        [HttpPost]
        public ActionResult Edit(Transportadora transportadora)
        {
            try
            {
                _repositorio.Atualizar(transportadora);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transportadoras/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // POST: Transportadoras/Delete/5
        [HttpPost]
        public ActionResult Delete(Transportadora transportadora)
        {
            try
            {
                _repositorio.Excluir(transportadora.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

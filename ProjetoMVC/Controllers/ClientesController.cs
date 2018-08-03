using AutoMapper;
using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjetoMVC.ViewModels;
using ProjetoDDD.Application.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            this.clienteApp = clienteApp;
        }

        /// <summary>
        /// Lista completa de clientes.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var clientes = clienteApp.GetAll();
            return View(clientes);
        }

        /// <summary>
        /// Detalhes do cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var cliente = clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        /// <summary>
        /// Get pra tela de criação de cliente.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post criação de cliente.
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        /// <summary>
        /// Get pra tela de edição de cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            //var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteApp.GetById(id));
            var clienteViewModel = new ClienteViewModel(clienteApp.GetById(id));
            return View(clienteViewModel);
        }

        /// <summary>
        /// Post edição de cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteApp.GetById(id));
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            var cliente = clienteApp.GetById(id);
            clienteApp.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}

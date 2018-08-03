using AutoMapper;
using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjetoMVC.ViewModels;
using ProjetoDDD.Application.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService produtoApp;

        public ProdutosController(IProdutoAppService produtoApp)
        {
            this.produtoApp = produtoApp;
        }

        /// <summary>
        /// Lista completa de produtos.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int clienteId)
        {
            var produtos = produtoApp.GetAllByClienteId(clienteId);
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
            return View(produtoViewModel);
        }

        /// <summary>
        /// Detalhes do produto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var produto = produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        /// <summary>
        /// Get pra tela de criação de produto.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int clienteId)
        {
            return View(new ProdutoViewModel(clienteId));
        }

        /// <summary>
        /// Post criação de produto.
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                produtoApp.Add(produtoDomain, produtoViewModel.ClienteId);

                return RedirectToAction("Index", new { clienteId = produtoViewModel.ClienteId });
            }

            return View(produtoViewModel);
        }

        /// <summary>
        /// Get pra tela de edição de produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var produtoViewModel = new ProdutoViewModel(produtoApp.GetById(id));
            return View(produtoViewModel);
        }

        /// <summary>
        /// Post edição de produto.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                produtoApp.Update(produtoDomain);

                return RedirectToAction("Index", new { clienteId = produtoViewModel.ClienteId });
            }

            return View(produtoViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produtoApp.GetById(id));
            return View(produtoViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            var produto = produtoApp.GetById(id);
            produtoApp.Remove(produto);

            return RedirectToAction("Index", new { clienteId = produto.Cliente.ClienteId });
        }
    }
}

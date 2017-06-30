using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inicial.Dominio;
using Inicial.Persistencia;
using Inicial.Filtros;

namespace Inicial.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto

        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            //List<Produto> produtos = DBProduto.GetByNome("");
            List<Produto> produtos = DBProduto.GetAll();
           // ViewBag.Produtos = produtos;
            return View(produtos);
        }
    
        public ActionResult Form()
        {
            
            IList < CategoriaDoProduto > categorias = DBCategoriaDoProduto.GetAll();
            ViewBag.Produto = new Produto();
            ViewBag.Categorias = categorias;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.IdCategoria.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }

            if (ModelState.IsValid)
            {
                DBProduto.Save(produto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                IList<CategoriaDoProduto> categorias = DBCategoriaDoProduto.GetAll();
                ViewBag.Categorias = categorias;
                return View("Form");
            }

               
        }
        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            Produto produto = DBProduto.GetById(id);
            ViewBag.Produto = produto;
            return View();
        }
        public ActionResult DecrementaQtd(int id)
        {
            
            Produto produto = DBProduto.GetById(id);
            produto.Quantidade--;
            DBProduto.Save(produto);
            return Json(produto);
           
        }

    }
}
using Inicial.Dominio;
using Inicial.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inicial.Filtros;

namespace Inicial.Controllers
{
    [AutorizacaoFilter]
    public class CategoriaDoProdutoController : Controller
    {
        // GET: CategoriaDoProduto
        // [Route("categorias", Name = "ListaCategorias")]
        public ActionResult Index()
        {
            List<CategoriaDoProduto> categorias = DBCategoriaDoProduto.GetAll();
            return View(categorias);
        }
        public ActionResult Form()
        {
            ViewBag.Categoria = new CategoriaDoProduto();
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoriaDoProduto)
        {
            if (categoriaDoProduto.Id == 0)
            {
                List<CategoriaDoProduto> existe = DBCategoriaDoProduto.GetByNome(categoriaDoProduto.Nome);
                if (existe.Count > 0)
                {
                    ModelState.AddModelError("categoriaDoProduto.NomeJaCadastrado", "Nome da Categoria de Produtos já Cadastrado");
                }
            }
            if (ModelState.IsValid)
            {
                DBCategoriaDoProduto.Save(categoriaDoProduto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categoria = categoriaDoProduto;
                return View("Form");
            }
        }
        public ActionResult Visualiza(int id)
        {
            CategoriaDoProduto categoria = DBCategoriaDoProduto.GetById(id);
            ViewBag.Categoria = categoria;
            return View();
        }
        public ActionResult Altera(CategoriaDoProduto categoria)
        {
            if (ModelState.IsValid)
            {
                DBCategoriaDoProduto.Save(categoria);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categoria = categoria;
                return View("Visualiza");
            }

        }
        public ActionResult Excluir(int id)
        {
            {
                DBCategoriaDoProduto.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
using Inicial.Dominio;
using Inicial.Filtros;
using Inicial.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    [AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuarios = DBUsuario.GetAll();
          //  ViewBag.Usuarios = usuarios;
            return View(usuarios);
        }
        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }
        public ActionResult Visualiza(int id)
        {
            Usuario usuario = DBUsuario.GetById(id);
            ViewBag.Usuario = usuario;
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Adiciona(Usuario usuario)
        {
            List<Usuario> existe = DBUsuario.GetByNome(usuario.Nome);
            if (existe.Count > 0)
            {
                ModelState.AddModelError("usuario.NomeJaCadastrado", "Nome já Cadastrado");
            }
            if (ModelState.IsValid)
            {
                DBUsuario.Save(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuario = usuario; ;
                return View("Form");
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Altera(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                DBUsuario.Save(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuario = usuario; 
                return View("Visualiza");
            }
        }
       
        public ActionResult Excluir(int id)
        {
            {
                DBUsuario.Delete(id);
                return RedirectToAction("Index");
            }
        }

        


    }
}
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
       
        public ActionResult Excluir(int id)
        {
            {
                DBUsuario.Delete(id);
                return RedirectToAction("Index");
            }
        }

    }
}
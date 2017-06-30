using Inicial.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult RecuperaSenha(String email)
        //{
            
        //    Usuario usuario = dao.BuscaPorEmail(email);
        //    GeraNovaSenha(usuario);
        //    dao.Atualiza(usuario);
        //    EnviaNovaSenhaParaOEmailDoUsuario(usuario);
        //    return View();
        //}
    }
}
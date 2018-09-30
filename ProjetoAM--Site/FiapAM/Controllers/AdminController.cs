using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiapAM.Filter;
using FiapAM.Models;

namespace FiapAM.Controllers
{
    [LogFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario UsuarioLogin)
        {
            if(UsuarioLogin != null)
            {
                if(UsuarioLogin.EmailUsuario.Equals("admin@teste.com"))
                {
                    Session["UsuarioLogado"] = UsuarioLogin;
                    return View();
                }
                else
                {
                    TempData["Mensagem"] = "Usuario e Senha Inválido";
                    return View("Index", UsuarioLogin);
                }
            }
            else
            {
                TempData["Mensagem"] = "Usuário ou Senha inválida.";
                return View("Index", UsuarioLogin);
            }

        }
    }
}
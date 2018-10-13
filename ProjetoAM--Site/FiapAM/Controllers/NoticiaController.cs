using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiapAM.DAO;
using FiapAM.Models;

namespace FiapAM.Controllers
{
    public class NoticiaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            if (Session["UsuarioLogado"] != null)
            {
                NoticiaDAO dao = new NoticiaDAO();
                IList<Noticia> lista = dao.ListarTodos();

                return View(lista);
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }


        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            if (Session["UsuarioLogado"] != null)
            {
                ModelState.Clear();
                return View(new Noticia());
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }

        }

        [HttpPost]
        public ActionResult Cadastrar(Noticia news)
        {
            NoticiaDAO NewsDAO = new NoticiaDAO();
            NewsDAO.Inserir(news);
            TempData["mensagem"] = "Nova noticia cadastrada com sucesso!";
            return RedirectToAction("Index");
          
            
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            if (Session["UsuarioLogado"] != null)
            {
                return View(new NoticiaDAO().BuscarPorId(Id));
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }

        }

        [HttpPost]
        public ActionResult Editar(Noticia News)
        {

                NoticiaDAO _noticiaDAO = new NoticiaDAO();
                _noticiaDAO.Editar(News);
                return View();
        }


        [HttpGet]
        public ActionResult Excluir(int id)
        {
            if(Session["UsuarioLogado"] != null) { 
            new NoticiaDAO().Deletar(id);

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }
        }

        [HttpGet]
        public ActionResult Consultar(int _id)
        {
            Noticia _news = new NoticiaDAO().BuscarPorId(_id);
            return View(_news);
        }
    }
}
using FiapAM.DAO;
using FiapAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiapAM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            NoticiaDAO dao = new NoticiaDAO();
            IList<Noticia> lista = dao.ListarTodos();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ModelState.Clear();
            return View(new Noticia());
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
            return View(new NoticiaDAO().BuscarPorId(Id));
        }

        [HttpPost]
        public ActionResult Editar(Noticia News)
        {
            NoticiaDAO _noticiaDAO = new NoticiaDAO();
            _noticiaDAO.Editar(News);
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int _id)
        {
            new NoticiaDAO().Deletar(_id);

            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Consultar(int _id)
        {
            Noticia _news = new NoticiaDAO().BuscarPorId(_id);
            return View(_news);
        }
    }
}
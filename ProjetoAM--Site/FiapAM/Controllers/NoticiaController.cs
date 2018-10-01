using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiapAM.DAO;
using FiapAM.Models;

namespace FiapAM.Controllers
{
    public class NoticiaController : Controller
    {
        [HttpPost]
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
            TempData["mensagem"] = "Usuario Inserido com Sucesso!";
            return RedirectToAction("Index");

            /*bool status = true;

            if (ModelState.IsValid)
            {

                NoticiaDAO NewsDAO = new NoticiaDAO();

                //Pesquisar como funciona esse if
                Noticia NoticiaExiste = NewsDAO.BuscarPorNome(news.Titulo);
                if ((NoticiaExiste == null) || !String.Equals(NoticiaExiste.Titulo, news.Titulo))
                {
                    NewsDAO.Inserir(news);
                    TempData["mensagem"] = "Usuario Inserido com Sucesso!";
                    //fazer o temp data para a Mensagem
                }
                else
                {
                    ModelState.AddModelError("", "Investidor já existe");
                    status = false;
                }

            }
            else
            {
                status = false;
            }
            //Terminar as validações e redirecionamento
            //Fazendo o redirecionamento
            if (status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            */
        }

        //[HttpPost]
    }
}
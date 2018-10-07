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
        public ActionResult InserirImagem()
        {
            ModelState.Clear();
            return View(new Noticia());
        }

        [HttpPost]
        public ActionResult InserirImagem(Noticia news)
        {
            NoticiaDAO NewsDAO = new NoticiaDAO();
            NewsDAO.Inserir(news);
            TempData["mensagem"] = "Nova noticia cadastrada com sucesso!";
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult CadastrarImagem(int Id)
        {
            return View(new NoticiaDAO().BuscarPorId(Id));
        }

        [HttpPost]
        public ActionResult CadastrarImagem(Noticia News)
        {
            NoticiaDAO _noticiaDAO = new NoticiaDAO();
            _noticiaDAO.Editar(News);
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int _id)
        {
            new NoticiaDAO().Deletar(_id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Consultar(int _id)
        {
            Noticia _news = new NoticiaDAO().BuscarPorId(_id);
            return View(_news);
        }
    }
}
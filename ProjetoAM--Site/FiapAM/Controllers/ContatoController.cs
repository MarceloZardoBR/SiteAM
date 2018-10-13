using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiapAM.DAO;
using FiapAM.Models;

namespace FiapAM.Controllers
{
    
    public class ContatoController : Controller
    {
        [HttpGet]
        public ActionResult Index(Models.Contato Contato)
        {
            IList<TipoContato> ListaTipoContato = new TipoContatoDAO().ListarTodos();
            ViewBag.ListaTipoContato = ListaTipoContato;
            ModelState.Clear();
            return View(Contato);
        }

        [HttpPost]
        public ActionResult Gravar(Models.Contato Contato)
        {

            if (ModelState.IsValid)
            {
                new ContatoDAO().Inserir(Contato);
                return View("GravarSucesso");

            }
            else
            {
                // ENVIAR O USUÁRIO PARA TELA DE ERRO.
                IList<TipoContato> ListaTipoContato = new TipoContatoDAO().ListarTodos();
                ViewBag.ListaTipoContato = ListaTipoContato;
                return View("GravarErro");
            }


        }

        [HttpGet]
        public ActionResult MotivoContato()
        {
            if (Session["UsuarioLogado"] != null)
            {
                ContatoDAO dao = new ContatoDAO();
                IList<Contato> listarTudo = dao.ListaTodos();
                return View(listarTudo);
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult VisualizarContato(int Id)
        {
            if (Session["UsuarioLogado"] != null)
            {
                return View(new ContatoDAO().Vizualizar(Id));
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada!, Por Favor efetuar login novamente";
                return RedirectToAction("Index", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            ContatoDAO _dao = new ContatoDAO();
            _dao.Excluir(Id);
            return RedirectToAction("MotivoContato");
        }
    }
}
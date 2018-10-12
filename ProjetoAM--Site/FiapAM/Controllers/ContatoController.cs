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
                return View("Index", Contato);
            }


        }

        [HttpGet]
        public ActionResult MotivoContato()
        {
            ContatoDAO dao = new ContatoDAO();
            IList<Contato> listarTudo = dao.ListaTodos();
            return View(listarTudo);
        }

        [HttpGet]
        public ActionResult VisualizarContato(int Id)
        {
            return View(new ContatoDAO().Vizualizar(Id));
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
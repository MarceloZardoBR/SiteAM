using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiapAM.DAO;
using FiapAM.Filter;
using FiapAM.Models;

namespace FiapAM.Controllers
{
    [AcessoFilter]
    public class InvestidorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            InvestidorDAO dao = new InvestidorDAO();
            IList<Investidor> lista = dao.ListarTodos();
            return View(lista);
        }


        [HttpGet]
        public ActionResult Inserir()
        {
            ModelState.Clear();
            return View(new Investidor());
        }

        [HttpPost]
        public ActionResult Inserir(Investidor Invest)
        {
            bool status = true;

            if (ModelState.IsValid) { 

            InvestidorDAO InvestDAO = new InvestidorDAO();
            
            //Pesquisar como funciona esse if
            Investidor InvestExiste = InvestDAO.BuscarPorNome(Invest.NomeInvestidor);
            if((InvestExiste == null) || !String.Equals(InvestExiste.NomeInvestidor, Invest.NomeInvestidor))
            {
                InvestDAO.Inserir(Invest);
                TempData["mensagem"] = "Usuario Inserido com Sucesso!";
                //fazer o temp data para a Mensagem
            }else
            {
                ModelState.AddModelError("","Investidor já existe");
                status = false;
            }

            }else
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
            
        }

        [HttpGet]
        public ActionResult Consultar(int id)
        {
            return View(new InvestidorDAO().Buscar(id));

        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            new InvestidorDAO().Deletar(Id);
            TempData["mensagem"] = "Produto excluido com sucesso";
            return RedirectToAction("Index");
        }
    }
}
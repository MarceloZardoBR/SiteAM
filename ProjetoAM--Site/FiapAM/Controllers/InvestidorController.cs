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
            if(Session["UsuarioLogado"] != null)
            {
                InvestidorDAO dao = new InvestidorDAO();
                IList<Investidor> lista = dao.ListarTodos();
                return View(lista);
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada! Efetue o Login novamente";
                return RedirectToAction("Index","Admin");
            }
            
        }


        [HttpGet]
        public ActionResult Inserir()
        {
            if (Session["UsuarioLogado"] != null)
            {
                ModelState.Clear();
                return View(new Investidor());
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada! Efetue o Login novamente";
                return RedirectToAction("Index", "Admin");
            }
            
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
                TempData["mensagem"] = "Investidor Inserido com Sucesso!";
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
        public ActionResult Editar(int Id)
        {
            if (Session["UsuarioLogado"] != null)
            {
                return View(new InvestidorDAO().Buscar(Id));
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada! Efetue o Login novamente";
                return RedirectToAction("Index", "Admin");
            }
            
        }

        [HttpPost]
        public ActionResult Editar(Investidor Invest) 
        {
            bool status = true;

            if (ModelState.IsValid)
            {

                InvestidorDAO InvestDAO = new InvestidorDAO();

                //Pesquisar como funciona esse if
                Investidor InvestExiste = InvestDAO.BuscarPorNome(Invest.NomeInvestidor);
                if ((InvestExiste == null) || !String.Equals(InvestExiste.NomeInvestidor, Invest.NomeInvestidor))
                {
                    InvestDAO.Editar(Invest);
                    TempData["mensagem"] = "Investidor Editado com Sucesso!";
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
        }

        [HttpGet]
        public ActionResult Consultar(int id)
        {
            if (Session["UsuarioLogado"] != null)
            {
                return View(new InvestidorDAO().Buscar(id));
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada! Efetue o Login novamente";
                return RedirectToAction("Index", "Admin");
            }
            
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
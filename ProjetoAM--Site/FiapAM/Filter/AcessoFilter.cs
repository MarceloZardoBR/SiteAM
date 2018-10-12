using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiapAM.Filter
{
    public class AcessoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["UsuarioLogado"] == null)
            {

                filterContext.Controller.TempData.Add("Mensagem", "Sessão Expirada! Efetue o login novamente.");

                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Admin");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);

            }

            base.OnActionExecuting(filterContext);

        }
    }
}
﻿using FiapAM.DAO;
using FiapAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiapAM.Filter
{
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log log = new Log();
            log.DataLog = DateTime.Now;
            log.Caminho = filterContext.HttpContext.Request.Url.ToString();
            new LogDAO().Inserir(log);
        }

    }
}
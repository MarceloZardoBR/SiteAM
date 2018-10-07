using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiapAM.DAO
{
    public class LogDAO
    {
        public void Inserir(Models.Log Log)
        {
            using (DAO.DataBaseContext ctx = new DAO.DataBaseContext())
            {
                ctx.Log.Add(Log);
                ctx.SaveChanges();
            }
        }

    }
}
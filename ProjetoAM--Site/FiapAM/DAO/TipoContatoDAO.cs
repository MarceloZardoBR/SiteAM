using FiapAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiapAM.DAO
{
    public class TipoContatoDAO
    {
        public IList<TipoContato> ListarTodos()
        {
            DAO.DataBaseContext ctx = new DAO.DataBaseContext();
            IList<TipoContato> ListaTipoContato = ctx.TipoContato.ToList<TipoContato>();
            return ListaTipoContato;
        }

       
    }
}
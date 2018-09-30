using FiapAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiapAM.DAO
{
    
    public class ContatoDAO
    {
        public IList<Contato> ListaTodos()
        {
            return new DataBaseContext().Contato.ToList<Contato>();
        }

        public void Inserir(Contato Cont)
        {
            using (DataBaseContext Dbctx = new DataBaseContext())
            {
                Dbctx.Contato.Add(Cont);
                Dbctx.SaveChanges();
            }
        }
    }
}
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

        public Contato Vizualizar(int id)
        {
            using (DataBaseContext _dbctx = new DataBaseContext())
            {
                return _dbctx.Contato.Find(id);
               
            }
        }

        public void Excluir(int id)
        {
            using(DataBaseContext _dbctx = new DataBaseContext())
            {
                Contato contato = Vizualizar(id);
                _dbctx.Entry(contato).State = System.Data.Entity.EntityState.Deleted;
                _dbctx.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiapAM.Models;

namespace FiapAM.DAO
{
    public class InvestidorDAO
    {
        public IList<Investidor> ListarTodos()
        {
            return new DataBaseContext().Investidor.ToList<Investidor>();
            
        }

        public Investidor Buscar(int id)
        {
            return new DataBaseContext().Investidor.Find(id);
        }

        public Investidor BuscarPorNome(String Nome)
        {
            Investidor Investidor = new Investidor();
            using (DataBaseContext DbContext = new DataBaseContext())
            {
                Investidor = DbContext.Investidor.Where(v => v.NomeInvestidor == Nome).SingleOrDefault<Investidor>();
            }

            return Investidor;
        }

        public void Deletar(int id)
        {
            using(DataBaseContext DbContext = new DataBaseContext())
            {
                Investidor Investidor = Buscar(id);
                DbContext.Entry(Investidor).State = System.Data.Entity.EntityState.Deleted;
                DbContext.SaveChanges();
            }

        }

        public void Editar(Investidor Invest){
            using(DataBaseContext DbContext = new DataBaseContext())
            {
                DbContext.Entry(Invest).State = System.Data.Entity.EntityState.Modified;
                DbContext.SaveChanges();
            }

        }
        public void Inserir(Investidor Invest)
        {
            using(DataBaseContext DbContext = new DataBaseContext())
            {
                DbContext.Investidor.Add(Invest);
                DbContext.SaveChanges();
            }
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiapAM.Models;

namespace FiapAM.DAO
{
    public class NoticiaDAO
    {
        public IList<Noticia> ListarTodos()
        {
            return new DataBaseContext().Noticias.Include("ListaImagem").ToList<Noticia>();
        }

        public void Inserir(Noticia News)
        {
            using(DataBaseContext Dbx = new DataBaseContext())
            {
                Dbx.Noticias.Add(News);
                Dbx.SaveChanges();
            }
        }

        public void InserirImagem(Noticia News)
        {
            using (DataBaseContext DbContext = new DataBaseContext())
            {
                DbContext.Entry(News).State = System.Data.Entity.EntityState.Modified;
                DbContext.SaveChanges();
            }

        }

        public Noticia BuscarPorId(int Id)
        {
            return new DataBaseContext().Noticias.Include("ListaImagem").FirstOrDefault<Noticia>(n => n.Idnoticia == Id);
        }

        public Noticia BuscarPorNome(String nome)
        {
            Noticia News = new Noticia();
            using(DataBaseContext Dbx = new DataBaseContext())
            {
                News = Dbx.Noticias.Include("ListaImagem").Where(v => v.Titulo == nome).SingleOrDefault<Noticia>();
            }

            return News;
        }

        public void Editar(Noticia News)
        {
            using (DataBaseContext DbContext = new DataBaseContext())
            {
                DbContext.Entry(News).State = System.Data.Entity.EntityState.Modified;
                DbContext.SaveChanges();
            }

        }


            public void Deletar(int id)
            {

            Noticia noticia = BuscarPorId(id);
            using (DataBaseContext Dbx = new DataBaseContext())
            {
                
                Dbx.Noticias.Attach(noticia);
                Dbx.Noticias.Remove(noticia);
                Dbx.SaveChanges();
            }
        }
    }
}
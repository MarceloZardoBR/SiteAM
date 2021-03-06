﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiapAM.Models;

namespace FiapAM.DAO
{
    public class NoticiaDAO
    {

        //public IList<Noticia> ListaTop3()
        //{

//        }
        public IList<Noticia> ListarTodos()
        {
            return new DataBaseContext().Noticias.ToList<Noticia>();
        }

        public void Inserir(Noticia news)
        {
            
            using(DataBaseContext Dbx = new DataBaseContext())
            {
                //News.Data = DateTime.Now.ToString();
                Dbx.Noticias.Add(news);
                Dbx.SaveChanges();
            }
        }

        public Noticia BuscarPorId(int Id)
        {
            return new DataBaseContext().Noticias.Find(Id);
        }

        public Noticia BuscarPorNome(String nome)
        {
            Noticia News = new Noticia();
            using(DataBaseContext Dbx = new DataBaseContext())
            {
                News = Dbx.Noticias.Where(v => v.Titulo == nome).SingleOrDefault<Noticia>();
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
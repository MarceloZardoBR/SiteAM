using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace FiapAM.Models
{

    [Table("NOTICIA")]
    public class Noticia
    {

        public Noticia()
        {
            Data = DateTime.Now.ToString();
        }

        [Key]
        [Column("IDNOTICIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idnoticia { get; set; }

        [Column("TITULO")]
        [Display(Name = "Titulo da Noticia", Description = "Informe o Titulo da Noticia")]
        [Required(ErrorMessage = "Titulo obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Titulo deve possuir no mínimo 3 e no máximo 50 caracteres")]
        public String Titulo { get; set; }

        [Column("TEXTO")]
        [Display(Name = "Texto", Description = "Coloque o Texto da Noticia")]
        [Required(ErrorMessage = "Texto obrigatório")]
        [StringLength(3000, MinimumLength = 3, ErrorMessage = "O campo TEXTO deve possuir no mínimo 3 e no máximo 3000 caracteres")]
        public String Texto { get; set; }

        [Column("URLIMAGEM")]
        [Display(Name = "URL Imagem", Description = "Coloque o Imagem da Noticia")]
        public String UrlImagem { get; set; }

        [Column("DATA")]
        [Display(Name = "Data", Description = "Informe a data de hoje")]
        public String Data { get; set;}

        private int TextoLimit = 100;

        public String Descricao
        {
            get
            {
                if (this.Texto.Length > this.TextoLimit)
                {
                    return this.Texto.Substring(0, this.TextoLimit) + "...";
                }
                else
                {
                    return this.Texto;
                }

            }
        }
    }
        
    }
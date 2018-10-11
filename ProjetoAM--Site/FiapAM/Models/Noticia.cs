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
            ListaImagem = new Collection<Imagem>();
        }

        [Key]
        [Column("IDNOTICIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idnoticia { get; set; }

        [Column("TITULO")]
        [Display(Name = "Titulo da Noticia", Description = "Informe o Titulo da Noticia")]
        [Required(ErrorMessage = "Titulo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Titulo deve possuir no mínimo 3 e no máximo 50 caracteres")]
        public String Titulo { get; set; }

        [Column("TEXTO")]
        [Display(Name = "Texto", Description = "Coloque o Texto da Noticia")]
        [Required(ErrorMessage = "Texto obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo TEXTO deve possuir no mínimo 3 e no máximo 50 caracteres")]
        public String Texto { get; set; }

        public virtual ICollection<Imagem> ListaImagem { get; set; }

        
    }
}
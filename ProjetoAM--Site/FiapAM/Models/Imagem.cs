using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace FiapAM.Models
{
    [Table("IMAGEMNOTICIA")]
    public class Imagem
    {

        [Key]
        [Column("IDIMAGEM")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImagem { get; set; }

        [Column("ROTULO")]
        [Display(Name = "Rotulo", Description = "Insira um rótulo para a imagem")]
        [Required(ErrorMessage = "Rotulo obrigatório")]
        public String Rotulo { get; set; }

        [Column("CAMINHO")]
        [Display(Name = "Caminho da Imagem", Description ="Insira o caminho da Imagem")]
        [Required(ErrorMessage = "Rotulo obrigatório")]
        public String Caminho { get; set; }

        [Column("IDNOTICIA")]
        [Display(Name = "Id da noticia", Description = "Insira o ID da noticia para cadastro de imagem")]
        [Required(ErrorMessage = "ID Obrigatorio")]
        public int IdNoticia { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public Noticia Noticia { get; set; }
    }
}
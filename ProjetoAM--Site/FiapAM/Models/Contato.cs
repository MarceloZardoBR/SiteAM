using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace FiapAM.Models
{
    [Table("CONTATO")]
    public class Contato
    {

        [Key]
        [Column("IDCONTATO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//usado para auto incrementar o ID
        public int IdContato { get; set; }

        [Display(Name = "Nome", Description = "Digite o nome")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve possuir no mínimo 3 e no máximo 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Digite o nome sem números e caracteres especiais.")]
        [Column("NOMECONTATO")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "e-Mail obrigatório")]
        [EmailAddress]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Display(Name = "Mensagem", Description = "Digite o texto da mensagem")]
        [Required(ErrorMessage = "Mensagem Obrigatória")]
        [StringLength(2048, MinimumLength = 3, ErrorMessage = "O campo Nome deve possuir no mínimo 3 e no máximo 2048 caracteres")]
        [Column("MENSAGEM")]
        public string Mensagem { get; set; }

        //[ScriptIgnore]    

        //[ForeignKey("TIPOCONTATO")]
        [Column("IDTIPOCONTATO")]
        public int IdTipoContato { get; set; }

        public virtual TipoContato TipoContato { get; set; }   
      
    }
}
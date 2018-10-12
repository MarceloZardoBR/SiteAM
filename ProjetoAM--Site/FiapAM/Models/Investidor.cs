using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace FiapAM.Models
{
        [Table("INVESTIDOR")]
        public class Investidor
        {
         
            [Key]
            [Column("IDINVESTIDOR")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int IdInvestidor { get; set; }

            [Column("NOMEINVESTIDOR")]
            [Display(Name = "Nome Investidor", Description = "Digite o nome do Investidor")]
            [Required(ErrorMessage = "Nome obrigatório")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve possuir no mínimo 3 e no máximo 50 caracteres")]
            public String NomeInvestidor { get; set; }

            [Column("EMPRESAINVESTIDOR")]
            [Display(Name = "Nome Empresa Investidor", Description = "Digite o nome da empresa do investidor")]
            [Required(ErrorMessage = "Nome obrigatório")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve possuir no mínimo 3 e no máximo 50 caracteres")]
            public String EmpresaInvestidor { get; set; }

            [Column("EMAIL")]
            [Display(Name = "Email Investidor", Description = "Digite o email do investidor")]
            [Required(ErrorMessage = "Email obrigatório")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Email deve possuir no mínimo 3 e no máximo 50 caracteres")]
            public String Email { get; set; }

            [Column("TELEFONE")]
            [Display(Name = "Telefone Investidor", Description = "Digite o Telefone do investidor")]
            [Required(ErrorMessage = "Nome obrigatório")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Telefone deve possuir no mínimo 9 caracteres")]
            public String Telefone { get; set; }
            
    }
}
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
            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapAM.Models
{
    [Table("TIPOCONTATO")]
    public class TipoContato
    {
        [Key]
        [Column("IDTIPOCONTATO")]
        public int IdTipoContato { get; set; }

        [Column("NOMETIPOCONTATO")]
        public string NomeTipoContato { get; set; }
    }
}
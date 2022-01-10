using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_01.Models
{
    public class TipoDocumento
    {

        public int Id { get; set; }

        [StringLength(20)]
        public string Abreviatura { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public bool Activo { get; set; }



    }
}
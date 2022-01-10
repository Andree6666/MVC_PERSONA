using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_01.Models
{
    public class Persona
    {

        public int Id { get; set; }

        public int TipoDocumentoId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(200)]
        public string ApellidoMaterno { get; set; }

        public DateTime Registro { get; set; }

        
        public DateTime Nacimiento { get; set; }

        [StringLength(100)]
        public string NroDocumento { get; set; }

        public decimal Sueldo { get; set; }

       


    }
}
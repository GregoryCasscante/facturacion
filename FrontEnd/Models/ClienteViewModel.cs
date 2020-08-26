using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Identificador de la Compañía")]
        [Required]
        public int id_compania { get; set; }
        public IEnumerable<Compania> companias { get; set; }
        [Display(Name = "Identificación")]
        [Required]
        public string identificacion { get; set; }
        [Display(Name = "Tipo de Identificación")]
        [Required]
        public int tipo_identificacion { get; set; }
        public IEnumerable<Identificacion_Tipos> identificacion_tipos { get; set; }
        [Display(Name = "Activadad Económica")]
        [Required]
        public int actividad_economica { get; set; }
        public IEnumerable<Actividades_Economicas> actividades_economicas { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Género")]
        [Required]
        public string genero { get; set; }
        [Display(Name = "E-mail primario")]
        [Required]
        public string email1 { get; set; }
        [Display(Name = "E-mail secundario")]
        [Required]
        public string email2 { get; set; }
        [Display(Name = "Teléfono primario")]
        [Required]
        public string telefono1 { get; set; }
        [Display(Name = "Teléfono secundario")]
        [Required]
        public string telefono2 { get; set; }
        [Display(Name = "País")]
        [Required]
        public int pais { get; set; }
        public IEnumerable<Pais> paises { get; set; }
        [Display(Name = "Provincia")]
        [Required]
        public int provincia { get; set; }
        public IEnumerable<Provincia> provincias { get; set; }
        [Display(Name = "Cantón")]
        [Required]
        public int canton { get; set; }
        public IEnumerable<Canton> cantones { get; set; }
        [Display(Name = "Distrito")]
        [Required]
        public int distrito { get; set; }
        public IEnumerable<Distrito> distritos { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string dirrecion { get; set; }
        public System.DateTime fecha_creacion { get; set; }


    }
}
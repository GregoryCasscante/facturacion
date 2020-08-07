using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {

        [Display(Name = "Identificador")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Estado (Activo/Desactivado)")]
        [Required(ErrorMessage = "Debe de selecionar una opción")]
        public int estado { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "Debe de selecionar un usuario")]
        public string usuario { get; set; }


        //public string salt { get; set; }
        //public string clave { get; set; }

        [Display(Name = "Tipo de Usuario")]
        [Required(ErrorMessage = "Debe de selecionar un tipo de usuario")]
        public int tipo { get; set; }


        //public System.DateTime fecha_creacion { get; set; }
        //public Nullable<System.DateTime> ultimo_login { get; set; }

        [Display(Name = "Cédula o identificación")]
        [Required(ErrorMessage = "Debe de selecionar una Cédula o tipo de Identificación")]
        public string identificacion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de digitar un nombre")]
        public string nombre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe de digitar un email")]
        public string email1 { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe de digitar un email")]
        public string email2 { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Debe de digitar un número de teléfono")]
        public string telefono1 { get; set; }

        [Display(Name = "Teléfono 2")]
        [Required(ErrorMessage = "Debe de digitar un número de teléfono")]
        public string telefono2 { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "Debe de digitar un país")]
        public int pais { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Debe de digitar una provincia")]
        public int provincia { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Debe de digitar un cantón")]
        public int canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe de digitar un distrito")]
        public int distrito { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe de digitar una dirección")]
        public string direccion { get; set; }

    }
}
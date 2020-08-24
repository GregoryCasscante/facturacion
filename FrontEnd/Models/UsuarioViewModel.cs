using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using FrontEnd.Models;
using System.ComponentModel.DataAnnotations;
using BackEnd.Entities;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {

        [Display(Name = "Identificador")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Estado (Activo/Desactivado)")]
        [Required(ErrorMessage = "Debe de selecionar una opción")]
        public Nullable<int> estado { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe de selecionar un usuario")]
        public string usuario { get; set; }


        public string salt { get; set; }
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "Debe de selecionar una Clave")]
        public string clave { get; set; }

        [Display(Name = "Tipo de Usuario")]
        [Required(ErrorMessage = "Debe de selecionar un tipo de usuario")]
        public Nullable<int> tipo { get; set; }


        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> ultimo_login { get; set; }

        [Display(Name = "Cédula o identificación")]
        [Required(ErrorMessage = "Debe de selecionar una Cédula o tipo de Identificación")]
        public string identificacion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de digitar un nombre")]
        public string nombre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe de digitar un email")]
        public string email1 { get; set; }

        [DataType(DataType.EmailAddress)]
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
        public Nullable<int> pais { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Debe de digitar una provincia")]
        public Nullable<int> provincia { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Debe de digitar un cantón")]
        public Nullable<int> canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe de digitar un distrito")]
        public Nullable<int> distrito { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe de digitar una dirección")]
        public string direccion { get; set; }


        public Pais      UsuarioPais { get; set; }
        public Provincia UsuarioProvincia { get; set; }
        public Canton    UsuarioCanton { get; set; }
        public Distrito  UsuarioDistrito { get; set; }

        /* Valores secundarios de Listas  */
        public IEnumerable<Pais> Paises { get; set; }
        public IEnumerable<Provincia> Provincias { get; set; }
        public IEnumerable<Canton> Cantones { get; set; }
        public IEnumerable<Distrito> Distritos { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alumnos_Crud.Models
{

    //Creo una copia de la tabla alumno
    public class AlumnoCE
    {
        public int Id { get; set; }
        [Required]  // importo de data annotation
        //[Display(Name = "Ingrese nombre")]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Sexo { get; set; }
        //    //Agrego un estado
        //    //public int Estado { get; set; }

    }
    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    {
        //public int Estado { get; set; }
        //propiedad de lectura
        public string NombreCompleto { get { return Nombre + " " + Apellido; } }
    }
}
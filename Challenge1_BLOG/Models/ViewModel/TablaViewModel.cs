using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge1_BLOG.Models.ViewModel
{
    public class TablaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(300)]
        public string Contenido { get; set; }

        [Required]
        [StringLength(300)]
        public string Imagen { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required]
        [Display(Name = "Fecha de creación")]
        public DateTime Fecha_Creacion { get; set; }
    }
}
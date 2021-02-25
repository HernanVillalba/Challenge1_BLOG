﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge1_BLOG.Models.ViewModel
{
    public class ListTablaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
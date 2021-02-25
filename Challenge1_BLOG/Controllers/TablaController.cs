using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge1_BLOG.Models;
using Challenge1_BLOG.Models.ViewModel;

namespace Challenge1_BLOG.Controllers
{
    public class TablaController : Controller
    {
        public ActionResult Index()
        {
            List<ListTablaViewModel> lista;
            using (DB_CHALLENGE_BLOGEntities db = new DB_CHALLENGE_BLOGEntities())
            {
                lista = (from item in db.Tabla
                         select new ListTablaViewModel
                         {
                             Id = item.ID,
                             Titulo = item.Titulo,
                             Contenido = item.Contenido,
                             Imagen = item.Imagen,
                             Categoria = item.Categoria,
                             Fecha_Creacion = item.Fecha_Creacion
                         } ).ToList();

            }
            return View(lista);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
    }
}
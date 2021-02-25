using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge1_BLOG.Models;
using Challenge1_BLOG.Models.ViewModel;

namespace Challenge1_BLOG.Controllers
{
    public class GETController : Controller
    {
        Database db = new Database();
        
        //GET: Blog
        public ActionResult Index()
        {
            return View (db.Tabla.ToList());
        }
        public ActionResult Nuevo()
        {
            return View();
        }


        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Database db = new Database())
                    {
                        var tabla = new Tabla();
                        tabla.Titulo = model.Titulo;
                        tabla.Contenido = model.Contenido;
                        tabla.Imagen = model.Imagen;
                        tabla.Categoria = model.Categoria;
                        tabla.Fecha_Creacion = model.Fecha_Creacion;

                        db.Tabla.Add(tabla);
                        db.SaveChanges();
                    }
                    Redirect("Tabla/Index");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
    }
}
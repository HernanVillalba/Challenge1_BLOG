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
        [HttpGet]
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(db.Tabla.ToList());
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            var blog = new Tabla();
            if (id > 0)
            {
                //si el V, entonces pasó bien el id del blog y procedo a buscarlo en la DB.
                blog = db.Tabla.FirstOrDefault(e => e.ID == id);
            }
            else
            {
                //si el id recibido es 0, significa que no existe el registro.
                //entonces igualo la varibale 'blog' a null para mostrar el error en la view.
                blog = null;
            }

            return View(blog);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }
        /*
        //public ActionResult Agregar(string Titulo, string Contenido, string Imagen, string Categoria, DateTime Fecha_Creacion)
        ViewBag.Titulo = Titulo;
            ViewBag.Contenido = Contenido;
            ViewBag.Imagen = Imagen;
            ViewBag.Categoria = Categoria;
            ViewBag.Fecha_Creacion = Fecha_Creacion;
        */
        [HttpPost]
        public ActionResult Agregar(FormCollection formAgregar)
        {
            Tabla tabla = new Tabla();
            string message; // para mostrar si los datos fueron guardados correctamente.

            try
            {
                tabla.Titulo = formAgregar["Titulo"];
                tabla.Contenido = formAgregar["Contenido"];
                tabla.Imagen = formAgregar["Imagen"];
                tabla.Categoria = formAgregar["Categoria"];
                tabla.Fecha_Creacion = Convert.ToDateTime(formAgregar["Fecha_Creacion"]);
                db.Tabla.Add(tabla);

                if (db.SaveChanges() == 1)
                {
                    message = "Datos guardados correctamente.";
                }
                else
                {
                    message = "No se pudo guardar los datos.";
                }
            }
            catch (Exception ex)
            {
                message = "Exepcion generada. Detalles: " + ex.Message;
            }

            return RedirectToAction("Index","GET", new { message });
            //return View();
        }

    }
}
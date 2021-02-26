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

        //GET/posts
        [HttpGet]
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            //ViewBag.Error = error;
            return View(db.Tabla.ToList());
        }

        //GET/POST/post
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

        //POST/post
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FormCollection formAgregar)
        {
            Tabla tabla = new Tabla();
            string message; // para mostrar si los datos fueron guardados correctamente.
            bool error;

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
                    error = false;
                }
                else
                {
                    message = "No se pudo guardar los datos.";
                    error = true;
                }
            }
            catch (Exception ex)
            {
                message = "Exepcion generada. Detalles: " + ex.Message;
                error = true;
            }

            return RedirectToAction("Index", "GET", new { message });
        }

        //DELETE
        public ActionResult Borrar(int id)
        {
            Tabla tabla = new Tabla();
            string message;
            bool error;

            tabla = db.Tabla.FirstOrDefault(i => i.ID == id);
            if (tabla != null)
            {
                db.Tabla.Remove(tabla);
                db.SaveChanges();
                message = "Registro eliminado correctamente.";
                error = false;
            }
            else
            {
                message = "No existe el registro para eliminarlo.";
                error = true;
            }

            return RedirectToAction("Index", "GET", new { message });
        }

        public ActionResult Editar(int id)
        {
            if (id > 0)
            {
                Tabla tabla = new Tabla();
                tabla = db.Tabla.FirstOrDefault(i => i.ID == id);
                if (tabla != null)
                {
                    return View(tabla);
                }
                else
                {
                    return RedirectToAction("Index", "GET");
                }
            }
            else
            {
                return RedirectToAction("Index", "GET");
            }
        }

        [HttpPost]
        public ActionResult Editar(FormCollection formEditar)
        {
            //Falta terminar
            Tabla tb = new Tabla();
            tb.ID = Convert.ToInt32(formEditar["ID"]);
            return RedirectToAction("Index", "GET");
        }
    }
}
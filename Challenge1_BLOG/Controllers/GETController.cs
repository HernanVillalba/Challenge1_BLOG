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
            //valido que el id sea entero y positivo.
            if (id > 0)
            {
                Tabla tabla = new Tabla();
                //busco el id para encontrar el registro que quiero editar.
                tabla = db.Tabla.FirstOrDefault(i => i.ID == id); 
                if (tabla != null)
                {
                    //Si lo encuentra, cargo los datos en view.
                    return View(tabla);
                }
                else
                {
                    //no encontró el registro, por lo tanto redirecciono.
                    return RedirectToAction("Index", "GET");
                }
            }
            else
            {
                //si no es entero ni positivo, redireciono a index.
                return RedirectToAction("Index", "GET");
            }
        }

        [HttpPost]
        public ActionResult Editar(FormCollection formEditar)
        {
            //Falta terminar (NO FUNCIONAL)
            //COMO ENCUENTRO EL REGISTRO EN LA DB Y LO ACTUALIZO SIN NECESIDAD DE BORRARLO????
            Tabla tb = new Tabla();
            string message;

            tb.Titulo = formEditar["Titulo"];
            tb.Contenido = formEditar["Contenido"];
            tb.Imagen = formEditar["Imagen"];
            tb.Categoria = formEditar["Categoria"];
            tb.Fecha_Creacion = Convert.ToDateTime(formEditar["Fecha_Creacion"]);

            if (tb != null)
            {
                db.Tabla.Attach(tb);
                db.SaveChanges();
                message = "Post actualizado correctamente.";
            }
            else
            {
                message = "No se pudo actualizar el post";
            }

            tb.ID = Convert.ToInt32(formEditar["ID"]);
            tb.Titulo = formEditar["Titulo"];
            return RedirectToAction("Index", "GET", new { message });

        }
    }
}
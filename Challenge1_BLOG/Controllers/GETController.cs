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
            return View(db.Tabla.ToList());
        }

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


    }
}
using BaseDeDatosUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseDeDatosUpdate.Controllers
{
    public class HomeController : Controller
    {
        private EjemploASPNETEntities db = new EjemploASPNETEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult EjemploUpdate()
        {//La vista general donde se muestra la lista de productos
            ViewBag.productos = db.Producto.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)//La vista para editar un registro mediante su id(formulario)
        {
            Producto producto = db.Producto.Find(id);//Busca el registro que tiene el id enviado
            return View("Editar", producto);//Enviamos un objeto a la vista
        }
        [HttpPost]
        public ActionResult Editar(Producto prod)
        {
            db.Entry(prod).State = System.Data.Entity.EntityState.Modified;//Cambiamos el estado del objeto a "modificado" para que SQL Server sepa cómo tratarlo
            db.SaveChanges();//Acá actualiza la base de datos.
            return RedirectToAction("EjemploUpdate");
        }
    }
}
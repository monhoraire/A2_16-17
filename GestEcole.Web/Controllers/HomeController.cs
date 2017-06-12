using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestEcole.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            
            string path = Server.MapPath("~/App_Data");

            ViewBag.Identifiant = id;
            ViewData["identifiant"] = id;

            var list = new List<string>();
            list.Add("Toto");
            list.Add("Titi");
            list.Add("Tata");
            list.Add("Tutu");

            // Retour de la vue avec le modèle
            return View(list);
        }



        /// <summary>
        /// Affiche l'ensemble des paramètres
        /// </summary>
        /// <param name="param">tableau de paramètres</param>
        /// <returns></returns>
        //public ActionResult ManyParams(string param)
        //{
        //    return View();
        //}
    }
}
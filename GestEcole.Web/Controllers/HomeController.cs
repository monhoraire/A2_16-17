using GestEcole.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            //var list = new List<string>();
            //list.Add("Toto");
            //list.Add("Titi");
            //list.Add("Tata");
            //list.Add("Tutu");

            // Retour de la vue avec le modèle
            return View(new LoginViewModel());
        }

        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // 1. Recherche de l'utilisateur dans la bdd

                // 2. Création du cookie d'authentification
                FormsAuthentication.SetAuthCookie(vm.Username, true);
                
            }

            return Redirect("~/");
            //return View("Index", vm);
        }

        /// <summary>
        /// Action de de déconnexion du site web
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
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
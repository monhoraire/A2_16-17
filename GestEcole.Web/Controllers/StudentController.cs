﻿using GestEcole.Web.Models.Student;
using GestEcole.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestEcole.Web.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private static readonly StudentService studentService = new StudentService();

        /// <summary>
        /// Affiche la vue par défaut
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var students = studentService.GetAll();

            return View(students);
        }

        ///<summary>
        /// Affiche la vue d'ajout d'un nouvel étudiant
        /// </summary>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Créé en base de données l'étudiant
        /// </summary>
        /// <param name="studentName">Nom de famille de l'étudiant</param>
        /// <param name="studentFirstName">Prénom de l'étudiant</param>
        /// <param name="studentBirthDate">Date de naissance de l'étudiant</param>
        /// <returns>Redirection vers la page Index</returns>
        [HttpPost]
        //public ActionResult Create(string studentName, string studentFirstName, string studentBirthDate)
        public ActionResult Create(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", viewModel);
            }
            else {
                studentService.Save(viewModel);

                // Ajout de l'étudiant à la session en cours
                //Students.Add(viewModel);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Action de suppression
        /// </summary>
        /// <param name="id">Identifiant de l'étudiant à supprimer</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var student = studentService.GetById(id);

            if (student == null)
                ViewBag.Error = $"Aucun étudiant ne correspond à l'id {id}";

            if (student != null)
            {
                studentService.Delete(id);
                ViewBag.Success = "L'étudiant a été supprimé avec succès";
            }

            return View("Index", studentService.GetAll());
        }
    }
}
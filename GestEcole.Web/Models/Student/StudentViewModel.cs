using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.Student
{
    public class StudentViewModel : IComparable<StudentViewModel>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant de l'étudiant
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom de famille du nouvel étudiant
        /// </summary>
        [Display(Name = "Nom de famille :")]
        [Required(ErrorMessage = "Le nom de l'étudiant est obligatoire")]
        [StringLength(30, ErrorMessage = "La longueur du nom de l'étudiant doit-être de 30 caractères au maximum")]
        public string StudentName { get; set; }
        /// <summary>
        /// Affecte ou obtient le prénom du nouvel étudiant
        /// </summary>
        [Display(Name = "Prénom :")]
        [StringLength(30, ErrorMessage = "La longueur du prénom de l'étudiant doit-être de 30 caractères au maximum")]
        public string StudentFirstName { get; set; }
        /// <summary>
        /// Affecte ou obtient la date de naissance de l'étudiant
        /// </summary>
        public DateTime StudentBirthDate { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Redéfinition du HashCode selon l'id de l'étudiant 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Méthode qui défini la comparaison entre 2 objets selon le HashCode de l'objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Méthode qui défini la comparaison entre 2 objets selon le HashCode de l'objet
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(StudentViewModel other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        #endregion
    }
}

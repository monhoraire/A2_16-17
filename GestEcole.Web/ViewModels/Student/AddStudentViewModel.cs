using GestEcole.Web.Models.School;
using GestEcole.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.ViewModels.Student
{
    public class AddStudentViewModel
    {
        #region Properties

        public List<SchoolViewModel> Schools { get; set; } = new List<SchoolViewModel>();

        public StudentViewModel Student { get; set; }

        #endregion

        #region Constructeurs
        public AddStudentViewModel()
        {
            Schools.Add(new SchoolViewModel() { Id = 1, Name = "IIA" });
            Schools.Add(new SchoolViewModel() { Id = 2, Name = "XXX" });

            Student = new StudentViewModel();
        }
        #endregion
    }
}

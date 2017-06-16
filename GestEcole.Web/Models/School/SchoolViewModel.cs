using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.School
{
    public class SchoolViewModel
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant de l'école
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de l'école
        /// </summary>
        public string Name { get; set; }
        #endregion
    }
}

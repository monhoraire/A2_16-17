using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Models.Home
{
    public class LoginViewModel
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient le nom d'utilisateur
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        public string Password { get; set; }
        #endregion
    }
}

using GestEcole.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Net.Http.Formatting;

namespace GestEcole.Web
{
    class WebApiRoleProvider : RoleProvider
    {
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

        }

        public override void CreateRole(string roleName)
        {

        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return null;
        }

        public override string[] GetAllRoles()
        {
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(ConfigurationManager.AppSettings["GestEcole:ApiBaseUrl"]) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/Groupes").Result;
                if(response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<IEnumerable<Groupe>>().Result;
                    return result.Select(group => group.Libelle).ToArray();
                }
            }

            return null;
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}

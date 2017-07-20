using Db201617zVaProektRnabContext;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Bazi_Web
{
    public class CustomPrincipal : CustomePrincipalSerializeModel, IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Roles != null) {
                if (Roles.Any(r => role.Contains(r)))
                    return true;
                else return false;
            } else return false;
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }
    }

    public class CustomePrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public IList<string> Roles { get; set; }

        public CustomePrincipalSerializeModel() {
            Roles = new List<string>();
        }

        public CustomePrincipalSerializeModel(Akaunti account)
        {
            this.UserId = account.AkauntId;
            this.UserName = account.KorisnichkoIme;
            this.EmailAddress = account.EmailAdresa;
            string roleName = account.Ulogi_UlogaId.UlogaIme;
            Roles = new List<string>();
            Roles.Add(roleName);
        }
    }
}

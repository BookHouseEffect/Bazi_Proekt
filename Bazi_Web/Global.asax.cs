using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;

namespace Bazi_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    CustomePrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomePrincipalSerializeModel>(authTicket.UserData);
                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.UserId = serializeModel.UserId;
                    newUser.UserName = serializeModel.UserName;
                    newUser.EmailAddress = serializeModel.EmailAddress;
                    newUser.Roles = serializeModel.Roles;

                    HttpContext.Current.User = newUser;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

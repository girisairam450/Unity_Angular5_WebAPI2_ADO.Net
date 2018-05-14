using Owin;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;

namespace API_Services.App_Start
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(

                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = ConfigurationManager.AppSettings["Tenant"],
                    TokenValidationParameters = new TokenValidationParameters { SaveSigninToken = true, ValidAudience = ConfigurationManager.AppSettings["AudienceUri"] }
                });
        }
    }
}
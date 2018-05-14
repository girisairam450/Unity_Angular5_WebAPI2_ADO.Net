using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

[assembly: OwinStartup(typeof(Unity_Angular5_WebAPI2_ADO.Web.Web_Angular.App_Start.Startup))]
namespace Unity_WebAPI2_ADO.App_Start
{
    public class Startup
    {
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        string clientId = ConfigurationManager.AppSettings["ClientId"];

        // RedirectUri is the URL where the user will be redirected to after they sign in.
        static string redirectUri = ConfigurationManager.AppSettings["RedirectUri"];

        // Tenant is the tenant ID (e.g. contoso.onmicrosoft.com, or 'common' for multi-tenant)
        // static string tenant = "36da45f1-dd2c-4d1f-af13-5abe46b99921";

        // Authority is the URL for authority, composed by Azure Active Directory v2 endpoint and the tenant name (e.g. https://login.microsoftonline.com/contoso.onmicrosoft.com/v2.0)
        //string authority = String.Format(System.Globalization.CultureInfo.InvariantCulture, "https://login.windows.net/common/oauth2/authorize", tenant);

        private static string aadInstance = ConfigurationManager.AppSettings["AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["Tenant"];
        private static string postLogoutRedirectUri = redirectUri;
        string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
        private bool productionMode = Convert.ToBoolean(ConfigurationManager.AppSettings["ProductionMode"]);

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            Configure(app);
        }
        private void Configure(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    // Sets the ClientId, authority, RedirectUri as obtained from web.config
                    ClientId = clientId,
                    Authority = authority,
                    RedirectUri = redirectUri,

                    // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
                    PostLogoutRedirectUri = postLogoutRedirectUri,

                    //Scope is the requested scope: OpenIdConnectScopes.OpenIdProfileis equivalent to the string 'openid profile': in the consent screen, this will result in 'Sign you in and read your profile'
                    Scope = OpenIdConnectScope.OpenIdProfile,

                    // ResponseType is set to request the id_token - which contains basic information about the signed-in user
                    ResponseType = OpenIdConnectResponseType.IdToken,

                    // ValidateIssuer set to false to allow work accounts from any organization to sign in to your application
                    // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name or Id (example: contoso.onmicrosoft.com)
                    // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
                    TokenValidationParameters = new TokenValidationParameters() { ValidateIssuer = false },

                    // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed,
                        SecurityTokenValidated = notification =>
                        {
                            notification.AuthenticationTicket.Properties.RedirectUri = RewriteToPublicOrigin(notification.AuthenticationTicket.Properties.RedirectUri);
                            return Task.FromResult(0);
                        }
                    }
                });
        }
        /// <summary>
        /// Handle failed authentication requests by redirecting the user to the home page with an error in the query string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }


        private static string RewriteToPublicOrigin(string originalUrl)
        {
            var publicOrigin = redirectUri;
            if (!string.IsNullOrEmpty(publicOrigin))
            {
                var uriBuilder = new UriBuilder(originalUrl);
                var publicOriginUri = new Uri(publicOrigin);
                uriBuilder.Host = publicOriginUri.Host;
                uriBuilder.Scheme = publicOriginUri.Scheme;
                uriBuilder.Port = publicOriginUri.Port;
                var newUrl = uriBuilder.Uri.AbsoluteUri;

                return newUrl;
            }

            return originalUrl;
        }

    }
}
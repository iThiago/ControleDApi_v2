using ControleDApi.DAL;
using ControleDApi.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ControleDApi.App_Start
{
    public class ControleDAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<AppUserManager>();

            var usuario = await userManager.FindAsync(context.UserName, context.Password);
            if (usuario == null)
            {
                context.SetError("invalid_grant", "Usuario inválido");
                return;
            }

            ClaimsIdentity identity = await userManager.CreateIdentityAsync(usuario, context.Options.AuthenticationType);

            //usuario.Claims.ToList().ForEach(x =>
            //identity.AddClaim(new Claim(x.ClaimType, x.ClaimValue))
            //);
            
            //identity.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));

            var tichet = new AuthenticationTicket(identity, GetProperties(usuario,
                identity.Claims));
            
            context.Validated(tichet);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            var ctx = new Context();

            var user = ctx.Users.Where(x => x.UserName == context.Identity.Name).FirstOrDefault();

            context.AdditionalResponseParameters.Add("NomeUsuario", user.Nome);

            return Task.FromResult<object>(null);
        }
        private static AuthenticationProperties GetProperties(Usuario usuario, IEnumerable<Claim> claims)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add(new KeyValuePair<string, string>("claims", string.Join(",", claims)));
            return new AuthenticationProperties(data);
        }
    }
}
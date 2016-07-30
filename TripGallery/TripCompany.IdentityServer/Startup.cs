using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;
using TripCompany.IdentityServer.Config;

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", builder =>
            {
                // configure the security token service (IdentityServer3)
                // so that it is aware of our own test users,
                // it registers supported clients
                // and registers the scopes that that the service authorises the user 

                var factory = new IdentityServerServiceFactory();

                factory.UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
                    .UseInMemoryUsers(Users.Get());

                var options = new IdentityServerOptions()
                {
                    Factory = factory,
                    SiteName = "Trip Company Secuirity Token Service",
                    IssuerUri = TripGallery.Constants.TripGalleryIssuerUri, // the identifier (doesnt have to exist) 
                    PublicOrigin = TripGallery.Constants.TripGallerySTSOrigin, // the origin of this server 
                    SigningCertificate = LoadCertificate(), // certificate used to sign
                };

                // have the security token service process the requests coming in from /identity
                builder.UseIdentityServer(options);
            });
        }

        /// <summary>
        /// Load a demo signing certificate
        /// </summary>
        /// <returns></returns>
        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2
                (
                fileName: $@"{AppDomain.CurrentDomain.BaseDirectory}\certificates\idsrv3test.pfx", 
                password: "idsrv3test"
                );
        }
    }
}
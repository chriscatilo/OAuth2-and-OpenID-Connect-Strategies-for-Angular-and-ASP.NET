using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    public static partial class Clients
    {
        /// <summary>
        /// Create an OAuth client for Trip Gallery
        /// </summary>
        private static Client CreateTripGalleryClientRegistrationByClientCredentials()
        {
            // define the client and from the application that requires an access token to access an API,
            // we defer to that client and trigger the authorisation flow (or grant)


            /* 
             * This OAuth client will use Client Credentials
             * Username and password is not passed.
             * Instead a client Id and Client secret is exchanged for an access token.
             * This method is suitable for Machine To Machine communication scenario
             * And should only be used between non-public, confidential clients
             * as a public client cannot safely store the client secret
             * 
             * 
             *  Client                  Authorisation Server
             *  ------                  --------------------
             *      client id & secret
             *      -------------------------->|
             *      
             *                      access token
             *      |<--------------------------
             */
            var grant = new
            {
                ClientId = "tripgalleryclientcredentials",
                ClientName = "Trip Gallery (Client Credentials)",
                Flow = Flows.ClientCredentials
            };

            return new Client
            {
                ClientId = grant.ClientId,
                ClientName = grant.ClientName,
                Flow = grant.Flow,

                ClientSecrets = new List<Secret>()
                {
                    new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                },

                // allow all scopes to the client
                AllowAccessToAllScopes = true,

                // Optionally, We could have specified a list a scopes allowed for this client
                // AllowedScopes = new List<string>() { "gallerymanagement" }
            };
        }

    }
}
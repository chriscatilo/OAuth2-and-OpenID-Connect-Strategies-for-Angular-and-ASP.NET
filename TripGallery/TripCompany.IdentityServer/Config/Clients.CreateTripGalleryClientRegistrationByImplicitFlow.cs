using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    public static partial class Clients
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Client CreateTripGalleryClientRegistrationByImplicitFlow()
        {

            // create an OAuth client
            return new Client()
            {
                AllowAccessToAllScopes = true,

                /*
                 * This OAuth client will use Implict Flow
                 * This flow is optimised for public clients (can be used by confidential clients as well)
                 * This flow does not use secrets as pubic clients can't store them securely
                 * Can be used to obtain access tokens (but no refresh tokens)
                 * 
                 * Resource   User Agent    Client    Authorization    Resource
                 *  Owner      (Browser)                 Server         Server
                 *  
                 *  
                 *                 |<---------|                                 1. Client redirects the UA to the Authorization endpoint of AS.
                 *                 |---------------------->|                       Redirection includes client ID, requested scope, and a
                 *                                                                 redirection Uri to which the AS will sends the UA back once access 
                 *                                                                 is granted or denied.
                 *     |<----------|                                            2. The AS authenticates the RO via the UA and establishes whether 
                 *                 |---------------------->|                       the RO grants or denies the client's access request. 
                 *                                                                 Assuming the RO grants access...
                 *                 |<----------------------|                    3. The AS redirects the UA back to the Client using the redirection Uri earlier.
                 *                 |--------->|                                    The redirection Uri includes the access token in the Uri fragment.
                 *                 |--------------------------------------->|   4. The UA then follows the redirection instructions by making a request the RS.
                 *                                                                 The UA retains the fragment information locally (including the access token).
                 *                 |<---------------------------------------|   5. RS returns a web page (typically an HTML document with embedded script) to full redirection Uri, 
                 *                                                                 including the fragment retained by the UA. It must also be capable of extracting
                 *                                                                 the access token contained in the fragement. So the UA typically executes a 
                 *                                                                 script on the page which extracts the access token.
                 *                 |--------->|                                 6. UA then passes the access token to the client.
                 */
                ClientId = "tripgalleryimplicit",
                ClientName = "Trip Gallery (Implicit)",
                Flow = Flows.Implicit,
                RedirectUris = new List<string>
                {
                    $"{TripGallery.Constants.TripGalleryAngular}callback.html" 
                }
            };
        }
    }
}
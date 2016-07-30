using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    /// <summary>
    /// Store of registered clients
    /// </summary>
    /// <remarks>
    /// Registrations are nested with this file
    /// </remarks>
    public static partial class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                CreateTripGalleryClientRegistrationByClientCredentials()
            };
        }
    }
}

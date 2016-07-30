using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    /// <summary>
    /// Store of registered clients
    /// </summary>
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        { 
            return new List<Client>(); 
        }
    }
}

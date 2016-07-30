using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    /// <summary>
    /// Store of supported scopes
    /// Scopes are the "intent" available to the supported client
    /// There are two types of scopes: Identity and Resource
    /// Resource scopes are appropriate to OAuth
    /// </summary>
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
                {                    
                    new Scope
                    { 
                        Name = "gallerymanagement",
                        DisplayName = "Gallery Management",
                        Description = "Allow the application to manage galleries on your behalf.",
                        Type = ScopeType.Resource 
                    }
                };
        }
    }
}

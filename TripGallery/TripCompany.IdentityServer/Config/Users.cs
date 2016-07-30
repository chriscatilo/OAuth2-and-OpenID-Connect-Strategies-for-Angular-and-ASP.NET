using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    /// <summary>
    /// Store of Users
    /// </summary>
    public static class Users
    {
        /// <summary>
        /// Returns a list of in memory test users 
        /// </summary>
        /// <returns></returns>
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>() {
                 
                new InMemoryUser
	            {
	                Username = "Kevin",
	                Password = "secret",                    
	                Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf" // unique identifier of the user
	             }
	            ,
	            new InMemoryUser
	            {
	                Username = "Sven",
	                Password = "secret",
	                Subject = "bb61e881-3a49-42a7-8b62-c13dbe102018"
	            }  
            };
        }
    }

}

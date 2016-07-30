using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TripGallery.MVCClient.Helpers
{
    public static class TripGalleryHttpClient
    {

        public static HttpClient GetClient()
        { 
            HttpClient client = new HttpClient();

            var accessToken = GetAccessTokenAuthorizationCode();

            client.SetBearerToken(accessToken);
           
            client.BaseAddress = new Uri(Constants.TripGalleryAPI);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


        /// <summary>
        /// Request the access token containing the gallerymanagement scope 
        /// from the /token endpoint of the identiry server
        /// passing down the client ID and client secret
        /// </summary>
        private static string RequestAccessTokenAuthorizationCode()
        {
            // create a token client
            var tokenClient = new TokenClient
                (
                address: TripGallery.Constants.TripGallerySTSTokenEndpoint,
                clientId: "tripgalleryclientcredentials",
                clientSecret: TripGallery.Constants.TripGalleryClientSecret
                );

            // ask for a token, containing the gallerymanagement scope
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("gallerymanagement").Result;

            // decode & write out the token so we can see what's in it
            TokenHelper.DecodeAndWrite(tokenResponse.AccessToken);


            return tokenResponse.AccessToken;
        }

        /// <summary>
        /// Put the access token to the cookie
        /// </summary>
        /// <returns></returns>
        private static string GetAccessTokenAuthorizationCode()
        {
            var accessToken = HttpContext.Current.Request.Cookies.Get("TripGalleryCookie")?["access_token"];

            if (accessToken != null) return accessToken;

            accessToken = RequestAccessTokenAuthorizationCode();

            HttpContext.Current.Response.Cookies["TripGalleryCookie"]["access_token"] = accessToken;

            return accessToken;
        }
    }
}
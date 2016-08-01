(function() {
    "use strict";

    /* 
        This angular service gets the bearer security token contained in the local storage.
        If the token is not local storage, then it redirects the User Agent to the Authorization Server and authenticates the Resource Owner. 
        On successful authentication, the Authorization Server redirects The User Agent to a callback page in order for it to save the token to local storage.
     */

    var getAccessToken = function () {
        debugger;

        // get and return access token from local storage
        var accessToken = localStorage.getItem("access_token");
        if (accessToken) {
            return accessToken;
        }

        // if access token for scope "galarymanagement" is NOT in local storage then 
        // 1) obtain it from the Authorization Server by authenticating the Resource Owner
        // 2) have the Authorization Server redirect the User Agent to the Client's callback page in order to store the token to the local storage
        window.location = "https://localhost:44317/identity/connect/authorize?" +
            "client_id=tripgalleryimplicit&" +
            "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
            "response_type=token&" +
            "scope=gallerymanagement";

        return null;
    }

    angular.module("common.services")
        .factory("tokenContainer", function() {
            return {
                getAccessToken: getAccessToken
            }
        });
})();
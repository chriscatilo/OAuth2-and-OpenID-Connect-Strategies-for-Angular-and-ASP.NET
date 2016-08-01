(function () {
    "use strict";

    debugger;
    angular
        .module("common.services")
        .factory("tripResource",
                ["$resource",
                 "appSettings",
                 "tokenContainer",
                 tripResource]);     

    function tripResource($resource, appSettings, tokenContainer) {
        return $resource(appSettings.tripGalleryAPI + "/api/trips/:tripId", null,
            {
                // when requesting the resource "trips" from the resource server
                'query' :
                {
                    isArray: true,
                    // ... pass down the authorization token
                    headers: { 'Authorization': 'Bearer ' + tokenContainer.getAccessToken() }
                },

                'patch':
                    {
                        method: 'PATCH',
                        transformRequest: createJsonPatchDocument
                    }
            });
    };

    var createJsonPatchDocument = function (data) {

        // create a JsonPatchDocument for the resource - the only
        // thing that can be updated in this specific case is the
        // isPublic boolean.    

        var dataToSend = "[{op: 'replace', path: '/isPublic', value: '" + !data["isPublic"] + "'}]";
        return dataToSend;
    }

}());


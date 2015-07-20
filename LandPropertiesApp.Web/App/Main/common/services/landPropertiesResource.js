(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("landPropertiesResource", ["$resource", landPropertiesResource]);

    function landPropertiesResource($resource) {        
        return $resource("/api/landProperties/:Id");
    }

})();
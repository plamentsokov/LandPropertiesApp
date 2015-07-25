(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("landPropertiesResource", ["$resource", landPropertiesResource]);

    function landPropertiesResource($resource, landPropertyService) {
        var self = this;

        function landPropertyService($resource) {
            return $resource("/api/services/landpropertyapp/:Id");
        }
    }

})();
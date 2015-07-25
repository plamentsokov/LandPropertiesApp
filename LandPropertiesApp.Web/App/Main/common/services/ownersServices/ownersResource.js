(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("ownersResource", ["$resource", ownersResource]);

    function ownersResource($resource) {
        return $resource("/api/owners/:Id");
    }

})();
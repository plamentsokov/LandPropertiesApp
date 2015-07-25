(function () {
    "use strict";

    angular
        .module('app')
        .controller("LandPropertiesCtrl", ['$scope', 'abp.services.landpropertyapp.landProperty', '$filter', 'ngTableParams', LandPropertiesCtrl]);

    function LandPropertiesCtrl($scope, landPropertyService, $filter, ngTableParams) {
        var vm = this;

        vm.properties = [];
        vm.refreshLandProperties = (function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                null,
                landPropertyService.getLandProperties()
                                .success(function (data) {
                                    vm.properties = data.landPropertiesList;
                                })

            );
        })();       
    }
})();
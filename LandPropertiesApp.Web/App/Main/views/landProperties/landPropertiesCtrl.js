(function () {
    "use strict";

    angular
        .module('app')
        .controller("LandPropertiesCtrl", ['$scope', "landPropertiesResource", LandPropertiesCtrl]);

    function LandPropertiesCtrl($scope, landPropertiesResource) {
        var vm = this;

        landPropertiesResource.query(function (data) {
            vm.properties = data;
        });        
    }
})();
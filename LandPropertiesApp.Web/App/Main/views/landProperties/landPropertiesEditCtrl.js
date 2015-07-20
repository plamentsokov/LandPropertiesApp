(function () {
    "use strict";

    angular
        .module('app')
        .controller("LandPropertiesEditCtrl", ["landProperty", "$state", LandPropertiesEditCtrl]);

    function LandPropertiesEditCtrl(landProperty, $state) {
        var vm = this;

        vm.landProperty = landProperty;

        vm.title = landProperty.Id ? "Edit land property N: " + landProperty.UPI : "New land property"

        vm.submit = function (savedProduct) {
            vm.landProperty.$save();
            $state.go('landPropertiesList');
        }
        vm.cancel = function (savedProduct) {
            $state.go('landPropertiesList');
        }
    }
})();
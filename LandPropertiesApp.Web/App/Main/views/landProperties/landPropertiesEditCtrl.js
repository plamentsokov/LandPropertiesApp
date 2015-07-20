(function () {
    "use strict";

    angular
        .module('app')
        .controller("LandPropertiesEditCtrl", ["landProperty", LandPropertiesEditCtrl]);

    function LandPropertiesEditCtrl(landProperty) {
        var vm = this;

        vm.landProperty = landProperty;
    }
})();
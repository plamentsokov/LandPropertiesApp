(function () {
    "use strict";

    angular
        .module('app')
        .controller("MortgageEditCtrl", ["mortgage",
                                                "$state",
                                                "abp.services.landpropertyapp.landProperty",
                                                "abp.services.landpropertyapp.mortgage",
                                                MortgageEditCtrl]);

    function MortgageEditCtrl(mortgage, $state, landPropertyService, mortgageService) {
        var vm = this;
        console.log(mortgage);
        vm.mortgage = mortgage;
        vm.mortgage.landProperty = mortgage.landProperty;
        vm.title = mortgage.id ? "Mortgage № " + mortgage.mortgageIdentifier : "New Mortgage №";

        vm.submit = function () {
            abp.ui.setBusy(
                null,
                mortgageService.addOrUpdate({ MortgageToUpdate: vm.mortgage }).success(function (data) {
                    $state.go('mortgageList');
                })
            );
        }
        vm.cancel = function () { $state.go('mortgageList'); }

        //Datetime picker event
        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        //patterns
        vm.onlyNumbers = /^\d+$/;
    }
})();
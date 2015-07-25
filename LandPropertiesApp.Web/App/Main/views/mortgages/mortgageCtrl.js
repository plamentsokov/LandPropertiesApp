(function () {
    "use strict";

    angular
        .module('app')
        .controller("MortgageCtrl", ['$scope', "abp.services.landpropertyapp.mortgage", MortgageCtrl]);

    function MortgageCtrl($scope, mortgageService) {
        var vm = this;
        vm.mortgages = [];

        vm.refreshMortgages = (function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                null,
                mortgageService.all()
                            .success(function (data) {
                                vm.mortgages = data.mortgages;
                            })
            );
        })();
    }
})();
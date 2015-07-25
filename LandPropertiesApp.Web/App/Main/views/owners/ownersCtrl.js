(function () {
    "use strict";

    angular
        .module('app')
        .controller("OwnersCtrl", ['$scope', "abp.services.landpropertyapp.owner", OwnersCtrl]);

    function OwnersCtrl($scope, ownersService) {
        var vm = this;
        vm.owners = [];

        vm.refreshOwners = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                null,
                ownersService.getOwners()
                            .success(function (data) {
                                vm.owners = data.owners;
                            })
            );
        };

        vm.refreshOwners();
    }
})();
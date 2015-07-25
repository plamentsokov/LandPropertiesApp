(function () {
    "use strict";

    angular
        .module('app')
        .controller("OwnersEditCtrl", ["owner", "$state", OwnersEditCtrl]);

    function OwnersEditCtrl(owner, $state) {
        var vm = this;

        vm.owner = owner;

        vm.title = owner.Id ? "Edit owner " + owner.FirstName + " " + owner.LastName : "New owner"

        vm.submit = function () {
            vm.owner.$save();
            $state.go('ownersList');
        }
        vm.cancel = function () {
            $state.go('ownersList');
        }
    }
})();
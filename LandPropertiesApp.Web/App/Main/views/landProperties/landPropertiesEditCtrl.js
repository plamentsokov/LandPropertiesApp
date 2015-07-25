(function () {
    "use strict";

    angular
        .module('app')
        .controller("LandPropertiesEditCtrl", ["landProperty",
                                                "$state",
                                                "abp.services.landpropertyapp.landProperty",
                                                "abp.services.landpropertyapp.owner",
                                                '$scope','$http','$timeout','$upload',
                                                LandPropertiesEditCtrl]);

    function LandPropertiesEditCtrl(landProperty, $state, landPropertyService, ownersService, $scope, $http, $timeout, $upload) {
        var vm = this;
        console.log(landProperty);
        vm.landProperty = landProperty;
        vm.landProperty.owners = landProperty.owners ? landProperty.owners : [];
        vm.landProperty.mortgage = landProperty.mortgage ? landProperty.mortgage : "";
        vm.title = landProperty.id ? "Land property № " + landProperty.upi : "New Land property";

        vm.submit = function () {
            abp.ui.setBusy(
                null,
                landPropertyService.addOrUpdate({ LandPropToUpdate: vm.landProperty }).success(function (data) {
                    $state.go('landPropertiesList');
                })
            );
        }
        vm.cancel = function () { $state.go('landPropertiesList'); }

        vm.selectedOwner = "";
        vm.Owners = [];
        vm.addOwner = function () {
            vm.landProperty.owners.push(vm.selectedOwner);
            console.log(vm.landProperty);
            vm.selectedOwner = "";
        }

        //Load all owners
        vm.refreshOwners = (function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                null,
                ownersService.getOwners()
                            .success(function (data) {
                                vm.Owners = data.owners;
                            })
            );
        })();

        //Datetime picker event
        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        $scope.upload = [];
        $scope.onFileSelect = function ($files) {
            var $file = $files[0];
            $upload.upload({
                url: "/api/files/upload", // webapi url
                method: "POST",
                data: { fileUploadObj: $file },
                file: $file
            }).progress(function (evt) {
                // get upload percentage
                //console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
            }).success(function (data, status, headers, config) {
                vm.landProperty.imageUrl = data.fileName;
            }).error(function (data, status, headers, config) {
                // file failed to upload
                alert("Cant upload this file");
            });
        }

        //patterns
        vm.onlyNumbers = /^\d+$/;
    }
})();
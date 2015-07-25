(function () {
    "use strict";

    angular
        .module('app')
        .controller("OwnersEditCtrl", ["owner",
                                        "$state",
                                        "abp.services.landpropertyapp.landProperty",
                                        "abp.services.landpropertyapp.owner",
                                        '$scope', '$http', '$upload',
                                        OwnersEditCtrl]);

    function OwnersEditCtrl(owner, $state, landPropertyService, ownersService, $scope, $http, $upload) {
        var vm = this;
        console.log(owner);
        vm.owner = owner;
        vm.owner.landProperties = owner.landProperties;
        vm.title = owner.id ? owner.fullName : "New owner";

        vm.submit = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
              null,
              ownersService.addOrUpdate({ OwnerToUpdate: vm.owner }).success(function (data) {
                  $state.go('ownersList');
              })
          );
        }
        vm.cancel = function () {
            $state.go('ownersList');
        }

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
                vm.owner.imageUrl = data.fileName;
            }).error(function (data, status, headers, config) {
                // file failed to upload
                alert("Cant upload this file");
            });
        }

        vm.selectedProperty = "";
        vm.LandProperties = [];
        vm.addProperty = function () {
            vm.owner.landProperties.push(vm.selectedProperty);
            console.log(vm.owner);
            vm.selectedProperty = "";
        }

        //Load all owners
        vm.refreshProperties = (function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                null,
                landPropertyService.getLandProperties()
                            .success(function (data) {
                                vm.LandProperties = data.landPropertiesList;
                                console.log(data);
                            })
            );
        })();

        //patterns
        vm.onlyNumbers = /^\d+$/;
    }
})();
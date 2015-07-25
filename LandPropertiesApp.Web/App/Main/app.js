(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngTable',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp',
        'akFileUploader',
        'angularFileUpload'
    ]);    

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/about');
            $stateProvider
                .state('landPropertiesList', {
                    url: '/',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesView.cshtml',
                    controller: 'LandPropertiesCtrl as vm'
                })
                .state('landPropertiesEdit', {
                    abstract: true,
                    url: '/landProperties/edit/:Id',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesEditView.cshtml',
                    controller: 'LandPropertiesEditCtrl as vm',
                    resolve: {
                        landPropertyService: 'abp.services.landpropertyapp.landProperty',
                        q:'$q',
                        landProperty: function ($stateParams, landPropertyService, $q) {
                            var id = $stateParams.Id;
                            var deferred = $q.defer();
                            abp.ui.setBusy(null,
                                           landPropertyService.getLandProperty({ landPropertyId: id }).success(function (data) {   
                                               deferred.resolve(data.singleLandProperty);
                                           })  
                                       );               

                            return deferred.promise;
                        }
                    }
                })
                .state('landPropertiesEdit.info', {
                    url: '/info',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesEditInfoView.cshtml'
                })
                .state('landPropertiesEdit.owners', {
                    url: '/owners',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesEditOwnersView.cshtml'
                })
                .state('landPropertiesEdit.mortgage', {
                    url: '/mortgage',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesEditMortgage.cshtml'
                })
                .state('ownersList', {
                    url: '/owners',
                    templateUrl: '/App/Main/views/owners/ownersView.cshtml',
                    controller: 'OwnersCtrl as vm'
                })
                .state('ownersEdit', {
                    url: '/owners/edit/:Id',
                    templateUrl: '/App/Main/views/owners/ownersEditView.cshtml',
                    controller: 'OwnersEditCtrl as vm',
                    resolve: {
                        ownerService: 'abp.services.landpropertyapp.owner',
                        q: '$q',
                        owner: function ($stateParams, ownerService, $q) {
                            var id = $stateParams.Id;
                            var deferred = $q.defer();
                            abp.ui.setBusy(null,
                                           ownerService.getOwner({ OwnerId: id }).success(function (data) {
                                               deferred.resolve(data.singleOwner);
                                           })
                                       );

                            return deferred.promise;
                        }
                    }
                })
                 .state('ownersEdit.info', {
                     url: '/info',
                     templateUrl: '/App/Main/views/owners/ownerEditInfoView.cshtml'
                 })
                .state('ownersEdit.properties', {
                    url: '/properties',
                    templateUrl: '/App/Main/views/owners/ownerEditPropertiesView.cshtml'
                })
                .state('mortgageList', {
                    url: '/mortgages',
                    templateUrl: '/App/Main/views/mortgages/mortgageView.cshtml',
                    controller: 'MortgageCtrl as vm'
                })
                 .state('mortgageEdit', {
                     url: '/mortgages/edit/:Id',
                     templateUrl: '/App/Main/views/mortgages/mortgageEditView.cshtml',
                     controller: 'MortgageEditCtrl as vm',
                     resolve: {
                         mortgageService: 'abp.services.landpropertyapp.mortgage',
                         q: '$q',
                         mortgage: function ($stateParams, mortgageService, $q) {
                             var id = $stateParams.Id;
                             var deferred = $q.defer();
                             abp.ui.setBusy(null,
                                            mortgageService.get({ MortgageId: id }).success(function (data) {
                                                deferred.resolve(data.singleMortgage);
                                            })
                                        );

                             return deferred.promise;
                         }
                     }
                 })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml'
                });
        }
    ]);
})();
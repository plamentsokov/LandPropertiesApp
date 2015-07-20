(function () {
    'use strict';

    var app = angular.module('app', [
        'common.services',       

        'ngAnimate',
        'ngSanitize',
        
        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp',
        'landPropertiesMock'
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
                    url: '/landProperties/edit/:Id',
                    templateUrl: '/App/Main/views/landProperties/landPropertiesEditView.cshtml',
                    controller: 'LandPropertiesEditCtrl as vm',
                    resolve: {
                        landPropertiesResource: "landPropertiesResource",
                        landProperty: function (landPropertiesResource, $stateParams) {
                            var Id = $stateParams.Id;
                            return landPropertiesResource.get({ Id: Id }).$promise;
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
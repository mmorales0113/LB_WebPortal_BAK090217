//erpApp.js

'use_strict';
//Getting the existing module

angular.module('testclaimsApp', ['ui.router','ngMask'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('testclaims', {
                url: '/',
                templateUrl: '/app/claims/lb/testclaims.tmpl.html',
                controller: 'TestClaimsController',
                controllerAs: 'vm',
            })
    });
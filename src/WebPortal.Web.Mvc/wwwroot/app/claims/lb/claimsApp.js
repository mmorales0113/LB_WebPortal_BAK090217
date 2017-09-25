//erpApp.js

'use_strict';
//Getting the existing module

angular.module('claimsApp', ['ui.router','ngMask'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('claims', {
                url: '/',
                templateUrl: '/app/claims/lb/claims.tmpl.html',
                controller: 'ClaimsController',
                controllerAs: 'vm',
            })
    });
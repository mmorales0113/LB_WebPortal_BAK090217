//erpApp.js

'use_strict';
//Getting the existing module

angular.module('eligibilityApp', ['ui.router','ngMask'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('eligibility', {
                url: '/',
                templateUrl: '/app/eligibility/lb/eligibility.tmpl.html',
                controller: 'EligibilityController',
                controllerAs: 'vm',
            })
    });
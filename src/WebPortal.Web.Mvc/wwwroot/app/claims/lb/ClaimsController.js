// eligibilityController.js

'use strict';

angular.module('claimsApp').controller('ClaimsController', function ClaimsController($http) {

    var vm = this;

    vm.result = [];
    vm.notFound = false;
    vm.isMedical = false;
    vm.isVision = false;
    vm.elig = [];

    vm.getClaim = function () {
        vm.notFound = false;
        vm.isMedical = false;
        vm.isVision = false;
        vm.isBusy = true;
        vm.errorMessage = "";
        vm.nRanNum = Math.random();
        vm.taxid = $('#HeaderCurrentUserName').data('tax-id');

        if ( !isNaN(vm.claim.identifier) && angular.isNumber(+vm.claim.identifier)) {
            var config = {
                params: {
                    ssn: vm.claim.identifier,
                    dob: vm.claim.dob.replace('/', '').replace('/', ''),
                    service_type: vm.claim.coverageType,
                    bill_amount: vm.claim.billed,
                    from_dos: vm.claim.dos.replace('/', '').replace('/', ''),
                    to_dos: vm.claim.todos.replace('/', '').replace('/', ''),
                    selector: 2,
                    first_name: vm.claim.name,
                    tin: vm.taxid,
                    call_id: vm.nRanNum
                }
            }
        }
        else {
            var config = {
                params: {
                    bcid: vm.claim.identifier,
                    dob: vm.claim.dob.replace('/', '').replace('/', ''),
                    service_type: vm.claim.coverageType,
                    bill_amount: vm.claim.billed,
                    from_dos: vm.claim.dos.replace('/', '').replace('/', ''),
                    to_dos: vm.claim.todos.replace('/', '').replace('/', ''),
                    first_name: vm.claim.name,
                    selector: 1,
                    tin: vm.taxid,
                    call_id:vm.nRanNum
                }
            }
        }

        $http.get("https://sccl.pswadmin.com/api/eligibility/claim", config)
            .then(function (response) {
                // Success
                console.log(response.data);
                if (response.data.failed == 1) {
                    vm.notFound = true;
                }
                else if (response.data.message == "Member Not Found")
                {
                    angular.copy(response.data, vm.result);

                    vm.isMedical = true;
                    vm.postLink = '.pdf';
                    vm.isEOB = false;

                }
                else
                {
                   angular.copy(response.data, vm.result);
                   
                   vm.isMedical = true;
                   vm.isEOB = true;
                   vm.postLink = '.pdf';
                }
            }, function (error) {
                // Failure
                vm.errorAccountMessage = "There was an error with the request: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    };
});

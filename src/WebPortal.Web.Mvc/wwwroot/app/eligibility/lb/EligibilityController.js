  // eligibilityController.js

'use strict';

angular.module('eligibilityApp').controller('EligibilityController', function EligibilityController($http) {
    var vm = this;

    vm.result = [];
    
   


    vm.elig = [];

    vm.getElig = function () {
        vm.notFound = false;
        vm.isMedical = false;
        vm.isVision = false;
        vm.isBusy = true;

        vm.isPrescription = false;
        vm.LBMEDEPOACT = false;
        vm.LBMEDEPORET = false;
        vm.LBMEDEPORETSD = false;
        vm.LBMEDPPOACT = false;
        vm.LBMEDPPORET = false;
        vm.LBMEDPPORETP1 = false;
        vm.LBMEDPPORETP2 = false;
        vm.LBDENPPO = false;

        vm.Description = false;

        vm.isEligible = false;

        vm.KSMED = false;
        vm.SIMNSAMED = false;
        vm.DELTDEN = false;
        vm.SIMNSADEN = false;
        vm.KSRX = false;
        vm.OPTRX = false;
        vm.SIMNSARX = false;
        vm.BlUEVS = false;
        vm.KSVS = false;
        vm.SIMNSAVS = false;
        vm.MEDEXL = false;

        vm.errorMessage = "";
        vm.nRanNum = Math.random();
        vm.taxid = $('#HeaderCurrentUserName').data('tax-id');

        if ( !isNaN(vm.elig.identifier) && angular.isNumber(+vm.elig.identifier)) {
            var config = {
                params: {
                    ssn: vm.elig.identifier,
                    dob: vm.elig.dob.replace('/', '').replace('/', ''),
                    service_type: vm.elig.coverageType,
                    selector: 2,
                    tin: vm.elig.taxid,
                    call_id: vm.nRanNum
                }
            }
        }
	else
	{
		var config = {
                params: {
                    bcid: vm.elig.identifier,
                    dob: vm.elig.dob.replace('/', '').replace('/', ''),
                    service_type: vm.elig.coverageType,
                    selector: 1,
                    tin: vm.elig.taxid,
                    call_id: vm.nRanNum
                }
            }
	}
        

        $http.get("https://sccl.pswadmin.com/api/eligibility/web", config)
            .then(function (response) {
                // Success
                console.log(response.data);
                if (response.data.failed == 1)
                {
                    vm.notFound = true;
                }
                else
                {
                    angular.copy(response.data, vm.result);
                    if(response.data.sbcName == "LB_MEDICAL_EPO_ACTIVE.docx")
                    {
                        vm.isMedical = true;
                        vm.isEligible = true;
                        vm.LBMEDEPOACT = true;
                        vm.today = new Date();
            

                    }
                    else if (response.data.sbcName == "LB_MEDICAL_EPO_RETIREE.docx")
                    {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDEPORET = true;
                        
                    }
                    else if (response.data.sbcName == "LB_MEDICAL_EPO_RETIREE_SD.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDEPORETSD = true;
                       
                    }
                    else if (response.data.sbcName == "LB_MEDICAL_PPO_ACTIVE.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDPPOACT = true;
                    }
                    else if (response.data.sbcName == "LB_MEDICAL_PPO_RETIREE.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDPPORET = true;
                    }
                    else if (response.data.sbcName == "LB_MEDICAL_PPO_RETIREE_PLAN1.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDPPORETP1 = true;
                    }
                    else if (response.data.sbcName == "LB_MEDICAL_PPO_RETIREE_PLAN2.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBMEDPPORETP2 = true;
                    }
                    else if (response.data.sbcName == "LB_DENTAL_PPO.docx") {
                        vm.isVision = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.LBDENPPO = true;
                    }
                    else if (response.data.sbcName == "Kaiser HMO Medical" || response.data.sbcName == "Delta Care HMO Dental" || response.data.sbcName == "SIMNSA HMO Dental " || response.data.sbcName == "SIMNSA HMO Medical" || response.data.sbcName == "Kaiser Prescription HMO " || response.data.sbcName == "SIMNSA HMO Prescription " || response.data.sbcName == "SIMNSA HMO Vision" || response.data.sbcName == "MediExcel HMO")
                    {
                        vm.isEligible = true;
                        vm.today = new Date();
                    }
                    else if (response.data.sbcName == "Kaiser HMO Vision")
                    {
                        vm.Description = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.KSVS = true;
                    }
                    else if (response.data.sbcName == "Blue View Vision ") {
                        vm.Description = true;
                        vm.isEligible = true;
                        vm.BlUEVS = true;
                        vm.today = new Date();
          
                    }
                    else if (response.data.sbcName == "OptumRx")
                    {
                        vm.Description = true;
                        vm.isEligible = true;
                        vm.today = new Date();
                        vm.OPTRX = true;

                    }

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

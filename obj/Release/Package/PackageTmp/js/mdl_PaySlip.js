var app = angular.module('mdl_PaySlip', []);
app.controller('ctrl_payslip', function ($scope, $http) {
    $scope.GetPaySlip = function () {
        $http.post('PaySlip.aspx/GetPaySlipDetails', {})
        .success(function (data) {
            $scope.MEMBER_NAME = (data.d)[0].Member_Name;
            $scope.BRANCH = (data.d)[0].Branch_name;
        })
        .error(function (status) {

        });
    }
})
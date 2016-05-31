var app = angular.module('mdl_PaySlip', []);
app.controller('ctrl_payslip', function ($scope, $http) {
    $scope.GetPaySlip = function () {
        $http.post('PaySlip.aspx/GetPaySlipDetails', { month_val: $("#ddl_month").val() })
        .success(function (data) {
            var d = (data.d)[2];
            //$scope.CreateSlip(d);
            if (d.length == 0)
            {
                $("#RptPaper").hide();
                alert("No Payslip Avaliable for this period!");
                return false;
            }
            else
            {
                $("#RptPaper").show();



            }
            $scope.MEMBER_NAME = (data.d)[0].Member_Name;

            $("#td_mem_name").html((data.d)[0].Member_Name);
            $scope.BRANCH = (data.d)[0].Branch_name;
            $scope.DEPARTMENT = (data.d)[0].Department_name;
            $scope.TYPE = (data.d)[0].Employee_type;
            $scope.DESIGNATION = (data.d)[0].Designation;


            $scope.RATE = (data.d)[0].Dailypayrate;
            $scope.HRATE = (data.d)[0].Hourlyrate;
            $scope.MONTH = (data.d)[0].Member_Name;
            $scope.PAYDAY = (data.d)[0].Pay_day;
            $scope.PAYMODE = (data.d)[0].PaymentMode;
            $scope.ngEarning = (data.d)[2];
            $scope.ngdeduct = (data.d)[3];

            $scope.T_EARNING = (data.d)[0].Total_earning;
            $scope.T_DEDUCTION = (data.d)[0].Total_deduction;
            $scope.T_TOTAL = (data.d)[0].Net_pay;
            
        })
        .error(function (status) {

        });
    }
});
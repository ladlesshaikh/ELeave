var app = angular.module('AppLeave', []);
app.controller('Ctrl_AppLeave', function ($scope, $http) {
    $scope.BindTab = function (d) {
        var t = $("#tblLst").DataTable();
        t.clear();
        for (var i = 0; i < d.length; i++) {
            if (d[i].Is_Sanctioned == "1") {
                EditMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
            }
            else {
                EditMarkup = '<button type="button" id="btnSave_' + i + '" onclick="sanction(this)"  style="font-size: 13px;" class="button  UltraSleek">Save</button>';
            }

            var Status = '<select id="ddlStatus_'+i+'"><option value="5">--SELECT--</option><option value="1">APPROVE</option><option value="0">REJECT</option></select>';


            if (d[i].Is_Sanctioned == "2") {
                DelMarkup = '<button type="button" style="font-size: 13px;" class="button success UltraSleek">Delete</button>';              
            }
            else {
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Delete</button>';
            }

            t.row.add([

                   d[i].APP_DATE,
                   d[i].Leavecode,
                   d[i].MEM_CODE,
                   d[i].Member_Name,
                   d[i].LeaveName,
                   d[i].FROM_DATE,
                   d[i].TO_DATE,
                   d[i].TOT_DAY,
                   d[i].REASON,
                    Status,
                   d[i].ROW_ID,
                    EditMarkup,
                    DelMarkup,
                   d[i].SPECIAL_LEAVE,
                   d[i].HALF_DAY_LEAVE
            ]).draw(false);
        }
    }

    $scope.GetAllLeaveDetails = function () {
        $.blockUI();  
        $http.post('LeaveRequest.aspx/getAllLeaveDetails', {})
        .success(function (data) {
           
            $scope.BindTab(data.d);
            $.unblockUI();
        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }
    $scope.GetHistoryLeaveDetails = function () {
        $.blockUI();
        $http.post('LeaveRequest.aspx/getHistoryLeaveDetails', {})
        .success(function (data) {
            $scope.BindTabHistory(data.d);
            $.unblockUI();
        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }


    $scope.BindTabHistory = function (d) {
        var t = $("#tblHistory").DataTable();
        t.clear();
        for (var i = 0; i < d.length; i++) {
            if (d[i].Is_Sanctioned == "1") {
                var Status = '<img src="../images/accepted.png" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "3") {
                var Status = '<img src="../images/cancelled.png" style="height:20px;">';
            }
            else {
                var Status = '<img src="../images/rejected.png" style="height:20px;">';
            }


            t.row.add([
                   d[i].APP_DATE,
                   d[i].Member_Name,
                   d[i].LeaveName,
                   d[i].FROM_DATE,
                   d[i].TO_DATE,
                   d[i].TOT_DAY,
                   d[i].REASON,
                    Status,
            ]).draw(false);
        }
    }

    $scope.ChangeStatus = function (StatusId, rowId) {
        $http.post('LeaveRequest.aspx/UpdateLeaveStatus', { StatusId: StatusId, RowId: rowId })
        .success(function (data) {
            if(data.d==true)
            {
                $scope.GetAllLeaveDetails(); $scope.GetHistoryLeaveDetails();
            }
            else
            {
                alert("Error Occured!");
            }
        })
        .error(function (status) {
            alert("Error Occured!");
        })
    }
})
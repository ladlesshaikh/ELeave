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

            var Status = '<select id="ddlStatus_' + i + '"><option value="5">--SELECT--</option><option value="1">APPROVE</option><option value="0">REJECT</option></select>'; //<option value="3">TRANSFER</option>


            if (d[i].Is_Sanctioned == "2") {
                DelMarkup = '<button type="button" style="font-size: 13px;" class="button success UltraSleek">Delete</button>';              
            }
            else {
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Delete</button>';
            }

            var AttachMarkup = '<button type="button" style="font-size: 13px; padding:3px 3px; " id="btnAttachment_' + i + '" onclick="ShowAttachments(this)" class="button success UltraSleek">Attachments</button>'
            var Remarks = '';
            if (d[i].Is_Sanctioned == "3")
            {
                var mem_name = $("#ddlMemLst option[value='" + d[i].Edit_By + "']").text();
                Remarks = d[i].RO_REMARKS;
            }
            else
            {
                var mem_name = "";
                Remarks = d[i].RO_REMARKS;
            }

            if (d[i].HALF_DAY_LEAVE == "1")
            {
                var LType = d[i].LeaveName + " [HalfDay : <b>" + d[i].HALF_DAY_LEAVE_MODE + "</b>]";
            }
            else
            {
                var LType = d[i].LeaveName;
            }

            t.row.add([

                   d[i].APP_DATE,
                   d[i].Leavecode,
                   d[i].MEM_CODE,
                   d[i].Member_Name,
                   LType,
                   d[i].FROM_DATE,
                   d[i].TO_DATE,
                   d[i].TOT_DAY,
                   d[i].REASON,
                   mem_name,
                   Remarks,
                   AttachMarkup,
                    Status,
                   d[i].ROW_ID,
                    EditMarkup,
                    DelMarkup,
                   d[i].SPECIAL_LEAVE,
                   d[i].HALF_DAY_LEAVE
            ]).draw(false);
        }
    }

    $scope.loadDocDet = function (application_id) {
        $http.post('Leave/ApplyLeave.aspx/getDocDetails', { app_id: application_id })
        .success(function (data) {
            $("#upload_dialog").dialog("open");
            $scope.docdet = data.d;
        })
        .error(function () {
            alert("Error Occured!");
        });
    }

    $scope.GetAllLeaveDetails = function () {
        $.blockUI();  
        var memcode=$("#hdfMemCode").val();
        $http.post('LeaveRequest.aspx/getAllLeaveDetails', { memCode: memcode })
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
        var memcode = $("#hdfMemCode").val();
        $http.post('LeaveRequest.aspx/getHistoryLeaveDetails', { mem_code: memcode })
        .success(function (data) {
            $scope.BindTabHistory(data.d);
            $.unblockUI();
        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }
    $scope.CloseRejectwin = function () {
        $("#reject_leave_remarks").dialog("close");
    }

    $scope.BindTabHistory = function (d) {
        var t = $("#tblHistory").DataTable();
        t.clear();
        for (var i = 0; i < d.length; i++) {
            if (d[i].Is_Sanctioned == "1") {
                var Status = '<img src="../images/accepted.png" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "5") {
                var Status = '<img src="../images/cancelled.png" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "3") {
                var Status = '<img src="../../images/transferred.PNG" style="height:20px;">';
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

    $scope.SetROMemCode = function (seq) {
        $scope.ActiveRO = $scope.roList[seq].MemCode;
    }



    $scope.ChangeStatus = function (StatusId, rowId) {
        if (StatusId == 3)
        {
            //Transfer Request
            $("#transfer_dialog").dialog("open");
            var memCode = $("#hdfMemCode").val();
            $http.post('LeaveRequest.aspx/GetReportingOfficers', { memCode: memCode })
            .success(function (data) {
                $scope.roList = data.d;
            })
            .error(function (status) {
                alert("Error Occured!");
            })
            return false;
        }
        if (StatusId == 0)
        {
            $("#reject_leave_remarks").dialog("open");
            return false;
        }
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

    $scope.TransferLeaveRequest = function () {
        var AuthType = $("#ddlTransferAuth").val();
        var remarks = $("#txtTransferRemarks").val();
        var ActiveRO = $scope.ActiveRO;
        if (AuthType == 2)
        {
            ActiveRO = "ADMIN";
        }
        if (AuthType == 0 || remarks == "" || ActiveRO == "")
        {
            alert("Please fill all the required fields (Transferred to / Remarks)");
            return false;
        }
        var row_id = $("#hdfTransferRowId").val();
        var memCode=$("#hdfMemCode").val();
        $http.post('LeaveRequest.aspx/TransferRequest', { MemCode: memCode, AuthType: AuthType, remarks: remarks, row_id: row_id,activeRO:ActiveRO })
        .success(function (data, status) {
            if (data.d == false)
            {
                alert("No Reporting officers availiable!");
                return false;
            }
            $("#ddlTransferAuth").val(0);
            $("#txtTransferRemarks").val("");
            alert("Leave Request Transferred!");
            $("#transfer_dialog").dialog("close");
            $scope.GetAllLeaveDetails(); $scope.GetHistoryLeaveDetails();
            $scope.ActiveRO = "";
        })
        .error(function (status) {

        });
    }

    $scope.RejectLeave = function () {
        var reason = $("#txtRejectReason").val();
        if (reason == "") {
            alert("Please enter the reason for rejection!");
            return false;
        }
        var row_id = $("#hdfTransferRowId").val();
        $http.post('LeaveRequest.aspx/RejectLeave', { reason: reason, RowId: row_id })
        .success(function (data, status) {
            if(data.d==true)
            {
                alert("Leave Rejected!");
            }
            else
            {
                alert("Leave Rejection failed,please try again!");
            }
            $("#txtTransferRemarks").val("");
            $("#reject_leave_remarks").dialog("close");
            $scope.GetAllLeaveDetails(); $scope.GetHistoryLeaveDetails();
        })
        .error(function (status) {
            alert("Leave Rejection failed,please try again!");
        });
    }

})
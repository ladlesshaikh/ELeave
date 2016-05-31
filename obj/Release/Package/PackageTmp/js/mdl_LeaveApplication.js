var app = angular.module('AppLeave', []);
app.controller('Ctrl_AppLeave', function ($scope, $http) {
    $scope.FetchEmployeeDetails = function () {
      $http.post('ApplyLeave.aspx/getEmpLst', {})
      .success(function (data, status) {
          $scope.ngEmpLst = data.d;
          var d = data.d;
          for (var i = 0; i < d.length; i++) {
              $("#ddlEmloyee").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
          }
          var $select1 = $('#ddlEmloyee');
          $select1.selectator({
              labels: {
                  search: 'Search here...'
              }
          });
      })
      .error(function (status) {
          alert(status);
      });
    }
    $scope.BindTab = function (d) {
        var t = $("#tblLst").DataTable();
        t.clear();
        for(var i=0;i<d.length;i++)
        {
            if (d[i].Is_Sanctioned == "2") {
                EditMarkup = '<button type="button" id="btnEdit_' + i + '"  onclick=EditDialog(this) style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
                var Status = '<img src="../../images/submitted.png" style="height:20px;">';
            }
            else {
                if (d[i].Is_Sanctioned == "1") {
                    var Status = '<img src="../../images/accepted.png" style="height:20px;">';
                }
                else if (d[i].Is_Sanctioned == "3") {
                    var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
                }
                else
                {
                    var Status = '<img src="../../images/rejected.png" style="height:20px;">';
                }
                EditMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
            }
            if (d[i].Is_Sanctioned == "2") {
                DelMarkup = '<button  id="btnDel_' + i + '" type="button" style="font-size: 13px;" class="button danger UltraSleek" onclick="CancelDialog(this)">Cancel</button>';
                var Status = '<img src="../../images/submitted.png" style="height:20px;">';
            }
            else {
                if (d[i].Is_Sanctioned == "1") {
                    var Status = '<img src="../../images/accepted.png" style="height:20px;">';
                }
                else if (d[i].Is_Sanctioned == "3") {
                    var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
                }
                else {
                    var Status = '<img src="../../images/rejected.png" style="height:20px;">';
                }
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button UltraSleek">Cancel</button>';
            }

            t.row.add([
                   
                   d[i].APP_DATE,
                   d[i].Leavecode,
                   $("#ddlLeaveType option[value="+d[i].Leavecode+"]").text(),
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
        $http.post('ApplyLeave.aspx/getLeaveDetails', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
            $scope.BindTab(data.d);
            $.unblockUI();
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }

    $scope.GetLeaveHistory = function () {
        $http.post('ApplyLeave.aspx/getLeaveHistory', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
            $scope.LeaveHist = data.d;
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }
    $scope.GetLeaveHistoryDetails = function () {
        $http.post('ApplyLeave.aspx/getLeaveHistoryDetails', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }

    $scope.SaveLeave = function () {
        //string strRowId, string strMemberCode, int iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays,
        //bool isSpecialLeave, bool isIsHalfDay, int iTotalDays, string strReason, string strFlag
        $.blockUI();
        var strMemberCode = $('#ddlEmloyee').val();
        var iLeaveType = $("#ddlLeaveType").val();
        var dtAppDate = $("#AppliedDate").val();
        var dtFrom = $("#FromDate").val();
        var dtTo = $("#ToDate").val();
        var fTotalDays = $("#tdTotalLeaves").html();
         
        if (dtFrom == "" || dtTo == "")
        {
            alert("Select Start Date and end date!");
            return false;
        }


        if($("#chkSpecialLeave").prop('checked')==true)
        {
            var isSpecialLeave = 1;
        }
        else
        {
            var isSpecialLeave = 0;
        }
        if ($("#chkHalfDayLeave").prop('checked') == true) {
            var isIsHalfDay = 1;
        }
        else {
            var isIsHalfDay = 0;
        }


        var iTotalDays = 0;
        var strReason = $("#txtReason").val();
        if ($("#hdfRowId").val() != "")
        {
            var strRowId = $("#hdfRowId").val();
            var strFlag = 'E';
        }
        else
        {
            var strFlag = 'A';
            var strRowId = null;
        }  
        var isIsHalfDay = 1;
        $("#dialog").dialog("close");
        $http.post('ApplyLeave.aspx/SaveLeaveApp', { strRowId: strRowId, strMemberCode: strMemberCode, iLeaveType: iLeaveType, dtAppDate: dtAppDate, dtFrom: dtFrom, dtTo: dtTo, fTotalDays: fTotalDays, isSpecialLeave: isSpecialLeave, isIsHalfDay: isIsHalfDay, iTotalDays: iTotalDays, strReason: strReason, strFlag: strFlag })
        .success(function (data) {
            $.unblockUI();
            if(data.d==0)
            {
                if (strFlag == 'A')
                {

                    alert("Leave Application Submitted!");
                }
                else
                {
                    alert("Leave Application Updated!");
                }
                $scope.GetAllLeaveDetails();
            }
        })
        .error(function (data) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }
    $scope.CancelLeave = function () {
        var rowId = $("#hdfRowIdUpdate").val();
        $http.post('ApplyLeave.aspx/UpdateLeaveStatus', { StatusId: "3", RowId: rowId })
        .success(function(data)
        {

        })
        .error(function (status) {

        })
    }
})
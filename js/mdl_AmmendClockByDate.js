var app = angular.module('ngAmmendClockByDate', []);
app.controller('ngAmmendClockByDateCtrl', function ($scope, $http) {
    $scope.FetchDDLDataSource = function () {
        //Get BranchDS
        $.blockUI();
        $http.post('AmmenTClockByDate.aspx/WM_LoadBranch', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlBranch").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');
            for (var i = 0; i < d.length; i++) {
                $("#ddlBranch").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
            }
            var $select1 = $('#ddlBranch');
            $select1.selectator({
                labels: {
                    search: 'Search here...'
                }
            });
        })
        .error(function (status) {
            alert(status);
        });
        //Get GradeDS
        $http.post('AmmenTClockByDate.aspx/WM_LoadGrade', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlGrade").html('');
            $("#ddlGrade").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');

                  for (var i = 0; i < d.length; i++) {
                      $("#ddlGrade").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
                  }
                  var $select1 = $('#ddlGrade');
                  $select1.selectator({
                      labels: {
                          search: 'Search here...'
                      }
                  });
              })
        .error(function (status) {
            alert(status);
        });
        //Get Designation
        $http.post('AmmenTClockByDate.aspx/WM_LoadDesignation', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlDesignation").html('');
            $("#ddlDesignation").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');
            for (var i = 0; i < d.length; i++) {
                $("#ddlDesignation").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
            }
            var $select1 = $('#ddlDesignation');
            $select1.selectator({
                labels: {
                    search: 'Search here...'
                }
            });
        })
        .error(function (status) {
            alert(status);
        });
        //Get Designation
        $http.post('AmmenTClockByDate.aspx/WM_LoadDepartment', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlDepartment").html('');
            $("#ddlDepartment").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');
            for (var i = 0; i < d.length; i++) {
                $("#ddlDepartment").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
            }
            var $select1 = $('#ddlDepartment');
            $select1.selectator({
                labels: {
                    search: 'Search here...'
                }
            });
        })
        .error(function (status) {
            alert(status);
        });
        //Get Designation
        $http.post('AmmenTClockByDate.aspx/WM_LoadShiftType', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlShiftType").html('');
            $("#ddlShiftType").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');
            for (var i = 0; i < d.length; i++) {
                $("#ddlShiftType").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
            }
            var $select1 = $('#ddlShiftType');
            $select1.selectator({
                labels: {
                    search: 'Search here...'
                }
            });
        })
        .error(function (status) {
            alert(status);
        });
        //Get Designation
        $http.post('AmmenTClockByDate.aspx/WM_LoadEmployeeType', {})
        .success(function (data, status) {
            var d = data.d;
            $("#ddlEmpType").html('');
            $("#ddlEmpType").append('<option value="0" data-left="<span style=margin-right:5px; color:#ccc;></span>">ALL</option>');
               for (var i = 0; i < d.length; i++) {
                   $("#ddlEmpType").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
               }
               var $select1 = $('#ddlEmpType');
               $select1.selectator({
                   labels: {
                       search: 'Search here...'
                   }
               });
               $.unblockUI();
           })
        .error(function (status) {
            alert(status);
        });
    }
    //Get Binding Data
    $scope.GetGridData = function () {
        var CurrDate = $("#txtDate").val();
        if (CurrDate == "")
        {
            alert("Please Select the Date!");
            return false;
        }
        var Branch = $("#ddlBranch").val();
        var Dept = $("#ddlDepartment").val()
        var Desig = $("#ddlDesignation").val();
        var EType = $("#ddlEmpType").val();
        var Grade = $("#ddlGrade").val();
        $.blockUI();
        $http.post('AmmenTClockByDate.aspx/WM_GetGridData', { CurrDate: CurrDate, Branch: Branch, Dept: Dept, Desig: Desig, EType: EType, Grade: Grade })
        .success(function (data) {
            $scope.BindDT(data.d);
            $.unblockUI();
        })
        .error(function (data) {

        });
    }


    $scope.BindDT = function (d) {
        var ShiftHours = 0;
        var TotalHours = 0;
        var TotalBreakHours = 0;
        var TotalNormalHours = 0;
        var TotalOT1Hours = 0;
        var TotalOT2Hours = 0;
        var TotalLostHours = 0;

        var t = $("#tblLst").DataTable();
        t.clear();
        for (var i = 0; i < d.length; i++) {
            var DelMarkup, EditMarkup;
            if (d[i].Edit_Status == "Closed") {
                EditMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
            }
            else {
                EditMarkup = '<button type="button" id="btnEdit_' + i + '"  onclick=showDialog(this) style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
            }
            if (d[i].Del_status == "Closed") {
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Delete</button>';
            }
            else { 
                DelMarkup = '<button type="button" id="btnDel_' + i + '"  onclick=deleteAttendanceDetails(this) style="font-size: 13px;" class="button success UltraSleek">Delete</button>';
            }
            var CurrentTotalHourWorked = d[i].Total_Hour_Worked;
            if (CurrentTotalHourWorked == "") {
                CurrentTotalHourWorked = "00:00";
            }
            TotalHours = TotalHours + (parseFloat(((CurrentTotalHourWorked).split(':')[0]) * 3600) + parseFloat(((CurrentTotalHourWorked).split(':')[1]) * 60));


            var CurrentShiftHour = d[i].Shift_Hour;
            if (CurrentShiftHour == "" || CurrentShiftHour == null) {
                CurrentShiftHour = "00:00";
            }
            ShiftHours = ShiftHours + (parseFloat(((CurrentShiftHour).split(':')[0]) * 3600) + parseFloat(((CurrentShiftHour).split(':')[1]) * 60));

            var CurrentBreakHour = d[i].Max_Break_Time;
            if (CurrentBreakHour == "" || CurrentBreakHour == null) {
                CurrentBreakHour = "00:00";
            }
            TotalBreakHours = TotalBreakHours + (parseFloat(((CurrentBreakHour).split(':')[0]) * 3600) + parseFloat(((CurrentBreakHour).split(':')[1]) * 60));

            var CurrentNormalHour = d[i].Nt_Hrs;
            if (CurrentNormalHour == "" || CurrentNormalHour == null) {
                CurrentNormalHour = "00:00";
            }
            TotalNormalHours = TotalNormalHours + (parseFloat(((CurrentNormalHour).split(':')[0]) * 3600) + parseFloat(((CurrentNormalHour).split(':')[1]) * 60));


            var CurrentOT1Hours = d[i].Ot1;
            if (CurrentOT1Hours == "" || CurrentOT1Hours == null) {
                CurrentOT1Hours = "00:00";
            }
            TotalOT1Hours = TotalOT1Hours + (parseFloat(((CurrentOT1Hours).split(':')[0]) * 3600) + parseFloat(((CurrentOT1Hours).split(':')[1]) * 60));

            var CurrentOT2Hours = d[i].Ot2;
            if (CurrentOT2Hours == "" || CurrentOT2Hours == null) {
                CurrentOT2Hours = "00:00";
            }
            TotalOT2Hours = TotalOT2Hours + (parseFloat(((CurrentOT2Hours).split(':')[0]) * 3600) + parseFloat(((CurrentOT2Hours).split(':')[1]) * 60));

            var CurrentLostHour = d[i].Lost_Hrs;
            if (CurrentLostHour == "" || CurrentLostHour == null) {
                CurrentLostHour = "00:00";
            }
            TotalLostHours = TotalLostHours + (parseFloat(((CurrentLostHour).split(':')[0]) * 3600) + parseFloat(((CurrentLostHour).split(':')[1]) * 60));

            t.row.add([
                    '<input type="checkbox" id="chk_' + i + '">',
                    d[i].Member_Code,
                    d[i].Member_Name,
                    d[i].Main_Status,
                    d[i].Shift_Name,
                    d[i].Shift_Hour,
                    d[i].Actual_In_Time,
                    d[i].Actual_Out_Time,
                    d[i].In_Time,
                    d[i].Out_Time,
                    d[i].Total_Hour_Worked,
                    d[i].Max_Break_Time,
                    d[i].Worked_Hour,
                    d[i].Nt_Hrs,
                    d[i].Ot1,
                    d[i].Ot2,
                    d[i].Ot3,
                    d[i].Lost_Hrs,
                    d[i].Processed,
                    d[i].Reason,
                    d[i].Dtl_row_Id,
                    EditMarkup,
                    DelMarkup,
                    d[i].Rejected_Attendance,
                    d[i].Main_Row_Id
            ]).draw(false);
        }
        t.rows().every(function (rowIdx, tableLoop, rowLoop) {
            if (t.cell({ row: rowIdx, column: 19 }).data() != "00:00" != "")
            {
                if (t.cell({ row: rowIdx, column: 8 }).data() != "00:00" && t.cell({ row: rowIdx, column: 9 }).data() != "00:00")
                {
                    var clockIn = t.cell({ row: rowIdx, column: 8 }).node();
                    var clockOut = t.cell({ row: rowIdx, column: 9 }).node();
                    $(clockIn).css('background', 'DarkSeaGreen');
                    $(clockOut).css('background', 'DarkSeaGreen');
                }
            }
        });
        $("#tdTHW").html($scope.SecondsTohhmmss(TotalHours));
        $("#tdTSH").html($scope.SecondsTohhmmss(ShiftHours));
        $("#tdTNH").html($scope.SecondsTohhmmss(TotalNormalHours));
        $("#tdTBH").html($scope.SecondsTohhmmss(TotalBreakHours));
        $("#tdOT1").html($scope.SecondsTohhmmss(TotalOT1Hours));
        $("#tdOT2").html($scope.SecondsTohhmmss(TotalOT2Hours));
        $("#tdTLH").html($scope.SecondsTohhmmss(TotalLostHours));

        $scope.TotalRows = i;
    }
    $scope.SecondsTohhmmss = function (totalSeconds) {
        var hours = Math.floor(totalSeconds / 3600);
        var minutes = Math.floor((totalSeconds - (hours * 3600)) / 60);
        var seconds = totalSeconds - (hours * 3600) - (minutes * 60);

        // round seconds
        seconds = Math.round(seconds * 100) / 100

        var result = (hours < 10 ? "0" + hours : hours);
        result += ":" + (minutes < 10 ? "0" + minutes : minutes);
        return result;
    }

    $scope.Save = function () {
        //Required Fields
        if ($("#txtClockIn").val() == "") {
            alert("Please Enter the Clock In!");
            return false;
        }
        if ($("#txtClockOut").val() == "") {
            alert("Please Enter the Clock out!");
            return false;
        }
        if ($("#txtReason").val() == "") {
            alert("Please Enter the Reason!");
            return false;
        }

        //Compare Time
        //---------------------------------------------------------------
        var start = $("#txtClockIn").val();
        var end = $("#txtClockOut").val();


        if (start == "00:00" && end == "00:00")
        {
            alert("Please Select the Clock In & Clock Out!");
            return false;
        }

        var startHour = start.split(':')[0];
        var startMinute = start.split(':')[1];
        var startSecond = 00;

        var endHour = end.split(':')[0];;
        var endMinute = end.split(':')[1];
        var endSecond = 00;

        //Create date object and set the time to that
        var startTimeObject = new Date();
        startTimeObject.setHours(startHour, startMinute, startSecond);

        //Create date object and set the time to that
        var endTimeObject = new Date(startTimeObject);
        endTimeObject.setHours(endHour, endMinute, endSecond);

        //Now we are ready to compare both the dates
        if (startTimeObject > endTimeObject) {
            var logDate = $("#txtLogDate").val();
            if (logDate == "")
            {
                alert("Please Select the Date!");
                return false;
            }
            var MemCode = $("#tdEmpId").html();
            $http.post('AmmentClockByEmp.aspx/CheckNightShift', { MemCode: MemCode, logDate: logDate })
            .success(function (data, status) {
                if (data.d == false) {
                    alert("The Clock out time must be greater than clock in!");
                    return false;
                }
            })
            .error(function () {

            })
        }
        else {
            //alert('Entries are perfect.');
            //Going to Save
            $("#dialog").dialog("close");
            $scope.SaveEntry();
        }
        //---------------------------------------------------------------------
    }
    $scope.SaveEntry = function () {
        $.blockUI();
        var MemCode = $("#tdEmpId").html();
        var LogDate = $("#txtLogDate").val();
        var ClockIn = $("#txtClockIn").val();
        var ClockOut = $("#txtClockOut").val();
        var Reason = $("#txtReason").val();
        var RowId = $("#hdfDTLRowId").val();
        if (RowId == "" || RowId == "00000000-0000-0000-0000-000000000000") {
            RowId = null;
        }
        var StrStatus = "IN-OUT";
        $http.post('AmmentClockByEmp.aspx/SaveEntry', { MemCode: MemCode, LogDate: LogDate, ClockIn: ClockIn, ClockOut: ClockOut, Reason: Reason, RowId: RowId, StrStatus: StrStatus })
        .success(function (data) {
            if(data.d==true)
            {
                $.unblockUI();
                alert("Successfully Updated the Details !");
                $scope.GetGridData();
            }
            else
            {
                $.unblockUI();
                alert("Something found Wrong! Please Try Again!");
            }
        })
        .error(function (status) {
            alert("Some error have occured.please contact your administrator! [Error Code:"+status+"]");
        })
    }
    $scope.DeleteAttendance = function () {
        $.blockUI();
        $http.post('AmmentClockByEmp.aspx/DeleteDetails', { MainRowId: $("#hdfMainRowId").val(), RowId: $("#hdfDTLRowId").val() })
        .success(function (data) {
            $.unblockUI();
            if (data.d == 0) {
                alert("Deleted Successfully!");
                $scope.GetGridData();
            }
            else if (data.d == -2) {
                alert("Deletion Failed!");
            }
            else if (data.d === 3) {
                alert("Exception Occured!");
            }
        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }
})
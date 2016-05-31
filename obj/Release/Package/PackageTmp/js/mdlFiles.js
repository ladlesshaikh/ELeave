var ngAmmendClockByEmp = angular.module('ngAmmendClockByEmp', []);
ngAmmendClockByEmp.controller('ngAmmendClockByEmpCtrl', function ($scope, $http, $compile) {
    $scope.FetchEmployeeDS = function () {
        $http.post('AmmentClockByEmp.aspx/getEmpLst', {})
        .success(function (data, status) {
            $scope.ngEmpLst = data.d;
            var d = data.d;
            for (var i = 0; i < d.length; i++) {
                $("#ddlEmloyee").append('<option value="5" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
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
    $scope.GetAttendanceDetails = function () {
        var empCode = $(".selectator_chosen_item_left span").html();
        var startDate = $("#txtStartDate").val();
        var EndDate = $("#txtEndDate").val();
        if (startDate == "" || EndDate == "")
        {
            alert("Select Date Range!");
            return false;
        }
        $.blockUI();
        $http.post('AmmentClockByEmp.aspx/ShowData', { StartDate: startDate, EndDate: EndDate, EmpCode: empCode }).success(function (data, status) {
            $.unblockUI();
            $scope.BindDT(data.d);
        }).error(function (status) {
            alert("Error Occured!");
            $.unblockUI();
        });
    }

    $scope.AddTime = function (oldtime, addtime) {
        var add = addtime;
        var startTime = oldtime
        var textArr = startTime.split(":");
        var origDate = new Date(1, 1, 1, textArr[0], textArr[1], 0, 0);

        var textAdd = add.split(":");
        origDate.setHours(origDate.getHours() + textAdd[0]);
        origDate.setMinutes(origDate.getMinutes() + textAdd[1]);

        var endTime = $scope.pad(origDate.getHours(), 2) + ":" + $scope.pad(origDate.getMinutes(), 2);
        console.log(endTime);
    }

    $scope.pad = function (str, max) {
        str = str.toString();
        return str.length < max ? $scope.pad("0" + str, max) : str;
    }


    $scope.SecondsTohhmmss = function (totalSeconds) {
        var hours = Math.floor(totalSeconds / 3600);
        var minutes = Math.floor((totalSeconds - (hours * 3600)) / 60);
        var seconds = totalSeconds - (hours * 3600) - (minutes * 60);

        // round seconds
        seconds = Math.round(seconds * 100) / 100

        var result = (hours < 10 ? "0" + hours : hours);
        result += "-" + (minutes < 10 ? "0" + minutes : minutes);
        result += "-" + (seconds < 10 ? "0" + seconds : seconds);
        return result;
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
                DelMarkup = '<button type="button" style="font-size: 13px;" class="button success UltraSleek">Delete</button>';
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
                    d[i].Log_Date,
                    d[i].Day_Name,
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
                    d[i].Rejected_Attendance
            ]).draw(false);
        }
        t.rows().every(function (rowIdx, tableLoop, rowLoop) {
            if (t.cell({ row: rowIdx, column: 19 }).data() != "00:00" != "") {
                if (t.cell({ row: rowIdx, column: 8 }).data() != "00:00" && t.cell({ row: rowIdx, column: 9 }).data() != "00:00") {
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
    $scope.getHour24 = function (timeString) {
        time = null;
        var matches = timeString.match(/^(\d{1,2}):00 (\w{2})/);
        if (matches != null && matches.length == 3) {
            time = parseInt(matches[1]);
            if (matches[2] == 'PM') {
                time += 12;
            }
        }
        return time;
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
            var MemCode = $("#tdEmpId").html();
            $http.post('AmmentClockByEmp.aspx/CheckNightShift', { MemCode: MemCode, logDate: logDate })
            .success(function (data, status) {
                if (data.d == false) {
                    $("#dialog").dialog("close");
                    alert("The Clock out time must be greater than clock in!");
                    return false;
                }
            })
            .error(function () {

            })
        }
        else {
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
            $.unblockUI();
            if (data.d == true) {
                alert("Successfully Updated the Details !");
                $scope.GetAttendanceDetails();
            }
            else {
                alert("Something found Wrong! Please Try Again!");
            }
        })
        .error(function (status) {
            $.unblockUI();
            alert("Some error have occured.please contact your administrator! [Error Code:" + status + "]");
        })
    }



    $scope.ProcessAttendance = function () {
        //Getting the Datatable Handle
        var table = $("#tblLst").DataTable();
        var TabLen = $scope.TotalRows;
        var PData = [];
        for (var i = 0; i < TabLen - 1; i++) {
            //MemCode
            var empId = $(".selectator_chosen_item_left span").html();
            //PuchDate
            var PunchDate = table.row(i).data()[1];
            //In Time
            var InTime = table.row(i).data()[8];
            //Out Time
            var OutTime = table.row(i).data()[9];
            //Main Status
            var MainStatus = table.row(i).data()[3]
            //Processed Flag
            var PFlag = table.row(i).data()[18]
            //Rejected Attendance
            var RejectedAttendance = table.row(i).data()[23]

            if ($("#chk_" + i).prop('checked') == true) {
                if (InTime != "00:00" && OutTime != "00:00" && MainStatus != "Absent" && PFlag != "PROCESSED") {
                    PData[i] = { empId: empId, PunchDate: PunchDate, InTime: InTime, OutTime: OutTime, MainStatus: MainStatus, PFlag: PFlag, RejectedAttendance: RejectedAttendance };
                }
            }
        }
        alert(JSON.stringify(PData));
        $http.post('AmmentClockByEmp.aspx/ProcessOT', { pData: JSON.stringify(PData) })
        .success(function () {

        })
        .error(function () {

        })
    }
});
var app = angular.module('ngBulkClocking', []);
app.controller('ngCtrlBulkClocking', function ($scope, $http) {
    $scope.FetchDDLDataSource = function () {
        //Get BranchDS
        $.blockUI();
        $http.post('BulkClocking.aspx/WM_LoadBranch', {})
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
        $http.post('BulkClocking.aspx/WM_LoadGrade', {})
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
        $http.post('BulkClocking.aspx/WM_LoadDesignation', {})
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
        $http.post('BulkClocking.aspx/WM_LoadDepartment', {})
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
        $http.post('BulkClocking.aspx/WM_LoadShiftType', {})
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
        $http.post('BulkClocking.aspx/WM_LoadEmployeeType', {})
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
    $scope.GetEmployee = function () {
        var logDate = $("#txtDate").val();
        if (logDate == "")
        {
            alert("Select the Date!");
            return false;
        }
        var Branch = $("#ddlBranch").val();
        var Dept = $("#ddlDepartment").val()
        var Desig = $("#ddlDesignation").val();
        var EType = $("#ddlEmpType").val();
        var Grade = $("#ddlGrade").val();
        var shiftType = $("#ddlShiftType").val();
        var newClock;
        if ($("#chk_new_clock").prop('checked') == true)
        {
            newClock = 1;
        }
        else
        {
            newClock = 0;
        }
        $.blockUI();
        $http.post('BulkClocking.aspx/WM_GetEmpList', { logDate: logDate, Branch: Branch, Dept: Dept, Desig: Desig, EType: EType, Grade: Grade, iInsertNewClock:newClock, shiftType: shiftType })
        .success(function (data) {
            var oTable = $('#tblLst').dataTable();
            oTable.fnClearTable();
            $.unblockUI();
         
            if(data.d==null)
            {
                alert("No Data found!");
            }
            else
            {
                $scope.BindDT(data.d);
            }
        })
        .error(function (status) {
            alert("Error Occured!");
            $.unblockUI();
        });
    }
    $scope.BindDT = function (d) {
        $("#chkBulkClockClearAll").prop('checked', 'checked');
        var t = $("#tblLst").DataTable();
        t.clear();
        var IsCont = 0;
        var p = $("#hdfProcessed").val();
        if (p != "")
        {
            p = JSON.parse(p);
            IsCont=1
        }
        var ProcessedStatus = "";
        for(var i=0;i<d.length;i++)
        {
            if (IsCont == 1)
            {
                if(d[i].Mem_code==p[i].Item1)
                {
                    if(p[i].Item2=="P")
                    {
                       ProcessedStatus = "Processed";
                    }
                    else
                    {

                    }
                }
                ProcessedStatus = "Processed";
            }
            t.row.add([
                  '<input type="checkbox" id="chk_' + i + '" checked="checked">',
                  d[i].Branch_id,
                  d[i].Branch_Name,
                  d[i].Mem_code,
                  d[i].Entroll_No,
                  d[i].Mem_Name,
                  d[i].Employee_Type,
                  d[i].Employee_Type_Name,
                  d[i].Clock_In,
                  d[i].Clock_Out,
                  ProcessedStatus,
                  d[i].Row_Id
            ]).draw(false);
        }
        $scope.TotalRows = d.length;
        $("#hdfProcessed").val('');
    }

    $scope.ClearControls = function () {
        $("#chk_new_clock").removeAttr('checked');
        $("#chk_one_time_clock").removeAttr('checked');
        $("#chk_new_clock").removeAttr('disabled');
        $("#chk_one_time_clock").removeAttr('disabled');
        $("#ChkIsClockIn").removeAttr('checked');
        $("#txtClockIn").val('');
        $("#ChkIsClockOut").removeAttr('checked');
        $("#txtClockOut").val('');
        $("#txtReason").val('');
    }
    $scope.clearAllChk = function () {
        if( $("#chkBulkClockClearAll").prop('checked')==false)
        {
            var table = $('#tblLst').dataTable();
            $("input[type=checkbox]", table.fnGetNodes()).each(function () {
                $(this).prop("checked", false);
            });
        }
        else
        {
            var table = $('#tblLst').dataTable();
            $("input[type=checkbox]", table.fnGetNodes()).each(function () {
                $(this).prop("checked", true);
            });
        }
    }


    $scope.ProcessData = function () {
        var c = confirm("You are about to Process the data are you really want to continue? (Y/N)");
        if (c == false)
        {
            return false;
        }
       
        //Getting the Datatable Handle
        var table = $("#tblLst").DataTable();
        var TabLen = $scope.TotalRows;
        var PData = [];
        if (TabLen == 0)
        {
            alert("The Employee List is empty!");
            return false;
        }
        if ($("#ChkIsClockIn").prop('checked') == true && $("#txtClockIn").val()!="") {
            var IsClockIn = 1;
        }
        else {
            var IsClockIn = 0;
        }
        if ($("#ChkIsClockOut").prop('checked') == true && $("#txtClockOut").val()!= "") {
            var IsClockOut = 1;
        }
        else {
            var IsClockOut = 0;
        }
        for (var i = 0; i < TabLen; i++) {

            if (i == 0)
            {
                if (IsClockIn == 0 || $("#txtClockIn").val()=="")
                {
                    var clock_in_time = table.row(i).data()[8];
                    clock_in_time = clock_in_time.split(':')[0] + ":" + clock_in_time.split(':')[1];
                }
                if (IsClockOut == 0 || $("#txtClockOut").val()=="")
                {
                    var clock_out_time = table.row(i).data()[9];
                    clock_out_time = clock_out_time.split(':')[0] + ":" + clock_out_time.split(':')[1];
                }
            }
            //BranchId
            var BranchId = table.row(i).data()[1];
            //Mem_Code
            var MemCode = table.row(i).data()[3];
            //Enroll No
            var EnrollNo = table.row(i).data()[4];
            //Mem_Name
            var Mem_Name = table.row(i).data()[5];
            //Emp_Type
            var Emp_type = table.row(i).data()[6];
            //Clock In
            var ClockIn = table.row(i).data()[8];
            //Clock Out
            var ClockOut = table.row(i).data()[9];
            //Row Id
            var RowId = table.row(i).data()[11];
            //if ($("#chk_" + i).prop('checked') == true) {
                if ($("#txtClockIn").val() != "" || $("#txtClockOut").val() != "") {
                    PData[i] = {Sel:"true",Branch_id:BranchId,Mem_code:MemCode,Entroll_No:EnrollNo,Mem_Name:Mem_Name,Employee_Type:Emp_type,Clock_In:ClockIn,Clock_Out:ClockOut,Row_Id:RowId };
                }
            //}
        }
        //alert(JSON.stringify(PData));
        var LogDate = $("#txtDate").val();
        if (LogDate == "")
        {
            alert("Select Date!");
            return false;
        }
        if ($("#chk_new_clock").prop('checked') == true)
        {
            var CheckInOut = 0;
        }
        else
        {
            var CheckInOut = 1;
        }
        var CheckIn = $("#txtClockIn").val();
        if (CheckIn == "")
        {
            CheckIn = clock_in_time;
        }
        var CheckOut = $("#txtClockOut").val();
        if (CheckOut == "")
        {
            CheckOut = clock_out_time;
        }
        if (CheckIn == "" && CheckOut == "")
        {
            alert("Please Select the Clock time!");
            return false;
        }
        //PData <!--Here-->
        var Reason = $("#txtReason").val();
        if (Reason == "")
        {
            alert("Please enter the reason!");
            return false;
        }
        if ($("#chk_one_time_clock").prop('checked') == true)
        {
            if(IsClockIn==0 && IsClockOut==0 )
            {
                alert("Please select any the checkbox meant for changing the clock time!");
                return false;
            }
        }
        $.blockUI();
        $http.post('BulkClocking.aspx/WM_ProcessDetails', { LogDate: LogDate, CheckInOut: CheckInOut, CheckIn: CheckIn, CheckOut: CheckOut, pData: JSON.stringify(PData), Reason: Reason, IsClockIn: IsClockIn, IsClockOut: IsClockOut })
        .success(function (data) {
            $.unblockUI();
            var s = data.d;
            s = JSON.stringify(s);
            $("#hdfProcessed").val(s);
            $scope.ClearControls();
            $scope.GetEmployee();
        })
        .error(function (status) {
            $.unblockUI();
            $("#hdfProcessed").val('');
            $scope.ClearControls();
        })
    }

    $scope.validate = function () {
        if ($("#chk_one_time_clock").prop('checked') == true)
        {
            $("#chk_new_clock").removeAttr('checked');
            $("#chk_new_clock").prop('disabled', 'disabled');
            $("#ChkIsClockIn").prop('checked', 'checked');
            $("#ChkIsClockOut").prop('checked', 'checked');
            $("#ChkIsClockIn").removeAttr('disabled');
            $("#ChkIsClockOut").removeAttr('disabled');
        }
        else
        {
            $("#chk_new_clock").removeAttr('disabled', 'disabled');
            $("#ChkIsClockIn").removeAttr('checked');
            $("#ChkIsClockOut").removeAttr('checked');
            $("#ChkIsClockIn").prop('disabled', 'disabled');
            $("#ChkIsClockOut").prop('disabled', 'disabled');

        }
    }

    $scope.validate1 = function () {
        if ($("#chk_new_clock").prop('checked') == true) {
            $("#chk_one_time_clock").removeAttr('checked');
            $("#chk_one_time_clock").prop('disabled', 'disabled');
        }
        else {
            $("#chk_one_time_clock").removeAttr('disabled', 'disabled');
        }
    }
})
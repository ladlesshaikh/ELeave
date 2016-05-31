$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        height: 325,
        width: 350,
        modal: true
    });
    $(".JQueryButton").button();
    $("#txtDate").datepicker({ changeMonth: true, changeYear: true });
    var t = $("#tblLst").DataTable({
        "columnDefs": [
              {
                  "targets": [0],
                  "sortable": false,
                  "searchable": false
              },
           {
               "targets": [20],
               "visible": false,
               "searchable": false
           },
        {
               "targets": [23],
        "visible": false,
        "searchable": false
        },
        {
               "targets": [24],
        "visible": false,
        "searchable": false
    }
        ],
        "columns": [
            { "width": "20px" },
            { "width": "60px" },
            { "width": "220px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "50px" },
            { "width": "35px" },
            { "width": "35px" },
            { "width": "35px" },
            { "width": "35px" },
            { "width": "35px" },
            { "width": "35px" },
            { "width": "50px" },
            null,
            null,
            { "width": "20px" },
            { "width": "30px" },
            { "width": "30px" },
            null
        ]
    });
});

function showDialog(sender) {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#dialog").dialog("open");
    $('#txtClockIn').timepicker();
    $('#txtClockOut').timepicker();
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#tdEmpId").html(table.row(split).data()[1]);
    $("#tdEmpName").html(table.row(split).data()[2] + " <b>[" + table.row(split).data()[1] + "]</b>");
    $("#txtLogDate").val($("#txtDate").val());
    if ($("#txtDate").val() == "")
    {
        alert("The Date can't be null!");
        return false;
    }
    $("#txtClockIn").val(table.row(split).data()[8]);
    $("#txtClockOut").val(table.row(split).data()[9]);
    $("#txtReason").val(table.row(split).data()[19]);
    $("#hdfDTLRowId").val(table.row(split).data()[20]);
}

function deleteAttendanceDetails(sender) {
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    var main_row_id = table.row(split).data()[24];
    var dtl_row_id = table.row(split).data()[20];
    if (dtl_row_id == "" || main_row_id == "") {
        return false;
    }
    var c = confirm("Are you really want to delete this entry! (OK/Cancel)");
    if (c == true) {
        $("#hdfDTLRowId").val(dtl_row_id);
        $("#hdfMainRowId").val(main_row_id);
        angular.element(document.getElementById('txtDate')).scope().DeleteAttendance();
    }
    else {
        return false;
    }

}

function CloseDialog() {
    $("#dialog").dialog("close");
}
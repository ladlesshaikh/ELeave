//Selectator Initialization
$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        height: 325,
        width: 350,
        modal: true
    });
    $(".JQueryButton").button();

    $("#txtStartDate").datepicker({
        onSelect: function (selected) {
            $("#txtEndDate").datepicker("option", "minDate", selected);
        },
        changeMonth: true, changeYear: true 
    });
    $("#txtEndDate").datepicker({
        onSelect: function (selected) {
            $("#txtStartDate").datepicker("option", "maxDate", selected);
        },
        changeMonth: true, changeYear: true
    });
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
            { "width": "90px" },
            { "width": "90px" },
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
    $("#tdEmpId").html($(".selectator_chosen_item_left span").html());
    $("#tdEmpName").html($(".selectator_chosen_item_title").html());
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#txtLogDate").val(table.row(split).data()[1]);
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
    if (dtl_row_id == "" || main_row_id == "")
    {
        return false;
    }
    var c = confirm("Are you really want to delete this entry! (OK/Cancel)");
    if (c == true)
    {
        $("#hdfDTLRowId").val(dtl_row_id);
        $("#hdfMainRowId").val(main_row_id);
        angular.element(document.getElementById('txtEndDate')).scope().DeleteAttendance();
    }
    else
    {
        return false;
    }
   
}


function CloseDialog()
{
    $("#dialog").dialog("close");
}
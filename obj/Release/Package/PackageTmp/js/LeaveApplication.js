$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        height: 260,
        width: 532,
        modal: true
    });
    $("#Update_dialog").dialog({
        autoOpen: false,
        height: 120,
        width: 303,
        modal: true
    });
    
    $("#dialog").dialog("close")
    $("#Update_dialog").dialog("close")
    $("#AppliedDate").datepicker();
    $("#FromDate").datepicker({
        onSelect: function (selected) {
            $("#ToDate").datepicker("option", "minDate", selected);
            CalculateDiff();
        }
    });
    $("#ToDate").datepicker({
        onSelect: function (selected) {
            $("#FromDate").datepicker("option", "maxDate", selected);
            CalculateDiff();
        }
    });


    $(".JQueryButton").button();
    var t = $("#tblLst").DataTable({
        "columnDefs": [
              {
                  "targets": [1],
                  "sortable": false,
                  "searchable": false,
                  "visible": false
              },
                    {
                        "targets": [8],
                        "sortable": false,
                        "searchable": false,
                        "visible": false
                    },
                       {
                           "targets": [11],
                           "sortable": false,
                           "searchable": false,
                           "visible": false
                       },
                {
                    "targets": [12],
                    "sortable": false,
                    "searchable": false,
                    "visible": false
                },
        ],
        "columns": [
            { "width": "70px" },
            { "width": "70px" },
            { "width": "135px" },
            { "width": "70px" },
            { "width": "70px" },
            { "width": "65px" },
            null,
            
            { "width": "30px" },
            { "width": "40px" },
            { "width": "60px" },
             { "width": "30px" },
              { "width": "30px" },
               { "width": "30px" },
        ]
    });
})

function showDialog() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    today = mm + '/' + dd + '/' + yyyy;
    $("#AppliedDate").val(today);
    $("#ddlEmloyee").val($("#hdfMemCode").val());
    $("#hdfRowId").val('');
    $('#ddlEmloyee').selectator('refresh');


    $("#FromDate").val('');
    $("#ToDate").val('');
    $("#txtReason").val('');
    $("#tdTotalLeaves").html('0')
    $("#chkSpecialLeave").val(0);
    $("#chkHalfDayLeave").val(0);
    $.ui.dialog.prototype._focusTabbable = function () { };
    var dialog = $("#dialog").dialog("open");
}

function EditDialog(sender) {
    $("#ddlEmloyee").val($("#hdfMemCode").val());
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#dialog").dialog("open");
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#AppliedDate").val(table.row(split).data()[0]);
    $("#FromDate").val(table.row(split).data()[3]);
    $("#ToDate").val(table.row(split).data()[4]);
    $("#txtReason").val(table.row(split).data()[6]);
    $("#tdTotalLeaves").html(table.row(split).data()[5])
    if(table.row(split).data()[11]==1)
    {
        $("#chkSpecialLeave").prop('checked','checked')
    }
    else
    {
        $("#chkSpecialLeave").removeProp('checked');
    }
    if (table.row(split).data()[12] == 1) {
        $("#chkHalfDayLeave").prop('checked', 'checked')
    }
    else {
        $("#chkHalfDayLeave").removeProp('checked');
    }
    $("#hdfRowId").val(table.row(split).data()[8]);
}

function CancelDialog(sender) {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#Update_dialog").dialog("open");
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#hdfRowIdUpdate").val(table.row(split).data()[8]);
}


// To calulate difference b/w two dates
function CalculateDiff() {

    if ($("#FromDate").val() != "" && $("#ToDate").val() != "") {

        var From_date = new Date($("#FromDate").val());
        var To_date = new Date($("#ToDate").val());
        var diff_date = To_date - From_date;
        var days = Math.floor(((diff_date % 31536000000) % 2628000000) / 86400000);
        $("#tdTotalLeaves").html(days);
    }
    else {
        return false;
    }
}
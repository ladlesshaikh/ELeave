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
        }
    });
    $("#txtEndDate").datepicker({
        onSelect: function (selected) {
            $("#txtStartDate").datepicker("option", "maxDate", selected);
        }
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
            { "width": "30px" }
        ]
    });
});

function showDialog(sender) {
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
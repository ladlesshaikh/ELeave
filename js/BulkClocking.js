$(document).ready(function () {
    $('#txtClockIn').timepicker();
    $('#txtClockOut').timepicker();
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
                 "targets": [1],
                 "sortable": false,
                 "searchable": false,
                 "visible": false
             },
             {
                 "targets": [6],
                 "sortable": false,
                 "searchable": false,
                 "visible": false
             },
             //{
             //    "targets": [10],
             //    "sortable": false,
             //    "searchable": false,
             //    "visible": false
             //},
             {
                 "targets": [11],
                 "sortable": false,
                 "searchable": false,
                 "visible": false
             }
        ],
        "columns": [
            //Checkbox
            { "width": "20px" },
            //Branch_Id
            { "width": "70px" },
             //Branch_Name
            { "width": "150px" },
            //Code
            { "width": "70px" },
            //Enroll_No
            { "width": "70px" },
            //Name
            null,
            //Emp_Type
            { "width": "70px" },
            //Emp_Type_name
            { "width": "150px" },
            //Clock In
            { "width": "70px" },
            //Clock Out
            { "width": "70px" },
            //Process
            { "width": "70px" },
            //Row_Id
            { "width": "70px" }
        ]
    });
});

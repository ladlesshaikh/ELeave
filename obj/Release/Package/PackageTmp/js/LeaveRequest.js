$(document).ready(function () {
    var t = $("#tblLst").DataTable({
        "columnDefs": [
              {
                  "targets": [10],
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

                    {
                        "targets": [13],
                        "sortable": false,
                        "searchable": false,
                        "visible": false
                    },
                       {
                           "targets": [14],
                           "sortable": false,
                           "searchable": false,
                           "visible": false
                       },
                {
                    "targets": [1],
                    "sortable": false,
                    "searchable": false,
                    "visible": false
                },
        {
            "targets": [2],
            "sortable": false,
            "searchable": false,
            "visible": false
        }
        ],
        "columns": [
            { "width": "70px" },
             { "width": "70px" },
             { "width": "70px" },
             { "width": "250px" },
            { "width": "135px" },
            { "width": "70px" },
            { "width": "70px" },
             { "width": "80px" },

            null,
              { "width": "80px" },
            { "width": "30px" },
            { "width": "40px" },
            { "width": "60px" },
              { "width": "30px" },
               { "width": "30px" },
        ]
    });




    var table = $("#tblHistory").DataTable({
        "columns": [
            { "width": "70px" },
              { "width": "250px" },
             { "width": "120px" },
            { "width": "70px" },
            { "width": "70px" },
             { "width": "70px" },

            null,
              { "width": "80px" },
        ]
    });
})


function sanction(sender)
{
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    var status = $("#ddlStatus_" + split).val();
    if (status == 5)
    {
        alert("Please Approve/Reject the Request!");
        return false;
    }
    var rowId = table.row(split).data()[10];
    $("#" + sender.id).parent().parent().remove();
    angular.element(document.getElementById('btn')).scope().ChangeStatus(status, rowId);
}
$(document).ready(function () {
    var t = $("#tblLst").DataTable({
        "columnDefs": [
              {
                  "targets": [1],
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
                        "targets": [15],
                        "sortable": false,
                        "searchable": false,
                        "visible": false
                    },
                       {
                           "targets": [16],
                           "sortable": false,
                           "searchable": false,
                           "visible": false
                       },
                {
                    "targets": [17],
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
            null,
            null,
              { "width": "60px" },
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
    
    $("#reject_leave_remarks").dialog({
        autoOpen: false,
        height: 160,
        width: 532,
        modal: true
    });
    $("#reject_leave_remarks").dialog("close");

    $("#transfer_dialog").dialog({
        autoOpen: false,
        height:300,
        width: 532,
        modal: true
    });
    $("#transfer_dialog").dialog("close");
    $("#upload_dialog").dialog({
        autoOpen: false,
        height: 160,
        width: 532,
        modal: true
    });
    $("#upload_dialog").dialog("close");
})


function sanction(sender)
{
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    var status = $("#ddlStatus_" + split).val();
    if (status == 5)
    {
        alert("Please select an option from the status, and try again …");
        return false;
    }
    var rowId = table.row(split).data()[13];
    //$("#" + sender.id).parent().parent().remove();
    $("#hdfTransferRowId").val(rowId);


    angular.element(document.getElementById('btn')).scope().ChangeStatus(status, rowId);
}

function ShowAttachments(sender) {
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    var rowId = table.row(split).data()[13];
    //$("#" + sender.id).parent().parent().remove();
    angular.element(document.getElementById('btn')).scope().loadDocDet(rowId);
}

function SelectRO(sender) {
    var id = sender.id;
    var seq = id.split('_')[1];
    angular.element(document.getElementById('btn')).scope().SetROMemCode(seq);
}

function HideROList() {
    var ddlValue = $("#ddlTransferAuth option:selected").val();
    if(ddlValue==2)
    {
        $("#tblROLst").hide();
        $("#tblAdminLst").show();
    }
    else if(ddlValue==1)
    {
        $("#tblAdminLst").hide();
        $("#tblROLst").show();
    }
}
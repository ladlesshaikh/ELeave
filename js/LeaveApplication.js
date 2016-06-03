/// <reference path="LeaveApplication.js" />
$(document).ready(function () {

    var haveUpload = $("#hdfDocUploadInLeave").val();
    var dialoght;
    var popupht;
    var totleavetop;
    if (haveUpload == 0) {
        dialoght = 248;
        popupht = 199;
        totleavetop = 220;
        //$("#tblUploadDoc").hide();
        //$("#tblTotLeave").css("top", "220px");
        //$(".Popup_Header").css("height", "300px")
        $("#dialog").dialog({
            autoOpen: false,
            //height: 285,
            width: 532,
            modal: true
        });
    }
    else {
        $("#dialog").dialog({
            autoOpen: false,
            //height: 500,
            width: 532,
            modal: true
        });
    }


    $("#Update_dialog").dialog({
        autoOpen: false,
        height: 150,
        width: 303,
        modal: true
    });

    $("#upload_dialog").dialog({
        autoOpen: false,
        height: 370,
        width: 532,
        modal: true
    });

    $("#Leave_Application_dialog").dialog({
        autoOpen: false,
        height: 370,
        width: 800,
        modal: true
    });

    $(".icon-btn").button({
        icons: {
            primary: "ui-icon-locked"
        },
        text: false
    })

    $("#dialog").dialog("close");
    $("#upload_dialog").dialog("close");
    $("#Leave_Application_dialog").dialog("close");
    $("#Update_dialog").dialog("close");
    $("#AppliedDate").datepicker();
    $("#FromDate").datepicker({
        onSelect: function (selected) {
            //$("#ToDate").datepicker("option", "minDate", selected);
            CalculateDiff();
        }
    });
    $("#ToDate").datepicker({
        onSelect: function (selected) {
            //$("#FromDate").datepicker("option", "maxDate", selected);
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
                   "targets": [2],
                   "sortable": false,
                   "searchable": false,
                   "visible": false
               },
                    {
                        "targets": [10],
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
                    "targets": [13],
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
            { "width": "30px" },
            null,
            { "width": "70px" },
            { "width": "100px" },
            null,
            { "width": "40px" },
            { "width": "60px" },
             { "width": "30px" },
              { "width": "30px" },
               { "width": "30px" },
                { "width": "30px" },
                { "width": "30px" }
        ]
    });


})

function showUploadDialog(sender) {
    var id = sender.id;
    var split = id.split('_')[1];
    $.ui.dialog.prototype._focusTabbable = function () { };
    var table = $("#tblLst").DataTable();
    var dialog = $("#upload_dialog").dialog("open");
    //alert(table.row(split).data()[9]);
    $("#hdfRowId").val(table.row(split).data()[10]);
    angular.element(document.getElementById('btnUpload_Docs')).scope().loadDocDet(table.row(split).data()[10]);
}

function Sendmail(sender) {
    var id = sender.id;
    if ($("#" + id).attr('data-id') == 1) {
        var e = confirm("You have already send the mail, want to send again ?");
        if (e == false) {
            return false;
        }
    }
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#hdfRowId").val(table.row(split).data()[10]);
    angular.element(document.getElementById('btnUpload_Docs')).scope().SendMail(table.row(split).data()[10]);
}



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
    $("#selectator_ddlEmloyee input").attr('disabled', 'disabled');

    $("#FromDate").val(today);
    $("#ToDate").val(today);
    $("#txtReason").val('');
    $("#tdTotalLeaves").html('0')
    $("#chkSpecialLeave").val(0);
    $("#chkHalfDayLeave").val(0);
    $("#chkSpecialLeave").removeAttr('checked');
    $("#chkHalfDayLeave").removeAttr('checked');
    $("#ddlFileType").val('');
    $("#txtRemarks_Attach").val('');
    $("#fileAttach").val('');
    $("#ddlLeaveAppDocType").val('');
    $("#txtLeaveAppAttachment_Remarks").val('');
    $("#leaveAppAttachment").val('');

    $("#checkAM").removeAttr('checked');
    $("#checkPM").removeAttr('checked');

    angular.element(document.getElementById('btnLeaveAppSave')).scope().createLeaveId();



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
    if (table.row(split).data()[13] == 1) {
        $("#chkSpecialLeave").attr('checked', 'checked')
    }
    else {
        $("#chkSpecialLeave").removeAttr('checked');
    }
    if (table.row(split).data()[14] == 1) {
        $("#chkHalfDayLeave").attr('checked', '')
        var h_mode = table.row(split).data()[7];
        console.log(h_mode);
        h_mode = h_mode.split(":")[1];
        $("#checkAM").removeAttr("checked");
        $("#checkPM").removeAttr("checked");
        console.log(h_mode);
        if (h_mode == "AM") {
            $("#checkAM").prop("checked", "checked");
        }
        if (h_mode == "PM") {
            $("#checkPM").prop("checked", "checked");
        }
    }
    else {
        $("#chkHalfDayLeave").removeAttr('checked');
    }

    $("#hdfRowId").val(table.row(split).data()[10]);
}

function CancelDialog(sender) {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#Update_dialog").dialog("open");
    var id = sender.id;
    var split = id.split('_')[1];
    var table = $("#tblLst").DataTable();
    $("#hdfRowIdUpdate").val(table.row(split).data()[10]);
}


// To calulate difference b/w two dates
function CalculateDiff() {

    if ($("#FromDate").val() != "" && $("#ToDate").val() != "") {

        var From_date = new Date($("#FromDate").val());
        var To_date = new Date($("#ToDate").val());
        var diff_date = To_date - From_date;
        var days = Math.floor(((diff_date % 31536000000) % 2628000000) / 86400000);
        $("#tdTotalLeaves").html(days);
        if (days == 0) {
            $("#tdTotalLeaves").html("1");
            $("#chkHalfDayLeave").prop("checked", "checked");
        }
    }
    else {

        return false;
    }
}

function CloseDialog() {
    $("#Update_dialog").dialog("close");
}
function CloseDialog1() {
    $("#dialog").dialog("close");
}
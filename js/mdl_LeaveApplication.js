var app = angular.module('AppLeave', ['ngCookies', 'ngResource', 'ngSanitize', 'ngRoute', 'angularFileUpload']);

app.controller('Ctrl_AppLeave', function ($scope, $http, $timeout, $upload) {
    $scope.FetchEmployeeDetails = function () {
        $http.post('ApplyLeave.aspx/getEmpLst', {})
        .success(function (data, status) {
            $scope.ngEmpLst = data.d;
            var d = data.d;
            for (var i = 0; i < d.length; i++) {
                $("#ddlEmloyee").append('<option value="' + d[i].ValueMember + '" data-left="<span style=margin-right:5px; color:#ccc;>' + d[i].ValueMember + '</span>">' + d[i].DisplayMember + '</option>');
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
    $scope.BindTab = function (d) {
        var t = $("#tblLst").DataTable();
        t.clear();
        for (var i = 0; i < d.length; i++) {
            var rejection_remarks = "";
            var leavename = "";
            leavename = d[i].leavename;
            if (d[i].Is_Sanctioned == "2") {
                EditMarkup = '<button type="button" id="btnEdit_' + i + '"  onclick=EditDialog(this) style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
                var Status = '<img src="../../images/submitted.png" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "3") {
                EditMarkup = '<button type="button" id="btnEdit_' + i + '"  onclick=EditDialog(this) style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
                var Status = '<img src="../../images/transferred.PNG" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "5") {
                EditMarkup = '<button type="button" id="btnEdit_' + i + '"  onclick=EditDialog(this) style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
                var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
            }
            else {
                if (d[i].Is_Sanctioned == "1") {
                    var Status = '<img src="../../images/accepted.png" style="height:20px;">';
                }
                else if (d[i].Is_Sanctioned == "3") {
                    var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
                }
                else {
                    var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
                    rejection_remarks = d[i].RO_REMARKS;

                }
                EditMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button  UltraSleek">Edit</button>';
            }
            if (d[i].Is_Sanctioned == "2") {
                DelMarkup = '<button  id="btnDel_' + i + '" type="button" style="font-size: 13px;" class="button danger UltraSleek" onclick="CancelDialog(this)">Cancel</button>';
                var Status = '<img src="../../images/submitted.png" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "3") {
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button UltraSleek">Cancel</button>';
                var Status = '<img src="../../images/transferred.PNG" style="height:20px;">';
            }
            else if (d[i].Is_Sanctioned == "5") {
                DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button UltraSleek">Cancel</button>';
                var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
            }
            else {
                if (d[i].Is_Sanctioned == "1") {
                    var Status = '<img src="../../images/accepted.png" style="height:20px;">';
                    DelMarkup = '<button  id="btnDel_' + i + '" type="button" style="font-size: 13px;" class="button danger UltraSleek" onclick="CancelDialog(this)">Cancel</button>';
                }
                else if (d[i].Is_Sanctioned == "3") {
                    var Status = '<img src="../../images/cancelled.png" style="height:20px;">';
                    DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button UltraSleek">Cancel</button>';
                }
                else {
                    var Status = '<img src="../../images/rejected.png" style="height:20px;">';
                    rejection_remarks = d[i].RO_REMARKS;
                    DelMarkup = '<button type="button" disabled="disabled" style="font-size: 13px;" class="button UltraSleek">Cancel</button>';
                }


            }
            var Type = "";
            if (d[i].SPECIAL_LEAVE == 1) {
                Type = "Special Leave";
            }
            if (d[i].HALF_DAY_LEAVE == 1) {
                Type = "Half Day Leave" + ":" + d[i].HALF_DAY_LEAVE_MODE;
            }
            if (d[i].Is_Sanctioned == "2" || d[i].Is_Sanctioned == "3") {
                var uploadStr = '<button type="button" id="btnUpload_' + i + '" onclick="showUploadDialog(this)" style="font-size: 12px;" class="button UltraSleek">Attach</button>'
            }
            else {
                var uploadStr = '<button type="button" disabled="disabled" id="btnUpload_' + i + '" onclick="showUploadDialog(this)" style="font-size: 12px;" class="button UltraSleek">Attach</button>'
            }
            if (d[i].Is_Sanctioned == "1" || d[i].Is_Sanctioned == "0") {
                if (d[i].Is_Send_Mail == 1) {
                    var mail = '<button data-id="1" disabled="disabled" type="button" id="btnMailSend_' + i + '" onclick="Sendmail(this)" style="font-size: 12px;" class="button UltraSleek">Mail</button>'
                }
                else {
                    var mail = '<button data-id="0" disabled="disabled" type="button" id="btnMailSend_' + i + '" onclick="Sendmail(this)" style="font-size: 12px;" class="button UltraSleek">Mail</button>'
                }
            }
            else {
                if (d[i].Is_Send_Mail == 1) {
                    var mail = '<button data-id="1" disabled="disabled"  type="button" id="btnMailSend_' + i + '" onclick="Sendmail(this)" style="font-size: 12px;" class="button UltraSleek">Mail</button>'
                }
                else {
                    var mail = '<button data-id="0" disabled="disabled"  type="button" id="btnMailSend_' + i + '" onclick="Sendmail(this)" style="font-size: 12px;" class="button UltraSleek">Mail</button>'
                }
            }



            t.row.add([
                   d[i].APP_DATE,
                   d[i].Leavecode,
                   $("#ddlLeaveType option[value=" + d[i].Leavecode + "]").text(),
                   d[i].FROM_DATE,
                   d[i].TO_DATE,
                   d[i].TOT_DAY,
                   d[i].REASON,
                   Type,  //leavename
                   Status,
                   rejection_remarks,
                   d[i].ROW_ID,
                    EditMarkup,
                    DelMarkup,
                   d[i].SPECIAL_LEAVE,
                   d[i].HALF_DAY_LEAVE,
                   uploadStr,
                   d[i].LeaveName//null
            ]).draw(false);
        }
    }

    $scope.GetAllLeaveDetails = function () {
        $.blockUI();
        $http.post('ApplyLeave.aspx/getLeaveDetails', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
            $.unblockUI();

            $scope.BindTab(data.d);

        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        });
    }

    $scope.GetLeaveHistory = function () {
        $http.post('ApplyLeave.aspx/getLeaveHistory', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
            $scope.LeaveHist = data.d;
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }
    $scope.GetLeaveHistoryDetails = function () {
        $http.post('ApplyLeave.aspx/getLeaveHistoryDetails', { MemCode: $("#hdfMemCode").val() })
        .success(function (data) {
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }

    $scope.FetchDocumentType = function () {
        $http.post('ApplyLeave.aspx/GetDocumentType', {})
        .success(function (data) {
            $scope.DocTypeLst = data.d;
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }
    $scope.CheckMedicalRec = function ($event) {
        var isMed = $('#ddlFileType').find(":selected").attr('data-id')
        if (isMed == 1) {
            $scope.Med_Status = "Medical Document";
        }
        else {
            $scope.Med_Status = "Non medical Document";
        }
    }


    $scope.createLeaveId = function () {
        $http.post('ApplyLeave.aspx/CreateGUID', {})
        .success(function (data) {
            $("#txtLeaveId").val(data.d);
            $.ui.dialog.prototype._focusTabbable = function () { };
            var dialog = $("#dialog").dialog("open");
        })
        .error(function (data) {
            alert("Unable to Create Leave Application Id!");
        });
    }



    $scope.SaveLeave = function () {
        //string strRowId, string strMemberCode, int iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays,
        //bool isSpecialLeave, bool isIsHalfDay, int iTotalDays, string strReason, string strFlag
        $scope.IsAlertShown = 0;
        var strMemberCode = $('#ddlEmloyee').val();
        var iLeaveType = $("#ddlLeaveType").val();
        var dtAppDate = $("#AppliedDate").val();
        var dtFrom = $("#FromDate").val();
        var dtTo = $("#ToDate").val();
        var fTotalDays = $("#tdTotalLeaves").html();

        if (dtFrom == "" || dtTo == "") {
            alert("Select Start Date and end date!");
            return false;
        }

        if (dtFrom > dtTo) {
            alert("From Date can not be more than end date!");
            return false;
        }

        if ($("#chkSpecialLeave").prop('checked') == true) {
            var isSpecialLeave = 1;
        }
        else {
            var isSpecialLeave = 0;
        }
        if ($("#chkHalfDayLeave").prop('checked') == true) {
            var isIsHalfDay = 1;
        }
        else {
            var isIsHalfDay = 0;
        }


        var iTotalDays = 0;
        var strReason = $("#txtReason").val();
        if ($("#hdfRowId").val() != "") {
            var strRowId = $("#hdfRowId").val();
            var strFlag = 'E';
        }
        else {
            var strFlag = 'A';
            var strRowId = null;
        }
        var LeaveId = $("#txtLeaveId").val();

        //AM-PM
        //var isSaveCont = 1;
        //var halfdayleavemode = "";
        //if ($("#chkHalfDayLeave").prop("checked") == true)
        //{
        //    if($("#checkAM").prop("checked")==false && $("#checkPM").prop("checked")==false)
        //    {
        //        alert("Please specify the leave is on AM/PM!");
        //        return false;
        //        isSaveCont = 0;
        //    }
        //}
        //if($("#checkAM").prop("checked")==true)
        //{
        //    halfdayleavemode = "AM";
        //}
        //if ($("#checkPM").prop("checked") == true)
        //{
        //    halfdayleavemode = "PM";
        //}
        //if (isSaveCont == 0)
        //{
        //    return false;
        //}
        //$('#dialog').block({
        //    message: '<h1 style="font-size:12px;">Submitting Application</h1>',
        //    css: { border: '#ccc solid 1px', background: '#f5f5f5' }
        //});

        //$http.post('ApplyLeave.aspx/SaveLeaveApp', { leaveId: LeaveId, strRowId: strRowId, strMemberCode: strMemberCode, iLeaveType: iLeaveType, dtAppDate: dtAppDate, dtFrom: dtFrom, dtTo: dtTo, fTotalDays: fTotalDays, isSpecialLeave: isSpecialLeave, isIsHalfDay: isIsHalfDay, iTotalDays: iTotalDays, strReason: strReason, strFlag: strFlag, halfdayleavemode:halfdayleavemode })
        //.success(function (data) {
        var isSaveCont = 1;
        var halfdayleavemode = "";
        if ($("#chkHalfDayLeave").prop("checked") == true) {
            if ($("#checkAM").prop("checked") == false && $("#checkPM").prop("checked") == false) {
                alert("Please specify the leave is on AM/PM!");
                return false;
                isSaveCont = 0;
            }
            if (dtFrom != dtTo) {
                alert("For half day leave from and to date should same!");
                return false;
            }
        }
        if ($("#checkAM").prop("checked") == true) {
            halfdayleavemode = "AM";
        }
        if ($("#checkPM").prop("checked") == true) {
            halfdayleavemode = "PM";
        }
        if (isSaveCont == 0) {
            return false;
        }
        $('#dialog').block({
            message: '<h1 style="font-size:12px;">Submitting Application</h1>',
            css: { border: '#ccc solid 1px', background: '#f5f5f5' }
        });

        var strFlagpercent = 'Y';
        $http.post('ApplyLeave.aspx/SaveLeaveApp', { leaveId: LeaveId, strRowId: strRowId, strMemberCode: strMemberCode, iLeaveType: iLeaveType, dtAppDate: dtAppDate, dtFrom: dtFrom, dtTo: dtTo, fTotalDays: fTotalDays, isSpecialLeave: isSpecialLeave, isIsHalfDay: isIsHalfDay, iTotalDays: iTotalDays, strReason: strReason, strFlag: strFlag, strFlagpercent: strFlagpercent, halfdayleavemode: halfdayleavemode })
        .success(function (data) {
            $('#dialog').unblock();
            $("#dialog").dialog("close");
            if (data.d == -50) {
                alert("Leave request already there for the requested date! Pease apply leave on another date!");
                return false;
            }
            if (data.d == -10) {
                alert("Leave request exceeded the team limit, Please apply leave on another date!");
                return false;
            }
            if (data.d == -100) {
                alert("No Reporting officers are assigned! Contact your Administrator.");
                return false;
            }
            if (data.d == -200) {
                alert("No Reporting officers / Admin are assigned! Contact your Administrator.");
                return false;
            }
            if (data.d == 0 || data.d == -500) {
                if (strFlag == 'A') {
                    if ($scope.IsFileUploadComplete == 1) {
                        if ($scope.IsAlertShown == 0) {
                            $scope.IsAlertShown = 1;
                            if (data.d == 0) {
                                alert("Leave Application Submitted and mail send!");
                            }
                            else {
                                alert("Leave Application Submitted!");
                            }
                        }
                    }
                }
                else {
                    alert("Leave Application Updated!");
                }
                $scope.GetAllLeaveDetails();
            }
            if (data.d == -600) {
                alert("Leave can't be submitted!");
                return false;
            }
        })
        .error(function (data) {
            $('#dialog').unblock();
            $("#dialog").dialog("close");
            alert("Error Occured!");
        });
    }

    $scope.CancelLeave = function () {
        var rowId = $("#hdfRowIdUpdate").val();
        $.blockUI();
        $http.post('ApplyLeave.aspx/UpdateLeaveStatus', { StatusId: "5", RowId: rowId })
        .success(function (data) {
            $.unblockUI();
            if (data.d == true) {
                $("#Update_dialog").dialog("close");
                alert("Leave Application Cancelled!");
                $scope.GetAllLeaveDetails();
            }

        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured!");
        })
    }

    //Attach Supporting Docs Starts here..
    $scope.upload = [];



    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };
    $scope.onFileSelect = function () {
        //Parameter Construction --
        var user_id = $("#hdfMemCode").val();
        var application_id = $("#hdfRowId").val();
        var file_type = $("#ddlFileType").val();
        if (file_type == 0) {
            alert("Select the Attachment type !");
            return false;
        }
        var remarks = $("#txtRemarks_Attach").val();
        if (remarks == 0) {
            alert("Enter the Remarks !");
            return false;
        }
        var finyear = $("#hdfFinYear").val();
        //--
        $scope.attachment_Details = { user_id: user_id, application_id: application_id, file_type: file_type, remarks: remarks, fin_year: finyear }

        //Blocking UI
        $('#div_Attachments').block({
            message: '<h1 style="font-size:12px;">Submitting documents</h1>',
            css: { border: '#ccc solid 1px', background: '#f5f5f5' }
        });


        //$files: an array of files selected, each file has name, size, and type.
        var $files = $("#fileAttach")[0].files;
        var k = $files.length;
        for (var i = 0; i < $files.length; i++) {
            var $file = $files[i];
            (function (index) {
                $scope.upload[index] = $upload.upload({
                    url: "/upload", // webapi url
                    method: "POST",
                    data: { fileUploadObj: $scope.attachment_Details },
                    file: $file
                }).progress(function (evt) {
                    // get upload percentage
                    console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                }).success(function (data, status, headers, config) {
                    // file is uploaded successfully
                    k--;
                    if (k == 0) {

                        alert("Documents submitted successfully!");
                        var isMed = $('#ddlFileType').find(":selected").attr('data-id');
                        if (isMed == 1) {
                            $scope.AutoApprove(application_id);
                        }
                        $scope.ClearControls();
                    }

                }).error(function (data, status, headers, config) {
                    // file failed to upload
                    k--;
                    if (k == 0) {
                        $scope.ClearControls();
                        alert("Error occured while uploading ! Please try again");
                    }
                    $scope.ClearControls();
                });
            })(i);
        }
    }

    $scope.attachLeaveDocs = function () {


        $scope.IsFileUploadComplete = 0;
        $scope.IsAlertShown = 0;
        //Parameter Construction --
        var user_id = $("#hdfMemCode").val();
        var application_id = $("#txtLeaveId").val();

        var $files = $("#leaveAppAttachment")[0].files;
        var k = $files.length;


        if (k > 0) {
            var file_type = $("#ddlLeaveAppDocType").val();
            if (file_type == 0) {
                alert("Select the Attachment type !");
                return false;
            }
            var remarks = $("#txtLeaveAppAttachment_Remarks").val();
            if (remarks == 0) {
                alert("Enter the Remarks !");
                return false;
            }
        }
        else {
            $scope.IsFileUploadComplete = 1;
            return false;
        }
        $('#dialog').block({
            message: '<h1 style="font-size:12px;">Submitting Application</h1>',
            css: { border: '#ccc solid 1px', background: '#f5f5f5' }
        });

        var finyear = $("#hdfFinYear").val();
        //--
        $scope.attachment_Details = { user_id: user_id, application_id: application_id, file_type: file_type, remarks: remarks, fin_year: finyear }

        //$files: an array of files selected, each file has name, size, and type.
        var $files = $("#leaveAppAttachment")[0].files;
        var k = $files.length;
        for (var i = 0; i < $files.length; i++) {
            var $file = $files[i];
            (function (index) {
                $scope.upload[index] = $upload.upload({
                    url: "/upload", // webapi url
                    method: "POST",
                    data: { fileUploadObj: $scope.attachment_Details },
                    file: $file
                }).progress(function (evt) {
                    // get upload percentage
                    console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                }).success(function (data, status, headers, config) {
                    // file is uploaded successfully
                    k--;
                    if (k == 0) {
                        $scope.IsFileUploadComplete = 1;
                        if ($scope.IsAlertShown == 0) {
                            $scope.IsAlertShown = 1;
                            alert("Leave Application Submitted Successfully!");
                        }

                        var isMed = $('#ddlLeaveAppDocType').find(":selected").attr('data-id');
                        if (isMed == 1) {

                            $scope.AutoApprove(application_id);
                        }
                        $scope.ClearAttach();
                    }

                }).error(function (data, status, headers, config) {
                    // file failed to upload
                    k--;
                    if (k == 0) {
                        $scope.ClearAttach();
                        alert("Error occured while uploading ! Please try again");
                    }
                    $scope.ClearAttach();
                });
            })(i);
        }
    }

    //Exception Approval
    //Approve if the Document is medical related.
    $scope.AutoApprove = function (application_id) {
        $http.post('ApplyLeave.aspx/AutoApprove', { appId: application_id })
        .success(function (data, status) {
            if (data.d == true) {
                alert("Leave application approved!");
                $scope.GetAllLeaveDetails();
            }
        })
        .error(function (status) {
            alert("Error Occured!");
        });
    }
    //end
    $scope.ClearControls = function () {
        $("#ddlFileType").val('');
        $("#txtRemarks_Attach").val('');
        $("#fileAttach").val('');
        $('#div_Attachments').unblock();
        $("#upload_dialog").dialog("close");
    }

    $scope.ClearAttach = function () {
        $("#ddlFileType").val('');
        $("#txtRemarks_Attach").val('');
        $("#fileAttach").val('');
        $("#ddlLeaveAppDocType").val('');
        $("#txtLeaveAppAttachment_Remarks").val('');
        $("#leaveAppAttachment").val('');
        $('#dialog').unblock();
        $("#dialog").dialog("close");
    }

    $scope.abortUpload = function (index) {
        $scope.upload[index].abort();
    }
    $scope.DeleteDoc = function ($event) {
        var id = $event.currentTarget.id;
        var docs_id = $("#tdId_" + id.split('_')[1]).html();
        var c = confirm("Do you really want to delete?");
        if (c == false) {
            return false;
        }
        var App_Id = $("#hdfRowId").val();
        $http.post('ApplyLeave.aspx/DeleteDoc', { doc_id: docs_id })
        .success(function (data) {
            if (data.d = true) {
                alert("Document Deleted!");
                $scope.loadDocDet(App_Id);
            }
            else {
                alert("Error occured,Please try again!");
            }
        })
        .error(function (status) {
            alert("Error occured while deletion with status code :" + status);
        })
    }
    $scope.loadDocDet = function (application_id) {
        $http.post('ApplyLeave.aspx/getDocDetails', { app_id: application_id })
        .success(function (data) {
            $scope.docdet = data.d;
        })
        .error(function () {

        });
    }
    //Ends here


    $scope.SendMail = function (app_id) {
        $.blockUI();
        var MemCode = $("#hdfMemCode").val();
        $http.post('ApplyLeave.aspx/Sendmail', { app_id: app_id, mem_code: MemCode })
        .success(function (data) {
            $.unblockUI();
            if (data.d != -1) {
                alert("Mail Send Successfully!");
            }
        })
        .error(function (status) {
            $.unblockUI();
            alert("Error Occured while sending mail, please try again!");
        })
    }
})





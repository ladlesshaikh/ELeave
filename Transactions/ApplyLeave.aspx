<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="BizHRMS.Transactions.ApplyLeave" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<html>
<head>
    <title>BizHRMS | Apply Leave</title>
    <link href="../css/metro.min.css" rel="stylesheet" />
    <link href="../css/metro-schemes.min.css" rel="stylesheet" />
    <link href="../css/metro-rtl.min.css" rel="stylesheet" />
    <link href="../css/metro-responsive.min.css" rel="stylesheet" />
    <link href="../css/metro-icons.min.css" rel="stylesheet" />
    <link href="../css/custom.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/angular.min.js"></script>
    <script src="../js/metro.min.js"></script>
    <script src="../DataTable/jquery.Datatable.min.js"></script>
    <script src="../js/LeaveApplication.js"></script>
    <!--Attach Docs Script-->
    <script src="../js/script_attach_docs/vendor/angular-file-upload-shim.js"></script>
    <script src="../js/script_attach_docs/vendor/angular-file-upload.js"></script>
    <script src="../js/script_attach_docs/angular-cookies.js"></script>
    <script src="../js/script_attach_docs/angular-resource.js"></script>
    <script src="../js/script_attach_docs/angular-route.js"></script>
    <script src="../js/script_attach_docs/angular-sanitize.js"></script>
    <!--end-->
    <script src="../js/mdl_LeaveApplication.js"></script>
    <link href="../Selectator/Css/fm.selectator.jquery.css" rel="stylesheet" />
    <script src="../Selectator/Js/fm.selectator.jquery.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="../js/jqueryui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="../js/BlockUI.js"></script>
    <style>
        body {
            font-family: 'Segoe UI';
        }

        .calendar .day a {
            padding: 8px !important;
        }

        .calendar a {
            padding: 14px !important;
        }

        .HistoryOverview {
            background: #f5f5f5;
            margin-top: 10px !important;
            padding: 0px;
            padding: 10px;
            border: #ccc solid 1px;
        }

            .HistoryOverview h1 {
                font-size: 17px;
                margin: 0px;
                margin-bottom: 5px;
            }

        .tblHist tr td {
            padding: 5px !important;
            font-size: 13px;
        }
    </style>
</head>
<body data-ng-app="AppLeave" data-ng-controller="Ctrl_AppLeave" data-ng-init="FetchEmployeeDetails();GetAllLeaveDetails();GetLeaveHistory();GetLeaveHistoryDetails();FetchDocumentType();">
    <form runat="server">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div class="grid FilterContainer">
            <div class="row cells">
                <div class="cell">
                    <table>
                        <tr>
                            <td>
                                <button type="button" class="image-button primary" style="margin-top: 0px; font-size: 13px;" onclick="showDialog()">
                                    Add new<span class="icon mif-plus bg-darkCobalt"></span>
                                </button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <div class="grid ListContainer NoTopMargin">
            <div class="row cells12">
                <div class="cell colspan2 HistoryOverview">
                    <h1><span class="icon mif-history" style="margin-right: 5px; color: rgb(158, 158, 158);"></span>History</h1>
                    <div class="HistoryOverview" style="background: #fff; height: 380px; overflow-y: scroll;">
                        <table class="table bordered striped tblHist" data-ng-repeat="Hist in LeaveHist">
                            <tr>
                                <td style="font-weight: bold;" colspan="2">{{Hist.LeaveName}}</td>
                            </tr>
                            <tr>
                                <td style="width: 135px;">Brought Forward</td>
                                <td>{{Hist.Acc_Bal}}</td>
                            </tr>
                            <tr>
                                <td>Leave Taken</td>
                                <td>{{Hist.Leave_Availed}}</td>
                            </tr>
                            <tr>
                                <td>Encash Balance</td>
                                <td>{{Hist.Encash_Bal}}</td>
                            </tr>
                            <tr>
                                <td>Adjustment Balance</td>
                                <td>{{Hist.Adj_Bal}}</td>
                            </tr>
                            <tr>
                                <td>Current Balance</td>
                                <td>{{Hist.CB}}</td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="cell colspan10">
                    <table id="tblLst" class="table striped hovered cell-hovered border bordered">
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th></th>
                                <th>Leave type</th>
                                <th>From</th>
                                <th>To</th>
                                <th>Total</th>
                                <%--  <th>Leave type</th>--%>
                                <th>Reason for Leave</th>
                                <th>Type</th>
                                <th>Status</th>
                                <th>Reason for Rejection</th>
                                <th></th>
                                <th></th>

                                <th></th>
                                <th></th>
                                <th></th>
                                <th>Attachments</th>
                                <th>Leave Type</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div data-role="dialog" title="Leave Application" id="dialog" class="padding20 dialog" style="display: none">
            <div class="Popup_Header">
                <table class="Aligner">
                    <tr style="display: none;">
                        <td>Leave Id</td>
                        <td colspan="3">
                            <input type="text" id="txtLeaveId" style="width: 280px;" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">Employee</td>
                        <td colspan="3">
                            <select id="ddlEmloyee" name="select1" disabled="disabled">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>Leave</td>
                        <td style="width: 130px;">
                            <select id="ddlLeaveType" runat="server" style="width: 130px;">
                            </select>
                        </td>
                        <td style="width: 137px;">Applied on</td>
                        <td>
                            <input type="text" class="date" id="AppliedDate" />
                        </td>
                    </tr>
                    <tr>
                        <td>From</td>
                        <td>
                            <input type="text" class="date" id="FromDate" onchange="CalculateDiff()" /></td>
                        <td>To</td>
                        <td>
                            <input type="text" class="date" id="ToDate" onchange="CalculateDiff()" /></td>
                    </tr>
                    <tr>
                        <td>Reason</td>
                        <td colspan="3">
                            <textarea class="ReasonTA" id="txtReason" style="width: 100%;">

                    </textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 11px;">Leave type</td>
                        <%-- <td>
                            <label class="input-control checkbox small-check" style="margin-top: 0px !important">
                                <input type="checkbox" id="chkSpecialLeave" runat="server">
                                <span class="check"></span>
                                <span class="caption">Special Leave</span>
                            </label>
                        </td>--%>

                        <td>
                            <label class="input-control checkbox small-check" style="margin-top: 0px !important">
                                <input type="checkbox" id="chkHalfDayLeave" runat="server">
                                <span class="check"></span>
                                <span class="caption">Half day</span>
                            </label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <label class="input-control checkbox small-check" style="margin-top: 0px !important">
                                            <input type="checkbox" id="checkAM" runat="server">
                                            <span class="check"></span>
                                            <span class="caption">AM</span>
                                        </label>
                                    </td>
                                    <td>
                                        <label class="input-control checkbox small-check" style="margin-top: 0px !important">
                                            <input type="checkbox" id="checkPM" runat="server">
                                            <span class="check"></span>
                                            <span class="caption">PM</span>
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table style="font-size: 12px; width: 100%; margin-top: 30px;" id="tblUploadDoc">
                    <tr>
                        <td colspan="2" style="padding-bottom: 12px; color: rgb(0, 75, 110)">Supporting documents (if any)</td>
                    </tr>
                    <%--<tr>
                        <td style="width: 92px;">Type</td>
                        <td>
                            <select data-ng-change="CheckMedicalRec();" data-ng-model="attach.file_type" id="ddlLeaveAppDocType" runat="server" style="font-size: 12px; padding: 3px; margin-bottom: 5px;">
                                <option data-ng-repeat="DocLst in DocTypeLst" data-id="{{DocLst.Is_Medical_Type}}" value="{{DocLst.DocumentId}}">{{DocLst.DocumentName}}</option>
                            </select>
                        </td>
                    </tr>--%>
                    <tr>
                        <td></td>
                        <td style="color: #ff0000; font-size: 13px; padding-bottom: 7px;">{{Med_Status}}
                        </td>
                    </tr>
                    <%--<tr>
                        <td>Remarks</td>
                        <td>
                            <textarea id="txtLeaveAppAttachment_Remarks" style="width: 100%; margin-bottom: 5px;" data-ng-model="attach.remarks"></textarea>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>Attachments
                        </td>
                        <td>
                            <!--Files-->
                            <input type="file" data-ng-model="attach.upload" multiple id="leaveAppAttachment" />
                            <!--end-->
                        </td>
                    </tr>
                </table>
            </div>
            <table style="position: relative; left: 12px; font-size: 12px; top: 10px" id="tblTotLeave">
                <tr>
                    <td>Total Leave applied: </td>
                    <td id="tdTotalLeaves" style="padding-left: 5px; padding-right: 5px; font-weight: bold; color: chocolate;">0</td>
                    <td>Day(s)</td>
                </tr>
            </table>
            <input type="hidden" id="hdfRowId" />
            <input type="button" class="JQueryButton" value="Cancel" onclick="CloseDialog1();" style="float: right; margin-top: 5px; margin-left: 5px;" />
            <input type="button" class="JQueryButton" value="Submit" id="btnLeaveAppSave" data-ng-click="SaveLeave();attachLeaveDocs();" style="float: right; margin-top: 5px;" />
        </div>

        <!--New Leave Application-->
        <div id="Leave_Application_dialog" title="Leave Application">
        </div>
        <!--end-->


        <div data-role="dialog" title="Attach Supporting documents" id="upload_dialog" class="padding20 dialog width100" style="display: none; width: 100% !important;">

            <div id="div_Attachments" style="width: 100%; background: #f5f5f5; border: rgb(158, 158, 158) solid 1px; margin-bottom: 10px; padding: 5px;">
                <table style="font-size: 12px; width: 100%;">
                    <tr>
                        <td>Type</td>
                        <td>
                            <select data-ng-change="CheckMedicalRec();" data-ng-model="attach.file_type" id="ddlFileType" runat="server" style="font-size: 12px; padding: 3px; margin-bottom: 5px;">
                                <option data-ng-repeat="DocLst in DocTypeLst" data-id="{{DocLst.Is_Medical_Type}}" value="{{DocLst.DocumentId}}">{{DocLst.DocumentName}}</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="color: #ff0000; font-size: 13px; padding-bottom: 7px;">{{Med_Status}}
                        </td>
                    </tr>
                    <tr>
                        <td>Remarks</td>
                        <td>
                            <textarea id="txtRemarks_Attach" style="width: 100%; margin-bottom: 5px;" data-ng-model="attach.remarks"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>Attachments
                        </td>
                        <td>
                            <!--Files-->
                            <input type="file" data-ng-model="attach.upload" multiple id="fileAttach" />
                            <!--end-->
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" class="JQueryButton" value="Upload" data-ng-click="onFileSelect();" id="btnUpload_Docs" style="float: right; margin-top: 5px;" />
                        </td>
                    </tr>
                </table>
            </div>

            <hr />


            <!--Listing-->


            <table id="tblsDocsView" class="table striped hovered cell-hovered border bordered" style="width: 100%;">
                <thead>
                    <tr>
                        <th>File name</th>
                        <th>Remarks</th>
                        <th colspan="2">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr data-ng-repeat="doc in docdet">
                        <td id="{{'tdId_'+$index}}" style="display: none;">{{doc.DOCS_ID}}</td>
                        <td>{{doc.FILE_NAME}}</td>
                        <td>{{doc.REMARKS}}</td>
                        <td style="width: 30px;"><a target="_blank" href='../../Attachments/{{doc.FILE_PATH}}' class="a_view">View</a></td>
                        <td style="width: 30px;">
                            <button id="{{'btnDelete_'+$index}}" data-ng-click="DeleteDoc($event)">Delete</button></td>
                    </tr>
                </tbody>
            </table>
            <!--end-->
            <input type="hidden" id="hdfAppId" />
        </div>



        <div data-role="dialog" title="Confirm Action" id="Update_dialog" class="padding20 dialog" style="display: none">
            <p>Are you really want to cancel this leave ?</p>
            <input type="hidden" id="hdfRowIdUpdate" />
            <input type="button" class="JQueryButton" value="Cancel" onclick="CloseDialog();" style="float: right; margin-top: 5px; margin-left: 5px;" />
            <input type="button" class="JQueryButton" value="OK" data-ng-click="CancelLeave();" style="float: right; margin-top: 5px;" />
        </div>

        <input type="hidden" id="hdfMemCode" runat="server" />
        <input type="hidden" id="hdfFinYear" runat="server" />
        <input type="hidden" id="hdfDocUploadInLeave" runat="server" />
    </form>
</body>
</html>

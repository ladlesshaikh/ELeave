<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequest.aspx.cs" Inherits="BizHRMS.Transactions.LeaveRequest" %>

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
    <script src="../js/LeaveRequest.js"></script>
    <script src="../js/mdl_LeaveRequest.js"></script>
    <link href="../Selectator/Css/fm.selectator.jquery.css" rel="stylesheet" />
    <script src="../Selectator/Js/fm.selectator.jquery.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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

        #tblLst, #tblHistory {
            background: #fff;
            width: 100% !important;
        }
    </style>
</head>
<body data-ng-app="AppLeave" data-ng-controller="Ctrl_AppLeave" data-ng-init="GetAllLeaveDetails();GetHistoryLeaveDetails();">
    <form runat="server">
        <select runat="server" id="ddlMemLst" style="display:none;"></select>
        <uc1:Navigation runat="server" ID="Navigation" />
        <div class="grid FilterContainer">
            <div class="row cells">
                <div class="cell">
                </div>
            </div>
        </div>
        <input type="button" id="btn" style="display: none;" />
        <div class="grid ListContainer NoTopMargin">
            <div class="row">

                <div class="cell">
                    <div class="panel collapsible" data-role="panel">
                        <div class="heading">
                            <span class="icon ui-icon-note"></span>
                            <span class="title">New Requests</span>
                        </div>
                        <div style="display: block; padding-bottom: 35px;" class="content padding10">
                            <table id="tblLst" class="table striped hovered cell-hovered border bordered">
                                <thead>
                                    <tr>

                                        <th>Date</th>
                                        <th></th>
                                        <th>Employee</th>
                                        <th>Employee name</th>
                                        <th>Leave type</th>
                                        <th>From</th>
                                        <th>To</th>
                                        <th>Total Days</th>
                                        <th>Reasona for Leave</th>
                                   <%--     <th>Transferred from</th>--%>
                                     <%--   <th>Reason for Rejection</th>--%>
                                        <th>Attachments</th>
                                        <th>Status</th>
                                        <th></th>
                                        <th>Action</th>
                                        <th></th>

                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="cell">
                    <div class="panel collapsible" data-role="panel">
                        <div class="heading">
                            <span class="icon ui-icon-note"></span>
                            <span class="title">History</span>
                        </div>
                        <div style="display: block; padding-bottom: 35px;" class="content padding10">
                            <table id="tblHistory" class="table striped hovered cell-hovered border bordered">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Employee name</th>
                                        <th>Leave type</th>
                                        <th>From</th>
                                        <th>To</th>
                                        <th>Total Days</th>
                                        <th>Reason for Rejection</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div data-role="dialog" title="Transfer" id="transfer_dialog" class="padding20 dialog" style="display: none">
            <!--Transfer Leave Request-->
            <table style="width: 100%; font-size:12px;">
                <tr>
                    <td style="width:110px;">Transferred to</td>
                    <td>
                        <select id="ddlTransferAuth" onchange="HideROList()">
                            <option value="0">--Select--</option>
                            <option value="1">Reporting Officer</option>
                            <option value="2">Admin</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px;">Remarks</td>
                    <td>
                        <textarea id="txtTransferRemarks" style="width:100%;"></textarea>
                    </td>
                </tr>
            </table>
            
            <table class="table striped hovered cell-hovered border bordered" id="tblROLst" style="display:none;">
              <tr data-ng-repeat="ro in roList" data-ng-if="ro.IsAdmin=='0'">
                <td style="padding:2px;width:30px;vertical-align:middle;text-align:center;"><input type="radio" id="{{'rd_'+$index}}" onchange="SelectRO(this)"/></td>
                <td style="padding:2px; font-size:13px;">{{ro.Mem_Name}}</td>
              </tr>
            </table>

             <table class="table striped hovered cell-hovered border bordered" id="tblAdminLst" style="display:none;">
              <tr data-ng-repeat="ro in roList" data-ng-if="ro.IsAdmin=='1'">
                <td style="padding:2px;width:30px;vertical-align:middle;text-align:center;"><input type="radio" id="{{'rd_'+$index}}" onchange="SelectRO(this)"/></td>
                <td style="padding:2px; font-size:13px;">{{ro.Mem_Name}}</td>
              </tr>
            </table>


            <!--end-->
            <input type="button" class="JQueryButton" value="Transfer request" data-ng-click="TransferLeaveRequest();" style="float: right; position:absolute; bottom:10px;right:10px; margin-top: 5px;" />
        </div>
        <div data-role="dialog" title="Attachments" id="upload_dialog" class="padding20 dialog width100" style="display: none; width: 100% !important;">
            <!--Listing-->
            <table id="tblsDocsView" class="table striped hovered cell-hovered border bordered" style="width: 100%;">
                <thead>
                    <tr>
                        <th>File name</th>
                        <th>Remarks</th>
                        <th>View</th>
                    </tr>
                </thead>
                <tbody>
                    <tr data-ng-repeat="doc in docdet">
                        <td id="{{'tdId_'+$index}}" style="display: none;">{{doc.DOCS_ID}}</td>
                        <td>{{doc.FILE_NAME}}</td>
                        <td>{{doc.REMARKS}}</td>
                        <td style="width: 30px;"><a target="_blank" href='../Attachments/{{doc.FILE_PATH}}' class="a_view">View</a></td>
                    </tr>
                </tbody>
            </table>
            <!--end-->
            <input type="hidden" id="hdfAppId" />
        </div>

        <!--Cancel Remarks-->
        <div data-role="dialog" title="Reason for rejection" id="reject_leave_remarks" class="padding20 dialog width100" style="display: none; width: 100% !important;">
            <table style="width: 100%; font-size:12px;">
                <tr>
                    <td style="width:50px; vertical-align:top;">Reason</td>
                    <td>
                        <textarea id="txtRejectReason" style="width:100%; height:74px;"></textarea>
                    </td>
                </tr>
            </table>
            <input type="button" class="JQueryButton" value="Reject" data-ng-click="RejectLeave();" style="float: right; margin-top: 5px; margin-left:5px;" />
            <input type="button" class="JQueryButton" value="Cancel" data-ng-click="CloseRejectwin();" style="float: right; margin-top: 5px;" />
        </div>
        <!--End-->

        <input type="hidden" id="hdfMemCode" runat="server" />
        <input type="hidden" id="hdfTransferRowId" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="BizHRMS.Transactions.Leave.ApplyLeave" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<html>
<head>
    <title>BizHRMS | Apply Leave</title>
    <link href="../../css/metro.min.css" rel="stylesheet" />
    <link href="../../css/metro-schemes.min.css" rel="stylesheet" />
    <link href="../../css/metro-rtl.min.css" rel="stylesheet" />
    <link href="../../css/metro-responsive.min.css" rel="stylesheet" />
    <link href="../../css/metro-icons.min.css" rel="stylesheet" />
    <link href="../../css/custom.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/angular.min.js"></script>
    <script src="../../js/metro.min.js"></script>
    <script src="../../DataTable/jquery.Datatable.min.js"></script>
    <script src="../../js/LeaveApplication.js"></script>
    <script src="../../js/mdl_LeaveApplication.js"></script>
    <link href="../../Selectator/Css/fm.selectator.jquery.css" rel="stylesheet" />
    <script src="../../Selectator/Js/fm.selectator.jquery.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="../../js/BlockUI.js"></script>
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
<body data-ng-app="AppLeave" data-ng-controller="Ctrl_AppLeave" data-ng-init="FetchEmployeeDetails();GetAllLeaveDetails();GetLeaveHistory();GetLeaveHistoryDetails();">
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
                <div class="cell colspan3 HistoryOverview">
                    <h1><span class="icon mif-history" style="margin-right: 5px; color: rgb(158, 158, 158);"></span>History</h1>
                    <div class="HistoryOverview" style="background:#fff; height:380px;overflow-y:scroll;">
                        <table class="table bordered striped tblHist" data-ng-repeat="Hist in LeaveHist">
                            <tr>
                                <td style="font-weight: bold;" colspan="2">{{Hist.LeaveName}}</td>
                            </tr>
                            <tr>
                                <td style="width: 135px;">Account Balance</td>
                                <td>{{Hist.Acc_Bal}}</td>
                            </tr>
                            <tr>
                                <td>Leave Availed</td>
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
                <div class="cell colspan9">
                    <table id="tblLst" class="table striped hovered cell-hovered border bordered">
                        <thead>
                            <tr>

                                <th>Date</th>
                                <th></th>
                                <th>Leave type</th>
                                <th>From</th>
                                <th>To</th>
                                <th>Total Days</th>
                                <th>Reason</th>
                                <th>Status</th>
                                <th></th>
                                <th></th>

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

        <div data-role="dialog" title="Leave Application" id="dialog" class="padding20 dialog" style="display: none">
            <div class="Popup_Header">
                <table class="Aligner">
                    <tr>
                        <td style="width: 70px;">Employee</td>
                        <td colspan="3">
                            <select id="ddlEmloyee" name="select1">
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
                        <td>
                        <td>
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="chkSpecialLeave" runat="server">
                                <span class="check"></span>
                                <span class="caption">Special Leave</span>
                            </label>
                        </td>

                        <td colspan="2">
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="chkHalfDayLeave" runat="server">
                                <span class="check"></span>
                                <span class="caption">Half day Leave</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <table style="position: absolute; bottom: 13px; left: 13px; font-size: 12px;">
                <tr>
                    <td>Total Leave(s)</td>
                    <td id="tdTotalLeaves" style="padding-left: 5px; padding-right: 5px; font-weight: bold; color: chocolate;">0</td>
                    <td>Day(s)</td>
                </tr>
            </table>
            <input type="hidden" id="hdfRowId" />
            <input type="button" class="JQueryButton" value="Save" data-ng-click="SaveLeave();" style="float: right; margin-top: 5px;" />
        </div>


        <div data-role="dialog" title="Confirm Action" id="Update_dialog" class="padding20 dialog" style="display: none">
            <p>Are yo really want to cancel this leave ?</p>
            <input type="hidden" id="hdfRowIdUpdate" />
            <input type="button" class="JQueryButton" value="OK" data-ng-click="CancelLeave();" style="float: right; margin-top: 5px;" />
        </div>

        <input type="hidden" id="hdfMemCode" runat="server" />
    </form>
</body>
</html>

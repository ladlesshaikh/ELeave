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
            #tblLst,#tblHistory
            {
                background:#fff;
                width:100% !important;
            }
    </style>
</head>
<body data-ng-app="AppLeave" data-ng-controller="Ctrl_AppLeave" data-ng-init="GetAllLeaveDetails();GetHistoryLeaveDetails();">
    <form runat="server">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div class="grid FilterContainer">
            <div class="row cells">
                <div class="cell">
                </div>
            </div>
        </div>
        <input type="button" id="btn" style="display:none;" />
        <div class="grid ListContainer NoTopMargin">
            <div class="row">

                <div class="cell">
                    <div class="panel collapsible" data-role="panel">
                        <div class="heading">
                            <span class="icon ui-icon-note"></span>
                            <span class="title">New Requests</span>
                        </div>
                        <div style="display: block;padding-bottom:35px;" class="content padding10">
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
                                        <th>Reason</th>
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
                        <div style="display: block;padding-bottom:35px;" class="content padding10">
                            <table id="tblHistory" class="table striped hovered cell-hovered border bordered">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Employee name</th>
                                        <th>Leave type</th>
                                        <th>From</th>
                                        <th>To</th>
                                        <th>Total Days</th>
                                        <th>Reason</th>
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
        <input type="hidden" id="hdfMemCode" runat="server" />
    </form>
</body>
</html>

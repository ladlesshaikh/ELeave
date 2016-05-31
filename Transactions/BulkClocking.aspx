<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkClocking.aspx.cs" Inherits="BizHRMS.Transactions.BulkClocking" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<html>
<head>
    <title>BizHRMS | Ammend Clock by Date</title>
    <link href="../css/metro.min.css" rel="stylesheet" />
    <link href="../css/metro-schemes.min.css" rel="stylesheet" />
    <link href="../css/metro-responsive.min.css" rel="stylesheet" />
    <link href="../css/metro-icons.min.css" rel="stylesheet" />
    <link href="../css/custom.css" rel="stylesheet" />
    <link href="../Selectator/Css/fm.selectator.jquery.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/metro.min.js"></script>
    <script src="../DataTable/jquery.Datatable.min.js"></script>
    <script src="../Selectator/Js/fm.selectator.jquery.js"></script>
    <script src="../js/BulkClocking.js"></script>
    <script src="../js/angular.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="../JQUERY%20TimePicker/timepcker.js"></script>
    <link href="../JQUERY%20TimePicker/timepicker.css" rel="stylesheet" />
    <script src="../js/BlockUI.js"></script>
    <style>
        .dataTable .sorting_asc::after {
            display: none !important;
        }
        .dataTable .sorting_desc::after
        {
            display: none !important;
        }

        .selectator_element {
            min-width: 100% !important;
        }

        .cell table {
            width: 100% !important;
        }

        .selectator_chosen_item_left {
            width: 20px !important;
        }
    </style>
</head>
<body data-ng-app="ngBulkClocking" data-ng-controller="ngCtrlBulkClocking" data-ng-init="FetchDDLDataSource();">
    <uc1:Navigation runat="server" ID="Navigation" />
    <!--Filter Section-->
    <div class="grid FilterContainer">
        <div class="row cells7  NoMargin">
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 80px;">Branch</td>
                        <td>
                            <select id="ddlBranch"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 80px;">Grade</td>
                        <td>
                            <select id="ddlGrade"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 86px;">Designation</td>
                        <td>
                            <select id="ddlDesignation"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell">
                <table style="margin-top: 6px;">
                    <tr>
                        <td>Date</td>
                        <td>
                            <input type="text" class="date" id="txtDate" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row cells7 NoMargin">
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 80px;">Department</td>
                        <td>
                            <select id="ddlDepartment"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 80px;">Shift type</td>
                        <td>
                            <select id="ddlShiftType"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width: 86px;">Employee type</td>
                        <td>
                            <select id="ddlEmpType"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell">
                <button class="button success sleekBtn" data-ng-click="GetEmployee();" style="font-size: 13px; float: right; width: 130px; margin-right: 2px;" type="button">Load Employee</button>

            </div>
        </div>
    </div>
    <div class="grid HighLight_Panel" style="margin: 0px;">
        <div class="row cells8">
            <div class="cell colspan2" style="height: 28px;">
                <table>
                    <tr>
                        <td>
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="chk_new_clock" data-ng-model="Add_Clock"  data-ng-change="validate1()">
                                <span class="check"></span>
                                <span class="caption">Add new clocking</span>
                            </label>
                        </td>
                        <td>
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="chk_one_time_clock" data-ng-model="One_Time_Clock" data-ng-change="validate()">
                                <span class="check"></span>
                                <span class="caption">One time clocking</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <input type="text" data-ng-model="TotalRows" style="display:none;" />
                <table style="width: auto !important">
                    <tr>
                        <td style="font-size: 13px; width: 60px;">Clock In</td>
                        <td style="padding-right: 5px; padding-top:1px; vertical-align:top;">
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="ChkIsClockIn" disabled="disabled">
                                <span class="check"></span>
                            </label>
                        </td>
                        <td>
                            <input type="text" class="TimePickerText" id="txtClockIn" />
                        </td>
                        <td style="font-size: 13px; width: 70px; padding-left:10px;">Clock Out</td>
                        <td style="padding-right: 5px; padding-top:1px; vertical-align:top;">
                            <label class="input-control checkbox small-check">
                                <input type="checkbox" id="ChkIsClockOut" disabled="disabled">
                                <span class="check"></span>
                            </label>
                        </td>
                        <td>
                            <input type="text" class="TimePickerText" id="txtClockOut"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan3">
                <table>
                    <tr>
                        <td style="font-size: 13px; width: 60px">Reason</td>
                        <td>
                            <input type="text" id="txtReason" style="width: 100%;" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell">
                <button class="button success sleekBtn" data-ng-click="ProcessData();" style="font-size: 13px; float: left; height:25px !important;" type="button">Process</button>
            </div>
        </div>
    </div>
    <div class="grid ListContainer NoTopMargin">
        <div class="row">
            <div class="cell">
                <table id="tblLst" class="table striped hovered cell-hovered border bordered">
                    <thead>
                        <tr>
                            <th><input type="checkbox" id="chkBulkClockClearAll" data-ng-click="clearAllChk();" style="margin-left:4px;" data-ng-model="Chkall" /></th>
                            <th>Branch Id</th>
                            <th>Branch Name</th>
                            <th>Code</th>
                            <th>Enroll No.</th>
                            <th>Name</th>
                            <th>Type</th>
                            <th>Employee Type</th>
                            <th>Clock In</th>
                            <th>Clock Out</th>
                            <th>Process</th>
                            <th>Row_Id</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <input type="hidden" id="hdfProcessed" />
    <script src="../js/mdl_BulkClocking.js"></script>
</body>
</html>


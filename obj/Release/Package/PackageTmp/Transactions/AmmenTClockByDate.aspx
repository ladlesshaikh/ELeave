<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmmenTClockByDate.aspx.cs" Inherits="BizHRMS.Transactions.AmmenTClockByDate" %>

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
    <script src="../js/AmmentClockByDate.js"></script>
    <script src="../js/angular.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="../JQUERY%20TimePicker/timepcker.js"></script>
    <link href="../JQUERY%20TimePicker/timepicker.css" rel="stylesheet" />
    <script src="../js/BlockUI.js"></script>
    <style>
        .selectator_element
        {
            min-width:100% !important;
        }
        .cell table
        {
            width:100% !important;
        }
        .selectator_chosen_item_left
        {
            width:20px !important;
        }
    </style>
</head>
<body data-ng-app="ngAmmendClockByDate" data-ng-controller="ngAmmendClockByDateCtrl" data-ng-init="FetchDDLDataSource();">
    <uc1:Navigation runat="server" ID="Navigation" />
    <!--Filter Section-->
    <div class="grid FilterContainer">
        <div class="row cells7  NoMargin">
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
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:80px;">Branch</td>
                        <td>
                            <select id="ddlBranch"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:80px;">Grade</td>
                        <td>
                            <select id="ddlGrade"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:86px;">Designation</td>
                        <td>
                            <select id="ddlDesignation"></select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row cells7 NoMargin">
              <div class="cell">
                <table style="margin-top: 6px;">
                    <tr>
                        <td>
                            <label class="input-control checkbox small-check">
                                <input type="checkbox">
                                <span class="check"></span>
                                <span class="caption">Overwrite OT</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:80px;">Department</td>
                        <td>
                            <select id="ddlDepartment"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:80px;">Shift type</td>
                        <td>
                            <select id="ddlShiftType"></select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cell colspan2">
                <table style="margin-top: 6px;">
                    <tr>
                        <td style="width:86px;">Employee type</td>
                        <td>
                            <select id="ddlEmpType"></select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
           <div class="cell" style="float:right;">
                        <table style="width:auto !important; float:right;">
                    <tr>
                        <td>
                            <button class="button success sleekBtn" data-ng-click="GetGridData();" style="font-size: 13px;" type="button">Show</button></td>
                        <td>
                            <button class="button sleekBtn" data-ng-click="ProcessAttendance();" type="button" style="font-size: 13px;">Process OT</button></td>
                    </tr>
                </table>
                    </div>
        </div>
    </div>
    <div class="grid HighLight_Panel" style="margin: 0px;">
        <div class="row cells7">
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total Worked Hours</p>
                <p id="tdTHW" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total Shift Hours</p>
                <p id="tdTSH" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total Normal Hours</p>
                <p id="tdTNH" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total Break Hours</p>
                <p id="tdTBH" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total OT1 Hours</p>
                <p id="tdOT1" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total OT2 Hours</p>
                <p id="tdOT2" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
            <div class="cell">
                <p style="font-size: 12px; margin-top: 3px; margin-bottom: 3px; color: rgb(147, 147, 147);">Total Lost Hours</p>
                <p id="tdTLH" style="font-size: 15px; margin-top: 3px; margin-bottom: 3px; font-weight: 100;">00:00:00</p>
            </div>
        </div>
    </div>
    <!--End-->
    <div class="grid ListContainer NoTopMargin">
        <div class="row">
            <div class="cell">
                <table id="tblLst" class="table striped hovered cell-hovered border bordered">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Code</th>
                            <th>Name</th>
                            <th>Main Status</th>
                            <th>Shift</th>
                            <th>Shift Hour</th>
                            <th>Actual In</th>
                            <th>Actual Out</th>
                            <th>In</th>
                            <th>Out</th>
                            <th>Total Hours</th>
                            <th>Break</th>
                            <th>Worked</th>
                            <th>NT</th>
                            <th>OTH</th>
                            <th>OT1</th>
                            <th>OT2</th>
                            <th>Lost Hour</th>
                            <th>OTP</th>
                            <th>Reason</th>
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
    <div id="dialog" title="Edit Attendance Details" style="font-size: 15px !important; padding: 5px;">
        <div>
            <table class="tblAlign">
                <tr>
                    <td>Employee</td>
                    <td id="tdEmpId" style="width: 100px; display: none;"></td>
                    <td id="tdEmpName"></td>
                </tr>
            </table>
            <hr />
            <p class="TitlePara">Log Details</p>
            <table class="tblAlign">
                <tr>
                    <td>Log Date</td>
                    <td>
                        <input type="text" class="date" id="txtLogDate" disabled="disabled" />
                    </td>
                </tr>
                <tr>
                    <td>Clock In</td>
                    <td>
                        <input type="text" class="TimePickerText" id="txtClockIn" data-ng-model="ClockIn" /></td>
                </tr>
                <tr>
                    <td>Clock Out</td>
                    <td>
                        <input type="text" class="TimePickerText" id="txtClockOut" data-ng-model="ClockOut" /></td>
                </tr>
                <tr>
                    <td colspan="2">IN-OUT</td>
                    </tr>
            </table>
            <hr />
            <p class="TitlePara">Reason</p>
            <table class="tblAlign">
                <tr>
                    <td style="vertical-align: top;">Reason *</td>
                    <td>
                        <textarea class="ReasonTA" id="txtReason"></textarea>
                    </td>
                </tr>
            </table>
            <input type="hidden" id="hdfDTLRowId" />
            <hr />
            <input type="button" class="JQueryButton" value="Save" data-ng-click="Save();" style="float: right; margin-right: 10px;" />
        </div>
    </div>
    <script src="../js/mdl_AmmendClockByDate.js"></script>
</body>
</html>


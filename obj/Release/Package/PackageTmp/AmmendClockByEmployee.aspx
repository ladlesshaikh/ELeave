<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmmendClockByEmployee.aspx.cs" Inherits="BizHRMS.AmmendClockByEmployee" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<html>
<head>
    <title></title>
    <link href="css/metro-icons.min.css" rel="stylesheet" />
    <link href="css/metro-responsive.min.css" rel="stylesheet" />
    <link href="css/metro-rtl.min.css" rel="stylesheet" />
    <link href="css/metro-schemes.min.css" rel="stylesheet" />
    <link href="css/metro.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/angular.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="DataTable/jquery.Datatable.min.js"></script>
    <link href="TimePicker/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="TimePicker/jquery.datetimepicker.full.min.js"></script>
    <script>
        $(document).ready(function () {
            jQuery('.timepick').datetimepicker({
                datepicker: false,
                format: 'H:i'
            });
            $("#txtStartDate").datepicker();
            $("#txtEndDate").datepicker();
            var dialog = $("#dialog").dialog({
                autoOpen: false,
                height: 250,
                width: 350,
                modal: true,
                buttons: {
                    Cancel: function () {
                        dialog.dialog("close");
                    }
                }
            });
            /*var t = $("#tblLst").DataTable({
                "columnDefs": [ 
                   {
                       "targets": [ 19 ],
                       "visible": false,
                       "searchable": false
                   }
                ],
                "columns": [
                    { "width": "90px" },
                    { "width": "90px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    { "width": "50px" },
                    null,
                    null,
                    { "width": "20px" },
                    { "width": "30px" },
                ]
            });*/
        });
    </script>
    <style>
        .ui-dialog-content .ui-widget-content, ui-dialog {
            font-size: 12px !important;
            padding: 0px !important;
        }

        .ui-widget-content {
            font-size: 12px !important;
            padding: 5px !important;
        }

        .table tr th {
            color: #000 !important;
        }

        #tblLst_info {
            background: #fff !important;
            font-size: 11px !important;
            color: #000 !important;
        }

        table.dataTable thead th, table.dataTable thead td, table.dataTable tbody th, table.dataTable tbody td {
            border-bottom: 1px solid #111 !important;
            font-size: 12px !important;
            padding: 5px 14px !important;
            padding-left: 5px !important;
            padding-right: 5px !important;
        }

        body {
            font-family: 'Segoe UI' !important;
        }

        .SearchPanel {
            padding: 10px;
            background: #f5f5f5;
        }

        .title_Text {
            font-size: 17px;
            margin: 0px;
            margin-bottom: 10px;
            color: #0094ff;
        }

        .formDesigner tr td {
            font-size: 13px;
            padding-left: 5px;
        }

        .tab tr td {
            padding: 3px !important;
            border: #ccc solid 1px;
        }

        .formDesigner tr td:first-child {
            padding-left: 0px;
        }

        input[type="text"] {
            padding: 5px;
            border: solid 1px #dcdcdc;
            transition: box-shadow 0.3s, border 0.3s;
        }

            input[type="text"]:focus,
            input[type="text"].focus {
                border: solid 1px #707070;
                box-shadow: 0 0 5px 1px #969696;
            }

        .small-text {
            width: 90px;
        }

        #tblLst tr td {
            font-size: 14px;
        }

        #tblLst_paginate .paginate_button {
            padding: 3px 12px !important;
            font-size: 13px;
            width:auto;
            float:right;
        }
    </style>
</head>
<body>
    <uc1:Navigation runat="server" ID="Navigation" />
    <div class="grid" data-ng-app="ngAmmendEmployee" data-ng-controller="ngAmmendEmpCtrl">
        <div class="row" style="padding: 10px;">
            <div class="cell SearchPanel">
                <table class="formDesigner">
                    <tr>
                        <td>
                            <input type="text" data-ng-model="ProcessData.StartDate" class="style-1" id="txtStartDate" style="width:130px;" />
                        </td>
                        <td>To</td>
                        <td>
                            <input type="text" data-ng-model="ProcessData.EndDate" class="style-1" id="txtEndDate" style="width:130px;" />
                        </td>
                        <td>Employee</td>
                        <td style="padding-right: 10px;">
                            <select data-ng-model="ProcessData.EmpName" style="width: 350px; height: 30px; border-radius: 0px; border: #ccc solid 1px;" tabindex="2" id="ddlEmployee" runat="server">
                            </select>
                        </td>
                        <td>
                            <div data-role="group" data-group-type="one-state">
                                <button class="button" style="height: 31px;font-size:12px;">Bulk OT Process</button>
                                <button class="button" style="height: 31px;font-size:12px;">Overwrite OT</button>
                                <button class="button" style="height: 31px;font-size:12px;">Process OT while Loading</button>
                            </div>
                        </td>
                        <%--                        <td style="background: #ddd; padding-left: 8px;">Bulk OT Process:</td>
                        <td style="padding-right: 0px; background: #ddd;">
                            <label class="switch-original" style="margin-left: 0px;">
                                <input type="checkbox">
                                <span class="check"></span>
                            </label>
                        </td>
                        <td style="background: #D1D1D1; padding-left: 8px;">Overwrite OT:</td>
                        <td style="padding-right: 0px; background: #D1D1D1;">
                            <label class="switch-original" style="margin-left: 0px;">
                                <input type="checkbox">
                                <span class="check"></span>
                            </label>
                        </td>
                        <td style="background: #ddd; padding-left: 8px;">Process OT while Loading:</td>
                        <td style="padding-right: 0px; background: #ddd;">
                            <label class="switch-original" style="margin-left: 0px;">
                                <input type="checkbox">
                                <span class="check"></span>
                            </label>
                        </td>--%>
                    </tr>
                </table>
                <table class="formDesigner">
                    <tr>
                        <td>
                            <button class="button success slee" data-ng-click="ShowItems();" style="font-size: 13px;" type="button">Show</button></td>
                        <td>
                            <button class="button" type="button" style="font-size: 13px;">Process Overtime</button></td>
                    </tr>
                </table>
            </div>
            <table id="tblLst" class="table striped hovered cell-hovered border bordered" style="display:none;">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Day</th>
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
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
           
             <table id="tblLst1" class="table striped hovered cell-hovered border bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Day</th>
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
                    </tr>
                </thead>
                <tbody>
                    <tr data-ng-repeat="AD in AttendData">
                        <td></td>
                    </tr>
                </tbody>
            </table>
           

        </div>
    </div>
    <div id="dialog" title="Update Details" style="font-size: 12px;">
        <table class="formDesigner tab">
            <tr>
                <td style="font-size: 12px !important; width: 80px;">Member</td>
                <td id="trtdMemId"></td>
                <td id="trtdMemName" colspan="2"></td>
            </tr>
            <tr>
                <td style="font-size: 12px !important; width: 80px;">Log Date</td>
                <td id="tdLogDate" colspan="3"></td>
            </tr>
            <tr>
                <td style="font-size: 12px !important; width: 80px;">Clock In</td>
                <td style="width: 70px;">
                    <input type="text" class="timepick" style="width: 70px;" id="txtClockIn" /></td>
                <td style="font-size: 12px !important;">Clock Out</td>
                <td style="width: 70px;">
                    <input type="text" class="timepick" style="width: 70px;" id="txtClockOut" /></td>
            </tr>
            <tr>
                <td style="font-size: 12px !important; width: 80px;">Remarks</td>
                <td colspan="3">
                    <textarea style="width: 100%;"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        angular.module('ngAmmendEmployee', []).controller('ngAmmendEmpCtrl', function ($scope, $http) {
            $scope.ShowItems = function () {
                var StartDate = $scope.ProcessData.StartDate;
                var EndDate = $scope.ProcessData.EndDate;
                var EmpName = $("#ddlEmployee option:selected").text();
                $http.post('AmmendClockByEmployee.aspx/ShowData', { StartDate: StartDate, EndDate: EndDate, EmpName: EmpName }).success(function (data, status) {  $scope.BindDT(data.d); }).error(function (status) { });
            }
            $scope.ShowPopup = function () {
                alert("dcd");
            }
            $scope.BindDT = function (d) {
                var t = $("#tblLst").DataTable();
                for (var i = 0; i < d.length; i++) {
                    t.row.add([
                            d[i].Date,
                            d[i].Day,
                            d[i].Status,
                            d[i].shift,
                            d[i].ShiftHour,
                            d[i].ActualIn,
                            d[i].ActualOut,
                            d[i].In,
                            d[i].Out,
                            d[i].TotHours,
                            d[i].Break,
                            d[i].Worked,
                            d[i].NT,
                            d[i].OTH,
                            d[i].OT1,
                            d[i].OT2,
                            d[i].LastHour,
                            d[i].OTP,
                            d[i].Reason,
                            '<i style="display:none;">' + d[i].dtl_row_id + '</i>',
                            '<a id="id_' + i + '" style="cursor:pointer;" onclick=ShowPopup(this)>Edit</a>',
                            '<a style="cursor:pointer;">Delete</a>'
                    ]).draw(false);
                }
            }
        });
        function ShowPopup(sender) {
            $("#dialog").dialog("open");
            var id = sender.id;
            var split = id.split('_')[1];
            var table = $("#tblLst").DataTable();
            console.log(table.row(split).data());
            $("#trtdMemId").html(($("#ddlEmployee option:selected").text()).split('-')[0]);
            $("#trtdMemName").html($("#ddlEmployee").val());
            $("#tdLogDate").html(table.row(split).data()[0]);
            $("#txtClockIn").val(table.row(split).data()[7]);
            $("#txtClockOut").val(table.row(split).data()[8]);
        }
    </script>
</body>
</html>

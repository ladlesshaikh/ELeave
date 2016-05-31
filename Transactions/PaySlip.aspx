<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PaySlip.aspx.cs" Inherits="BizHRMS.Transactions.PaySlip" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<html>
<head>
    <title>BizHRMS | PaySlip</title>
    <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <link href="../css/metro-responsive.min.css" rel="stylesheet" />
    <link href="../css/metro-icons.min.css" rel="stylesheet" />
    <link href="../css/metro-rtl.min.css" rel="stylesheet" />
    <link href="../css/metro-schemes.min.css" rel="stylesheet" />
    <link href="../css/metro.min.css" rel="stylesheet" />
    <script src="../js/metro.min.js"></script>
    <script src="../js/angular.min.js"></script>
    <script src="../js/mdl_PaySlip.js"></script>
    <link href="../css/Payslip.css" rel="stylesheet" />
</head>
<body data-ng-app="mdl_PaySlip" data-ng-controller="ctrl_payslip" data-ng-init="GetPaySlip();">
    <uc1:Navigation runat="server" ID="Navigation" />
    <form runat="server">
        <div class="container">
            <div class="Receipt">
                <table style="font-size: 14px;">
                    <tr>
                        <td>Year</td>
                        <td style="padding-left: 5px;">
                            <select disabled="disabled" style="height: 35px;">
                                <option value="0">2015</option>
                            </select>
                        </td>
                        <td style="padding-left: 10px;">Month</td>
                        <td style="padding-left: 5px;">
                            <select id="ddl_month" runat="server" style="height: 35px;">
                                <option value="1">January</option>
                                <option value="2">February</option>
                                <option value="3">March</option>
                                <option value="4">April</option>
                                <option value="5">May</option>
                                <option value="6">June</option>
                                <option value="7">July</option>
                                <option value="8">August</option>
                                <option value="9">September</option>
                                <option value="10">October</option>
                                <option value="11">November</option>
                                <option value="12">December</option>
                            </select>
                        </td>
                        <td style="padding-left: 10px;">
                            <input type="button" value="Generate" data-ng-click="GetPaySlip();" /></td>
                    </tr>
                </table>
            </div>



            <div class="Receipt" id="RptPaper" runat="server" style="margin-top: 10px;display:none;">
                <div class="grid">
                    <div class="row cells3 SleekBottom">
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 100px;">Name </td>
                                    <td>
                                        <h1 class="member_name">{{MEMBER_NAME}}</h1>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px;">Designation </td>
                                    <td>
                                        <h1 class="member_name">{{DESIGNATION}}</h1>
                                    </td>
                                </tr>
                            </table>

                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 100px;">Branch</td>
                                    <td>
                                        <h1 class="member_name">{{BRANCH}}</h1>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px;">Department</td>
                                    <td>
                                        <h1 class="member_name">{{DEPARTMENT}}</h1>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td>Type</td>
                                    <td>
                                        <h1 class="member_name">{{TYPE}}</h1>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <hr />
                    <div class="row cells5">
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 38px;">Rate :</td>
                                    <td>{{RATE}}</td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 80px;">Hourly Rate :</td>
                                    <td>{{HRATE}}</td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td>Month :</td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 80px;">Pay Day(s) :</td>
                                    <td>{{PAYDAY}}</td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="tblDisplay">
                                <tr>
                                    <td style="width: 110px;">Payment Mode :</td>
                                    <td>{{PAYMODE}}</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="row cells2">
                        <div class="cell">
                            <table class="table striped hovered cell-hovered border bordered  sleekTable">
                                <tr>
                                    <th style="padding: 5px;" colspan="3">EARNINGS</th>
                                </tr>
                                <tr>
                                    <td>Description</td>
                                    <td>Actual Earning</td>
                                    <td>Amount</td>
                                </tr>
                                <tr data-ng-repeat="earn in ngEarning">
                                    <td>{{earn.Description}}</td>
                                    <td>{{earn.Actual_earning}}</td>
                                    <td>{{earn.Amount}}</td>
                                </tr>
                            </table>
                        </div>
                        <div class="cell">
                            <table class="table striped hovered cell-hovered border bordered  sleekTable">
                                <tr>
                                    <th style="padding: 5px;" colspan="3">DEDUCTION</th>
                                </tr>
                                <tr>
                                    <td>Description</td>
                                    <td>Actual Earning</td>
                                    <td>Amount</td>
                                </tr>
                                <tr data-ng-repeat="deduct in ngdeduct" runat="server" id="tdDEd">
                                    <td>{{deduct.Description}}</td>
                                    <td>{{deduct.Actual_earning}}</td>
                                    <td>{{deduct.Amount}}</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell">
                            <table class="table striped hovered cell-hovered border bordered  sleekTable">
                                <tr>
                                    <th style="padding: 5px; text-align: right;" colspan="3">Summary</th>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Earnings</td>
                                    <td style="width: 120px; text-align: right;">{{T_EARNING}}</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">Deduction</td>
                                    <td style="width: 120px; text-align: right;">{{T_DEDUCTION}}</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold;">Net Pay</td>
                                    <td style="width: 120px; text-align: right; font-weight: bold;">{{T_TOTAL}}</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <br />

            <div style="margin: 50px; display:none;" id="employeelistDiv" runat="server">
                <h1 style="margin-bottom: 5px; text-align: center;">Company Name</h1>
                <p style="margin-top: 0px; text-align: center;">Company Address PVT Ltd.</p>
                <hr />
                <h2 class="sleek" style="font-size: 20px; text-align: center; text-decoration: underline;">PaySlip</h2>
                <div style="border: #000 solid 1px; padding: 20px;">
                    <table style="width: 100%;">
                        <tr>
                            <td><b>Member name</b></td>
                            <td id="td_mem_name"></td>
                            <td><b>Branch</b></td>
                            <td id="td_branch"></td>
                            <td><b>Type</b></td>
                            <td>{{TYPE}}</td>
                        </tr>
                        <tr>
                            <td><b>Designation</b></td>
                            <td>{{DESIGNATION}}</td>
                            <td><b>Department</b></td>
                            <td>{{DEPARTMENT}}</td>
                        </tr>
                    </table>
                </div>
                <hr />
                <div style="border: #000 solid 1px; padding: 20px;">
                    <table style="width: 100%;">
                        <tr>
                            <td><b>Rate</b></td>
                            <td>{{RATE}}</td>
                            <td><b>Hourly Rate</b></td>
                            <td>{{HRATE}}</td>
                            <td><b>Month</b></td>
                            <td></td>
                            <td><b>Pay Day(s)</b></td>
                            <td>{{PAYDAY}}</td>
                            <td><b>Payment Mode</b></td>
                            <td>{{PAYMODE}}</td>
                        </tr>
                    </table>
                </div>
                <div style="border: #000 solid 1px; padding: 20px; width: 100%;">
                    <table border="1" style="width: 100%;" id="tbl">
                        <tr>
                            <td colspan="3" style="padding: 5px !important;"><b>&nbsp;Earnings</b></td>
                            <td colspan="3" style="padding: 5px !important;"><b>&nbsp;Deductions</b></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table border="1" style="width: 100%;">
                                    <tr data-ng-repeat="earn in ngEarning">
                                        <td style="padding: 5px !important; text-indent: 5px;">&nbsp;{{earn.Description}}</td>
                                        <td style="width: 100px; padding: 5px !important; text-indent: 5px;">&nbsp;{{earn.Actual_earning}}</td>
                                        <td style="width: 100px; padding: 5px !important; text-indent: 5px;">&nbsp;{{earn.Amount}}</td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="3">
                                <table border="1" style="width: 100%;">
                                    <tr data-ng-repeat="deduct in ngdeduct" runat="server" id="tdPrintDeduct">
                                        <td style="padding: 5px !important; text-indent: 5px;">&nbsp;{{deduct.Description}}</td>
                                        <td style="width: 100px; padding: 5px !important; text-indent: 5px;">&nbsp;{{deduct.Actual_earning}}</td>
                                        <td style="width: 100px; padding: 5px !important; text-indent: 5px;">&nbsp;{{deduct.Amount}}</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div style="display:none">
                       <asp:PlaceHolder ID="ControlContainer"
                       runat="server"/>
            </div>
      


            <asp:Button ID="Button1" runat="server"  Text="Print Payslip" OnClick="Button1_Click" />
        </div>
        <input type="hidden" runat="server" id="hdfPrint" />
    </form>
    <script>
        function SetValues()
        {
            return true;
        }
    </script>
</body>
</html>

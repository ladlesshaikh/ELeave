<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaySlip.aspx.cs" Inherits="BizHRMS.Transactions.PaySlip" %>

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
    <div class="container">
        <div class="Receipt">
            <div class="grid">
                <div class="row cells3 SleekBottom">
                    <div class="cell">
                        <table class="tblDisplay">
                            <tr>
                                <td style="width:100px;">Name </td>
                                <td>
                                    <h1 class="member_name">{{MEMBER_NAME}}</h1>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100px;">Designation </td>
                                <td>
                                    <h1 class="member_name">{{DESIGNATION}}</h1>
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div class="cell">
                        <table  class="tblDisplay">
                            <tr>
                                <td style="width:100px;">Branch</td>
                                <td>
                                    <h1 class="member_name">{{BRANCH}}</h1>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100px;">Department</td>
                                <td>
                                    <h1 class="member_name">{{DEPARTMENT}}</h1>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="cell">
                        <table  class="tblDisplay">
                            <tr>
                                <td>Type</td>
                                <td>
                                    <h1 class="member_name">{{TYPE}}</h1>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>

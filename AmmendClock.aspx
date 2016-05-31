<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmmendClock.aspx.cs" Inherits="BizHRMS.AmmendClock" %>

<%@ Register Src="~/UserControls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<html>
<head>
    <title>BizHRMS | Home</title>
    <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <link href="css/metro-responsive.min.css" rel="stylesheet" />
    <link href="css/metro-icons.min.css" rel="stylesheet" />
    <link href="css/metro-rtl.min.css" rel="stylesheet" />
    <link href="css/metro-schemes.min.css" rel="stylesheet" />
    <link href="css/metro.min.css" rel="stylesheet" />
    <script src="js/metro.min.js"></script>
    <link href="css/custom.css" rel="stylesheet" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(document).ready(function () {
            $("#txtStartDate").datepicker();
            $("#txtEndDate").datepicker();
        });
    </script>
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <form runat="server">
    <div class="grid" style="padding-left: 10px; padding-right: 10px;">
        <div class="row cells9">
            <div class="cell">
                <label>Start Date</label>
                <input type="text" class="cal" id="txtStartDate" runat="server" />
            </div>
            <div class="cell">
                <label>End Date</label>
                <input type="text" class="cal" id="txtEndDate" runat="server" />
            </div>
            <div class="cell colspan3">
                <label>Employee</label>
                <div class="input-control select" style="width: 100%;">
                    <select id="ddlEmployee" runat="server">
                    </select>
                </div>
            </div>
            <div class="cell colspan4">
                <table>
                    <tr>
                        <td style="padding-left:10px;">
                            <div class="cell" style="padding-top: 10px;">
                                <label class="input-control checkbox small-check">
                                    <input type="checkbox" id="chkBulkOT" runat="server">
                                    <span class="check"></span>
                                    <span class="caption">Bulk OT</span>
                                </label>
                            </div>
                        </td>
                        <td style="padding-left:10px;">
                            <div class="cell" style="padding-top: 10px;">
                                <label class="input-control checkbox small-check">
                                    <input type="checkbox" id="chkOverWriteOT" runat="server">
                                    <span class="check"></span>
                                    <span class="caption">Overwrite OT</span>
                                </label>
                            </div>
                        </td>
                        <td style="padding-left:10px;">
                            <div class="cell" style="padding-top: 10px;">
                                <label class="input-control checkbox small-check">
                                    <input type="checkbox" id="chkBulkOTProces" runat="server">
                                    <span class="check"></span>
                                    <span class="caption">Bulk OT While Loading</span>
                                </label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>



        </div>
        <div class="row cells9">
            <div class="cell">
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="row">
            <div class="cell">
           
<asp:GridView ID="dgvDisplyaSaveData" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
    </Columns>
</asp:GridView>

            </div>
        </div>
    </div>
        </form>
</body>
</html>

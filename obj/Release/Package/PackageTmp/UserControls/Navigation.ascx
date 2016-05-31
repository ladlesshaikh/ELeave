<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="BizHRMS.UserControls.Navigation" %>
<div class="app-bar" data-role="appbar">
    <a class="app-bar-element branding" style="font-size:22px;">Biz HRMS</a>
    <span class="app-bar-divider"></span>
    <ul class="app-bar-menu small-dropdown" runat="server" id="ul_Menu">
        <li data-flexorder="1" data-flexorderorigin="0"><a href="">Home</a></li>
        <li data-flexorder="2" data-flexorderorigin="1">
            <a class="dropdown-toggle">Transactions</a>
            <ul class="d-menu" data-role="dropdown">
                <li><a href="AmmentClockByEmp.aspx">Ammend Clock by Employee</a></li>
                <li><a href="AmmenTClockByDate.aspx">Ammend Clock by Date</a></li>
                <li><a href="LeaveRequest.aspx">Leave Request</a></li>
            </ul>
        </li>
    </ul>
    <div class="app-bar-element place-right">
   <ul class="app-bar-menu small-dropdown" >
        <li data-flexorder="1" data-flexorderorigin="1">
            <a style="font-size:13px !important;" class="dropdown-toggle" id="Account_Name" runat="server">Transactions</a>
            <ul class="d-menu" data-role="dropdown" style="right:2px;">
                <li id="li_Logout" runat="server"><a href="../Login.aspx">Logout</a></li>
            </ul>
        </li>
    </ul>
    </div>

    <div style="display: none;" class="app-bar-pullbutton automatic"></div>
    <div class="clearfix" style="width: 0;"></div>
    <nav style="display: none;" class="app-bar-pullmenu hidden flexstyle-app-bar-menu">
        <ul class="app-bar-pullmenubar hidden app-bar-menu"></ul>
    </nav>
</div>

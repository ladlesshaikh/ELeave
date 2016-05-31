<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="BizHRMS.UserControls.Header" %>
<div class="row" style="background:#fff; border-top:#0094ff solid 4px;">
    <div class="cell colspan3">
        <img src="../images/MasterLogo.PNG" style="width:115px;" />
        <h6 style="float:right;margin-right:10px;margin-top:12px;padding:10px;background:#f5f5f5; color:#000;" id="txtLoginDetails" runat="server"></h6>
    </div>
</div>
<div class="fluent-menu" data-role="fluentmenu" data-on-special-click="specialClick" style="padding:10px;">
    <ul class="tabs-holder">
        <li class="special"><a href="#">Home</a></li>
        <li class="active"><a href="#tab_home">Transactions</a></li>
        <li><a href="#tab_account">Account</a></li>
    </ul>

    <div class="tabs-content">
        <div style="display: block;" class="tab-panel" id="tab_home">
            <div class="tab-panel-group">
                <div class="tab-group-content">
                    <button class="fluent-big-button">
                        <img src="../images/TimeLarge.png" style="margin-bottom:10px;" />
                        Clock-AMD-EMP
                    </button>
                    <button class="fluent-big-button">
                        <img src="../images/PunchesLarge.png" style="margin-bottom:10px;" />
                        Clock Amt Date
                    </button>
                    <button class="fluent-big-button">
                        <img src="../images/ReviewLarge.png" style="margin-bottom:10px;" />
                        Leave Application
                    </button>
                </div>
                <div class="tab-group-caption">Attendance</div>
            </div>
        </div>
        <div style="display: block;" class="tab-panel" id="tab_account">
            <div class="tab-panel-group">
                <div class="tab-group-content">
                    <button class="fluent-big-button">
                        <img src="../images/logout.png" style="margin-bottom:10px;"/>
                        Logout
                    </button>
                </div>
                <div class="tab-group-caption">Account</div>
            </div>
        </div>
    </div>
</div>

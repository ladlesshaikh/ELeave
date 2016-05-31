<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BizHRMS.Login" %>
<html>
<head>
    <title>BizHRMS::Login</title>
    <link href="css/metro.min.css" rel="stylesheet" />
    <link href="css/metro-responsive.min.css" rel="stylesheet" />
    <link href="css/metro-icons.min.css" rel="stylesheet" />
    <link href="css/metro-rtl.min.css" rel="stylesheet" />
    <script src="js/metro.min.js"></script>
    <style>
        body {
            background: #f5f5f5;
        }

        .LoginContainer {
            background: #fff;
        }

        .LoginForm {
            background: #fff;
            padding: 5px;
            margin-bottom: 0px !important;
        }

        .downText {
            color: #ccc !important;
            padding-top: 2px;
        }

        .NoMargin {
            margin: 0px !important;
        }

        input[type=text], input[type=password] {
            font-size: 14px !important;
        }

        .shadow1 {
            border-left: #ccc solid 5px;
            border-bottom: #ccc solid 5px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="grid" style="padding-top: 130px;">
            <form runat="server">
                <div class="row cells6">
                    <div class="cell colspan4 offset1 shadow">
                        <div class="row cells2 LoginForm">
                            <div class="cell" style="padding: 20px;">
                                <img src="images/LoginPageSplash.PNG" />
                            </div>
                            <div class="cell">
                                <img src="images/MasterLogo.PNG" style="width: 95px; float: right;" />
                                <h3>Login</h3>
                                <h6 class="downText">Enter your Credentials</h6>
                                <div class="input-control modern text NoMargin">
                                    <input type="text" placeholder="Username" id="txtUsername" runat="server">
                                    <span class="label">Username</span>
                                    <span class="informer">Please enter your username</span>
                                    <span class="placeholder"></span>
                                </div>
                                <div class="input-control modern text NoMargin">
                                    <input type="password" placeholder="Password" id="txtPassword" runat="server">
                                    <span class="label">Password</span>
                                    <span class="informer">Please enter your username</span>
                                    <span class="placeholder"></span>
                                </div>
                                <asp:Button ID="LoginBtn" class="button primary" Style="display: block; margin-top: 30px;" runat="server" Text="Login" OnClick="LoginBtn_Click"></asp:Button>
                            <div id="Div_Fin_Year" runat="server" style="position:relative; top:10px; right:0px; padding:5px; background:#FBEDDA; font-size:12px; float:right;">Financial Year : 2015</div>
                            </div>
                        </div>
                        <div style="width:100%;padding:10px; display:none; background:#FBEDDA; color:#ff0000; font-size:12px;" id="Div_Alert_Box" runat="server">
                        </div>
                        <div style="width:100%;padding:10px; display:none; background:#f3ffee; color:#05810f; font-size:12px;" id="Div_Red_Succ" runat="server">
                        </div>
                        <div class="row cells2" style="background: #E7E7E7;">
                            <div class="cell" style="padding: 8px;">
                                <div class="input-control select" style="margin-top: 17px; width: 100%;">
                                    <label style="color: #9b59b6;">Branch</label>
                                    <select style="margin-top: 4px; font-size:12px;" runat="server" id="ddlBranch">
                                    </select>
                                </div>
                            </div>
                            <div class="cell" style="padding: 8px;">
                                <div class="input-control select" style="margin-top: 17px; width: 100%;">
                                    <label style="color: #9b59b6;">Month</label>
                                    <select style="margin-top: 4px; font-size:12px;" runat="server" id="ddlMonth">
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

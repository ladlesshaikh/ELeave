<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BizHRMS.Transactions.Home" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>


<html>
    <head>
        <title>BizHRMS | Home</title>
        <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
        <link href="../css/metro-responsive.min.css" rel="stylesheet" />
        <link href="../css/metro-icons.min.css" rel="stylesheet" />
        <link href="../css/metro-rtl.min.css" rel="stylesheet" />
        <link href="../css/metro-schemes.min.css" rel="stylesheet" />
        <link href="../css/metro.min.css" rel="stylesheet" />
        <script src="../js/metro.min.js"></script>
    </head>
    <body>
        <uc1:Navigation runat="server" ID="Navigation" />
    </body>
</html>

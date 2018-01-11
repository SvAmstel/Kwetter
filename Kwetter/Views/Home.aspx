<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Kwetter.Views.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnTest" runat="server" Text="TEST" OnClick="btnTest_Click" />
            <asp:Button ID="btnTest2" runat="server" Text="OPHALEN" OnClick="btnTest2_Click" />
            <asp:Label ID="lblNaam" runat="server" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Current Time: <asp:Label ID="currentTimeLabel" runat="server" /><br />
    Current Time Offset: <asp:Label ID="currentTimeOffsetLabel" runat="server" /><br />
    Current Utc Time: <asp:Label ID="currentUtcTimeLabel" runat="server" /><br />
    Current Calculated Time: <asp:Label ID="calculatedTimeLabel" runat="server" />
    </div>
    </form>
</body>
</html>

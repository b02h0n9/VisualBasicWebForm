<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PostBackTestPage.aspx.vb" Inherits="VisualBasicWebForm.PostBackTestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PostBack測試頁面</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="SubmitBtn" Text="送出" UseSubmitBehavior="false" runat="server" />
        <input type="button" id="JsChangeTextBtn" value="JavaScript更動輸入框文字" onclick="changeText();" />
        <input type="button" id="ClearSubmitBtn" value="清畫面" onclick="window.document.location.href = window.document.location.href;" />
        <div>
            <h3>(ServerControl) Enabled="false"</h3>
            <asp:TextBox ID="DisabledTextBox" Text="NothingChanged" Enabled="false" runat="server" />
            <asp:Label ID="DisabledTextBoxLabel" Text="" runat="server" />
            <br />

            <h3>(ServerControl) ReadOnly="true"</h3>
            <asp:TextBox ID="ReadOnlyTextBox" Text="NothingChanged" ReadOnly="true" runat="server" />
            <asp:Label ID="ReadOnlyTextBoxLabel" Text="" runat="server" />
            <br />

            <h3>(HtmlControl) readonly="readonly"</h3>
            <input type="text" id="ReadOnlyInputText" value="NothingChanged" readonly="readonly" runat="server" />
            <asp:Label ID="ReadOnlyInputTextLabel" Text="" runat="server" />
            <br />
        </div>
        <hr />
        <h2>解決辦法:</h2>
        <span>(以下皆為ServerControl)</span>
        <div>
            <h3>方法1: 利用 <span style="color: red;">onfocus="this.blur();"</span> 解決</h3>
            <asp:TextBox ID="BlurTextBox" Text="NothingChanged" onfocus="this.blur();" runat="server" />
            <asp:Label ID="BlurTextBoxLabel" Text="" runat="server" />
            <br /><br />

            <h3>方法2: 設置 ReadOnly="true"，並在後端使用 <span style="color: red;">Request.Form("MyTextBoxName")</span> 來取值</h3>
            <asp:TextBox ID="ReadOnlyRequestFormTextBox" Text="NothingChanged" ReadOnly="true" runat="server" />
            <asp:Label ID="ReadOnlyRequestFormTextBoxLabel" Text="" runat="server" />
            <br /><br />

            <h3>方法3: 在Page_Load設置只讀屬性 <span style="color: red;">MyTextBox.Attributes.Add("readonly", True)</span></h3>
            <asp:TextBox ID="PageLoadReadOnlyTextBox" Text="NothingChanged" runat="server" />
            <asp:Label ID="PageLoadReadOnlyTextBoxLabel" Text="" runat="server" />
            <br />
        </div>
    </form>
    <script>
        function changeText() {
            document.getElementById("<%=DisabledTextBox.ClientId%>").value = "Changed";
            document.getElementById("<%=ReadOnlyTextBox.ClientId%>").value = "Changed";
            document.getElementById("<%=ReadOnlyInputText.ClientId%>").value = "Changed";
            document.getElementById("<%=BlurTextBox.ClientId%>").value = "Changed";
            document.getElementById("<%=ReadOnlyRequestFormTextBox.ClientId%>").value = "Changed";
            document.getElementById("<%=PageLoadReadOnlyTextBox.ClientId%>").value = "Changed";
        }
    </script>
</body>
</html>

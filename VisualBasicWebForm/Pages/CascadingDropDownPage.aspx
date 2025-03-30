<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CascadingDropDownPage.aspx.vb" Inherits="VisualBasicWebForm.CascadingDropDownPage" %>
<%@ Register TagPrefix="cus" Namespace="VisualBasicWebForm.Controls" Assembly="VisualBasicWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>連動式下拉選單頁面</title>
</head>
<body>
    <form id="form1" runat="server">
        <!--畫面上一定要放置ScriptManager控制項-->
        <asp:ScriptManager runat="server" ID="ScriptManager1" />

        <asp:Button ID="SubmitBtn" Text="送出" UseSubmitBehavior="false" runat="server" />
        <input type="button" id="ClearSubmitBtn" value="清畫面" onclick="window.document.location.href = window.document.location.href;" />

        <div>
            <!--第一個下拉選單，記得把OnSelectedIndexChanged事件和AutoPostBack兩個屬性拿掉-->
            <cus:NoValidationDropDownList ID="DropDownList1" runat="server" />
            <!--ajaxToolkit為剛剛在Web.config裡的tagPrefix-->
            <!--TargetControlID為想要擴充連動下拉功能的目標控制項-->
            <!-- Category屬性必填，它的值是為了要和WebService溝通用，兩個下拉選單都取名同樣-->
            <ajaxToolkit:CascadingDropDown id="DropDownList1_CascadingDropDown"
                runat="server"
                category="MyCategoryDemo" targetcontrolid="DropDownList1"
                prompttext="請選擇部門"
                servicepath="~/Services/CascadingDropDownWebService.asmx" servicemethod="GetDepts">
            </ajaxToolkit:CascadingDropDown>

            <!--第二個下拉選單-->
            <cus:NoValidationDropDownList ID="DropDownList2" runat="server" />

            <!--ParentControlID很直覺地，就是哪個父控制項會連動到DropDownList2-->
            <!--  ServicePath、ServiceMethod 為Ajax呼叫的Url位置和執行的function-->
            <ajaxToolkit:CascadingDropDown id="DropDownList2_CascadingDropDown"
                runat="server" category="MyCategoryDemo"
                prompttext="請選擇員工" targetcontrolid="DropDownList2"
                servicepath="~/Services/CascadingDropDownWebService.asmx" servicemethod="GetEmps"
                parentcontrolid="DropDownList1">
            </ajaxToolkit:CascadingDropDown>
        </div>
        <div>
            DeptText: <asp:Label ID="DeptText" Text="" runat="server" /><br />
            DeptValue: <asp:Label ID="DeptValue" Text="" runat="server" /><br />
            <br />
            EmpText: <asp:Label ID="EmpText" Text="" runat="server" /><br />
            EmpValue: <asp:Label ID="EmpValue" Text="" runat="server" /><br />
        </div>
    </form>
</body>
</html>

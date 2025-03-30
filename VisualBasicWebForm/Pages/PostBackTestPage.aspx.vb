Imports Microsoft.Data.Edm.Library.Values
Imports System.Xml

Public Class PostBackTestPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '方法3: 在Page_Load設置只讀屬性
        If Not Page.IsPostBack Then
            PageLoadReadOnlyTextBox.Attributes.Add("readonly", True)
        End If
    End Sub

    Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitBtn.Click
        DisabledTextBoxLabel.Text = DisabledTextBox.Text
        ReadOnlyTextBoxLabel.Text = ReadOnlyTextBox.Text
        ReadOnlyInputTextLabel.Text = ReadOnlyInputText.Value

        '方法1: 不設置ReadOnly也不設置Disabled，利用 onfocus="this.blur(); 解決
        BlurTextBoxLabel.Text = BlurTextBox.Text

        '方法2: 設置ReadOnly，並在後端使用Request來取值
        ReadOnlyRequestFormTextBoxLabel.Text = Request.Form("ReadOnlyRequestFormTextBox").Trim()

        '方法3: 在Page_Load設置只讀屬性
        PageLoadReadOnlyTextBoxLabel.Text = PageLoadReadOnlyTextBox.Text
    End Sub
End Class
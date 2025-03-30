Imports AjaxControlToolkit
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class CascadingDropDownPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitBtn.Click
        DeptText.Text = DropDownList1.SelectedItem.Text
        DeptValue.Text = DropDownList1.SelectedValue
        EmpText.Text = DropDownList2.SelectedItem.Text
        EmpValue.Text = DropDownList2.SelectedValue
    End Sub
End Class
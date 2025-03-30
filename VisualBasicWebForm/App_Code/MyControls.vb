Namespace Controls
    ''' <summary>
    ''' 透過自訂控件的方式來忽略 (SupportsEventValidation)
    ''' 避免JS在DropDownList添加選項導致PostBack出現錯誤
    ''' </summary>
    ''' <remarks>
    ''' 來源: https://johanleino.wordpress.com/2011/04/09/revised-cascadingdropdown-causes-invalid-postback-or-callback-argument-error/
    ''' </remarks>
    Public Class NoValidationDropDownList
        Inherits System.Web.UI.WebControls.DropDownList

    End Class

    ''' <summary>
    ''' 覆寫 SelectedValue 屬性解決資料繫結的問題
    ''' </summary>
    ''' <remarks>
    ''' 來源: https://dotblogs.com.tw/jeff377/2008/10/23/5752
    ''' </remarks>
    Public Class TBDropDownList
        Inherits DropDownList

        ''' <summary>
        ''' 覆寫 SelectedValue 屬性。
        ''' </summary>
        Public Overrides Property SelectedValue() As String
            Get
                Return MyBase.SelectedValue
            End Get
            Set(ByVal value As String)
                Dim oItem As ListItem = Me.Items.FindByValue(value)
                If (oItem Is Nothing) Then
                    Me.SelectedIndex = -1 '當 Items 不存在時 
                    Exit Property
                Else
                    MyBase.SelectedValue = value
                End If
            End Set
        End Property

    End Class
End Namespace

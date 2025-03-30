Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports AjaxControlToolkit

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class CascadingDropDownWebService
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function HelloWorld() As String
        ' 驗證 Session，若失敗返回錯誤結構
        Dim errorResponse As ErrorResponse = ValidateSession()
        If errorResponse IsNot Nothing Then
            Return Nothing ' 若驗證失敗，返回錯誤結構
        End If

        Return "Hello World"
    End Function

    Public Class ErrorResponse
        Public Property Success As Boolean
        Public Property Message As String
        Public Property ErrorCode As Integer
    End Class

    ' 共通的驗證函式
    Private Function ValidateSession() As ErrorResponse
        If HttpContext.Current.Session("User") Is Nothing Then
            Throw New UnauthorizedAccessException("Access Denied")
            ' 如果Session失敗，返回錯誤結構
            'Return New ErrorResponse With {
            '    .Success = False,
            '    .Message = "Session expired or user not logged in.",
            '    .ErrorCode = 401 ' 可以設置為未授權錯誤
            '}
        End If
        ' Session驗證通過，返回空 (或可以返回其他成功訊息)
        Return Nothing
    End Function

    Public Class Department
        Public Property ID As Integer
        Public Property DeptName As String
    End Class

    Public Class Employee
        Public Property ID As Integer
        Public Property empName As String
        Public Property Dept_ID As Integer
    End Class


    <WebMethod()>
    Public Function GetDepts(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        ' Create a list of departments
        Dim depts As New List(Of Department) From {
        New Department() With {.ID = 1, .DeptName = "Developer"},
        New Department() With {.ID = 2, .DeptName = "PM"},
        New Department() With {.ID = 3, .DeptName = "Sales"}
    }

        ' Create a list of CascadingDropDownNameValue
        Dim values As New List(Of CascadingDropDownNameValue)

        ' Add departments to the values list
        values.AddRange(depts.Select(Function(m) New CascadingDropDownNameValue With {
            .name = m.DeptName,
            .value = m.ID.ToString()
        }))

        Return values.ToArray()
    End Function

    <WebMethod()>
    Public Function GetEmps(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        ' Create a list of employees
        Dim emps As New List(Of Employee) From {
            New Employee() With {.ID = 1, .empName = "Jack Dev", .Dept_ID = 1},
            New Employee() With {.ID = 2, .empName = "Tom Dev", .Dept_ID = 1},
            New Employee() With {.ID = 3, .empName = "Mary PM", .Dept_ID = 2},
            New Employee() With {.ID = 4, .empName = "Cherry PM", .Dept_ID = 2},
            New Employee() With {.ID = 5, .empName = "Will Sales", .Dept_ID = 3}
        }

        ' Create a list of CascadingDropDownNameValue
        Dim values As New List(Of CascadingDropDownNameValue)

        Try
            ' Parse the knownCategoryValues
            Dim kv As New StringDictionary()
            kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)

            ' Get the Dept_ID selected from the first dropdown
            Dim Dept_ID As Integer = Convert.ToInt32(kv(category))

            ' Filter employees based on Dept_ID
            Dim query = emps.Where(Function(m) m.Dept_ID = Dept_ID)

            ' Add the filtered employees to the values list
            values.AddRange(query.Select(Function(m) New CascadingDropDownNameValue With {
                .name = m.empName,
                .value = m.ID.ToString()
            }))
        Catch ex As Exception
            ' 不存在的選項
        End Try

        Return values.ToArray()
    End Function

End Class
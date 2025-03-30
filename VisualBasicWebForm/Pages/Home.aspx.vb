Imports System.IO

Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadPageLinks()
        End If
    End Sub

    Private Sub LoadPageLinks()
        Dim pagesFolder As String = Server.MapPath("~/Pages") ' 獲取 Pages 資料夾的實際路徑
        If Directory.Exists(pagesFolder) Then
            Dim files As String() = Directory.GetFiles(pagesFolder, "*.aspx") ' 取得所有 .aspx 頁面

            Dim html As String = ""
            For Each filePath As String In files
                Dim fileName As String = Path.GetFileName(filePath) ' 取得檔案名稱（例如 About.aspx）
                Dim pageUrl As String = ResolveUrl($"~/Pages/{fileName}") ' 確保路徑正確
                html &= $"<a class='link-button' href='{pageUrl}'>{fileName}</a><br/>"
            Next

            litPageLinks.Text = html ' 顯示頁面連結
        Else
            litPageLinks.Text = "<p>未找到 Pages 資料夾。</p>"
        End If
    End Sub
End Class
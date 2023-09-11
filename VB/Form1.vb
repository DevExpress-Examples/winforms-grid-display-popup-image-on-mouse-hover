Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel
Imports System.Drawing

Namespace WindowsFormsApplication85

    Public Partial Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            Dim list = New BindingList(Of Item)()
            For i As Integer = 0 To 5 - 1
                list.Add(New Item() With {.CategoryID = i, .CategoryName = "Test name" & i, .Description = "Description" & i, .Picture = imageCollection1.Images(i)})
            Next

            gridControl1.DataSource = list
        End Sub

        Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As ToolTipControllerGetActiveObjectInfoEventArgs)
            If e.SelectedControl IsNot gridControl1 Then Return
            Dim info As ToolTipControlInfo = Nothing
            Dim sTooltip1 As SuperToolTip = New SuperToolTip()
            Try
                Dim view As GridView = TryCast(gridControl1.GetViewAt(e.ControlMousePosition), GridView)
                If view Is Nothing Then Return
                Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
                If hi.HitTest = GridHitTest.RowIndicator Then
                    info = New ToolTipControlInfo(GridHitTest.RowIndicator.ToString() & hi.RowHandle.ToString(), "Row Handle: " & hi.RowHandle.ToString())
                    Dim titleItem1 As ToolTipTitleItem = New ToolTipTitleItem()
                    Dim im As Image = TryCast(view.GetRowCellValue(hi.RowHandle, "Picture"), Image)
                    Dim item1 As ToolTipItem = New ToolTipItem()
                    item1.Image = im
                    sTooltip1.Items.Add(item1)
                End If

                info = New ToolTipControlInfo(hi.HitTest, "")
                info.SuperTip = sTooltip1
            Finally
                e.Info = info
            End Try
        End Sub
    End Class

    Public Class Item

        Public Property CategoryID As Integer

        Public Property CategoryName As String

        Public Property Description As String

        Public Property Picture As Image
    End Class
End Namespace

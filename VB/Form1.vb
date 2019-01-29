Imports Microsoft.VisualBasic
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel
Imports System.Drawing

Namespace WindowsFormsApplication85
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()

			Dim list = New BindingList(Of Item)()
			For i As Integer = 0 To 4
				list.Add(New Item() With {.CategoryID = i, .CategoryName = "Test name" & i, .Description = "Description" & i, .Picture = imageCollection1.Images(i)})
			Next i
			gridControl1.DataSource = list
		End Sub

		Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo
			If e.SelectedControl IsNot gridControl1 Then
				Return
			End If
			Dim info As ToolTipControlInfo = Nothing
			Dim sTooltip1 As New SuperToolTip()
			Try
				Dim view As GridView = TryCast(gridControl1.GetViewAt(e.ControlMousePosition), GridView)
				If view Is Nothing Then
					Return
				End If
				Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
				If hi.HitTest = GridHitTest.RowIndicator Then
					info = New ToolTipControlInfo(GridHitTest.RowIndicator.ToString() & hi.RowHandle.ToString(), "Row Handle: " & hi.RowHandle.ToString())
					Dim titleItem1 As New ToolTipTitleItem()
					Dim im As Image = TryCast(view.GetRowCellValue(hi.RowHandle, "Picture"), Image)
					Dim item1 As New ToolTipItem()
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
		Private privateCategoryID As Integer
		Public Property CategoryID() As Integer
			Get
				Return privateCategoryID
			End Get
			Set(ByVal value As Integer)
				privateCategoryID = value
			End Set
		End Property
		Private privateCategoryName As String
		Public Property CategoryName() As String
			Get
				Return privateCategoryName
			End Get
			Set(ByVal value As String)
				privateCategoryName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privatePicture As Image
		Public Property Picture() As Image
			Get
				Return privatePicture
			End Get
			Set(ByVal value As Image)
				privatePicture = value
			End Set
		End Property
	End Class
End Namespace

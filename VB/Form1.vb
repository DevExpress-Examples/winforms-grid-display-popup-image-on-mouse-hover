Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.IO

Namespace WindowsFormsApplication85
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
			'this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);
			nwindDataSet.ReadXml("..\..\Categories")

		End Sub

		Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo
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
				'if (hi.InRowCell)
				'{
				'    info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), GetCellHintText(view, hi.RowHandle, hi.Column));
				'    return;
				'}
				'if (hi.Column != null)
				'{
				'    info = new ToolTipControlInfo(hi.Column, GetColumnHintText(hi.Column));
				'    return;
				'}
				'if (hi.HitTest == GridHitTest.GroupPanel)
				'{
				'    info = new ToolTipControlInfo(hi.HitTest, "Group panel");
				'    return;
				'}

				If hi.HitTest = GridHitTest.RowIndicator Then
					info = New ToolTipControlInfo(GridHitTest.RowIndicator.ToString() & hi.RowHandle.ToString(), "Row Handle: " & hi.RowHandle.ToString())
					Dim titleItem1 As New ToolTipTitleItem()
					Dim cellIm() As Byte = TryCast(view.GetRowCellValue(hi.RowHandle, "Picture"), Byte())
					Dim im As Image = Nothing
					If cellIm IsNot Nothing Then
						Dim ms As New MemoryStream(cellIm)

						im = Image.FromStream(ms)
					End If

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

		Private Function GetColumnHintText(ByVal gridColumn As DevExpress.XtraGrid.Columns.GridColumn) As String
			Throw New NotImplementedException()
		End Function

		Private Function GetCellHintText(ByVal view As GridView, ByVal p As Integer, ByVal gridColumn As DevExpress.XtraGrid.Columns.GridColumn) As String
			Throw New NotImplementedException()
		End Function

	End Class
End Namespace

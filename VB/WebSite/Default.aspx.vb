Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page
	' Data object 

	Private Class GridDataItem
		Private privateID As Int32
		Public Property ID() As Int32
			Get
				Return privateID
			End Get
			Set(ByVal value As Int32)
				privateID = value
			End Set
		End Property
		Private privateTime As TimeSpan
		Public Property Time() As TimeSpan
			Get
				Return privateTime
			End Get
			Set(ByVal value As TimeSpan)
				privateTime = value
			End Set
		End Property
	End Class

	' Runtime Data-binding 

	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		Grid.DataSource = TempData
	End Sub

	Protected Overrides Sub OnLoad(ByVal e As EventArgs)
		MyBase.OnLoad(e)
		Grid.DataBind()
	End Sub

	' Custom Updating action 

	Protected Sub Grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		Dim item = TempData.Where(Function(i) i.ID = Convert.ToInt32(e.Keys("ID"))).First()

		item.Time = CType(e.NewValues("Time"), TimeSpan)

		e.Cancel = True
		Grid.CancelEdit()
	End Sub

	' Custom Inserting action 

	Protected Sub Grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim item = TempData.OrderBy(Function(i) i.ID).Last()

		Dim newItem As GridDataItem = New GridDataItem With {.ID = item.ID + 1, .Time = CType(e.NewValues("Time"), TimeSpan)}

		TempData.Add(newItem)

		e.Cancel = True
		Grid.CancelEdit()
	End Sub

	' Parse String object of the "Time" text box 

	Protected Sub Grid_ParseValue(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxParseValueEventArgs)
		If (Not Grid.IsNewRowEditing) AndAlso e.FieldName = "Time" Then
			e.Value = TimeSpanFromString(e.Value)
		End If
	End Sub

	' Convert from TimeSpan to a proper Mask format 

	Protected Sub Grid_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
		If e.Column.FieldName = "Time" Then
			e.Editor.Value = StringFromTimeSpan(e.Value)
		End If
	End Sub

	' Helper methods 

	Private Function TimeSpanFromString(ByVal value As Object) As TimeSpan
		If value Is Nothing OrElse String.IsNullOrEmpty(CType(value, String)) Then
			Return TimeSpan.Zero
		End If

		Return TimeSpan.Parse(CType(value, String))
	End Function

	Private Function StringFromTimeSpan(ByVal value As Object) As String
		If value Is Nothing Then
			Return String.Empty
		End If

		Dim time As TimeSpan = CType(value, TimeSpan)

		If time.Days <> 0 Then
			Return time.ToString("c")
		End If

		Dim str As String = time.ToString("hh\:mm\:ss")

		If time < TimeSpan.Zero Then
			Return String.Format("-0.{0}", str)
		Else
			Return String.Format("0.{0}", str)
		End If
	End Function

	' Fake data source 

	Private ReadOnly Property TempData() As List(Of GridDataItem)
		Get
			Const key As String = "(some guid)"
			If Session(key) Is Nothing Then

				Dim lst As New List(Of GridDataItem)()

				' Initialization with some values 

				For i As Int32 = -5 To 5
					lst.Add(New GridDataItem With {.ID = i, .Time = New TimeSpan(i, i, i, i)})
				Next i

				Session(key) = lst
			End If
			Return CType(Session(key), List(Of GridDataItem))
		End Get
	End Property
End Class
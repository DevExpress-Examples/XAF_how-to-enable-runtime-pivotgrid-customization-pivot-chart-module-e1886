Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.PivotChart.Win
Imports DevExpress.ExpressApp
Imports System.Drawing
Imports DevExpress.ExpressApp.Model

Namespace PivotGridCustomization.Module.Win
                Public Interface IModelPivotGridCustomizationItem
	   Inherits IModelDetailViewItem
                End Interface
	<DetailViewItemName("PivotGridCustomizationItem")> _
	Public Class PivotGridCustomizationDetailViewItem
		Inherits ViewItem
		Private analysisEditor As AnalysisEditorWin
		Private showColumnGrandTotalCheckEdit As CheckEdit
		Private showRowGrandTotalCheckEdit As CheckEdit

		Private Sub SubscribeEditorEvents()
			If analysisEditor IsNot Nothing Then
				AddHandler analysisEditor.PivotGridSettingsLoaded, AddressOf AnalysisEditor_PivotGridSettingsLoaded
				AddHandler analysisEditor.IsDataSourceReadyChanged, AddressOf AnalysisEditor_IsDataSourceReadyChanged
			End If
		End Sub
		Private Sub UnsubscribeEditorEvents()
			If analysisEditor IsNot Nothing Then
				RemoveHandler analysisEditor.PivotGridSettingsLoaded, AddressOf AnalysisEditor_PivotGridSettingsLoaded
				RemoveHandler analysisEditor.IsDataSourceReadyChanged, AddressOf AnalysisEditor_IsDataSourceReadyChanged
			End If
		End Sub
		Private Sub AnalysisEditor_IsDataSourceReadyChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim isEnabled As Boolean = analysisEditor.IsDataSourceReady
			showRowGrandTotalCheckEdit.Enabled = isEnabled
			showColumnGrandTotalCheckEdit.Enabled = isEnabled
			If (Not isEnabled) Then
				showRowGrandTotalCheckEdit.Checked = False
				showColumnGrandTotalCheckEdit.Checked = False
			End If
		End Sub
		Private Sub AnalysisEditor_PivotGridSettingsLoaded(ByVal sender As Object, ByVal e As EventArgs)
			showRowGrandTotalCheckEdit.Checked = analysisEditor.Control.PivotGrid.OptionsView.ShowRowGrandTotals
			showColumnGrandTotalCheckEdit.Checked = analysisEditor.Control.PivotGrid.OptionsView.ShowColumnGrandTotals
		End Sub
		Private Sub showRowGrandTotalCheckEdit_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			If analysisEditor IsNot Nothing AndAlso analysisEditor.Control IsNot Nothing Then
				analysisEditor.Control.PivotGrid.OptionsView.ShowRowGrandTotals = showRowGrandTotalCheckEdit.Checked
			End If
		End Sub
		Private Sub showColumnGrandTotalCheckEdit_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			If analysisEditor IsNot Nothing AndAlso analysisEditor.Control IsNot Nothing Then
				analysisEditor.Control.PivotGrid.OptionsView.ShowColumnGrandTotals = showColumnGrandTotalCheckEdit.Checked
			End If
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			Dim control As New XtraUserControl()

			showRowGrandTotalCheckEdit = New CheckEdit()
			showRowGrandTotalCheckEdit.Properties.Caption = "Show Row Grand Total"
			showRowGrandTotalCheckEdit.Location = New Point(0, 0)
			showRowGrandTotalCheckEdit.Size = showRowGrandTotalCheckEdit.CalcBestSize()
			showRowGrandTotalCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top
			showRowGrandTotalCheckEdit.CalcBestSize()
			showRowGrandTotalCheckEdit.Enabled = False
			AddHandler showRowGrandTotalCheckEdit.CheckedChanged, AddressOf showRowGrandTotalCheckEdit_CheckedChanged

			showColumnGrandTotalCheckEdit = New CheckEdit()
			showColumnGrandTotalCheckEdit.Properties.Caption = "Show Column Grand Total"
			showColumnGrandTotalCheckEdit.Location = New Point(0, 20)
			showColumnGrandTotalCheckEdit.Size = showColumnGrandTotalCheckEdit.CalcBestSize()
			showColumnGrandTotalCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top
			showColumnGrandTotalCheckEdit.CalcBestSize()
			showColumnGrandTotalCheckEdit.Enabled = False
			AddHandler showColumnGrandTotalCheckEdit.CheckedChanged, AddressOf showColumnGrandTotalCheckEdit_CheckedChanged

			control.Controls.Add(showColumnGrandTotalCheckEdit)
			control.Controls.Add(showRowGrandTotalCheckEdit)

			control.Size = control.GetPreferredSize(New Size())
			control.MaximumSize = New Size(0, control.Size.Height)
			control.MinimumSize = New Size(0, control.Size.Height)

			Return control
		End Function
                                Public Sub New(ByVal classType As Type, ByVal id As String)
                                	MyBase.New(classType, id)
                                End Sub
		Public Sub New(ByVal model As IModelPivotGridCustomizationItem, ByVal classType As Type)
			MyBase.New(classType, model.Id)
		End Sub
		Public Sub SetAnalysisEditor(ByVal analysisEditor As AnalysisEditorWin)
			UnsubscribeEditorEvents()
			Me.analysisEditor = analysisEditor
			SubscribeEditorEvents()
		End Sub
	End Class
End Namespace

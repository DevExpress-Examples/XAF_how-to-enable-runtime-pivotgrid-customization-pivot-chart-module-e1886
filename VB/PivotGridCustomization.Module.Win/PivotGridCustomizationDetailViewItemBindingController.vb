Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.PivotChart
Imports DevExpress.ExpressApp.PivotChart.Win

Namespace PivotGridCustomization.Module.Win
	Public Class PivotGridCustomizationDetailViewItemBindingController
		Inherits AnalysisViewControllerBase
		Private Function FindPivotGridCustomizationItem() As PivotGridCustomizationDetailViewItem
			Dim view As DetailView = CType(Me.View, DetailView)
			Dim items As IList(Of PivotGridCustomizationDetailViewItem) = view.GetItems(Of PivotGridCustomizationDetailViewItem)()
			If items.Count <> 0 Then
				Return items(0)
			End If
			Return Nothing
		End Function
		Private Sub BindPivotGridCustomizationItemToEditor(ByVal analysisEditor As AnalysisEditorWin)
			Dim customizationItem As PivotGridCustomizationDetailViewItem = FindPivotGridCustomizationItem()
			If customizationItem IsNot Nothing Then
				customizationItem.SetAnalysisEditor(analysisEditor)
			End If
		End Sub
		Protected Overrides Sub OnAnalysisControlCreated()
			MyBase.OnAnalysisControlCreated()
			BindPivotGridCustomizationItemToEditor(CType(analysisEditor, AnalysisEditorWin))
		End Sub
		Protected Overrides Sub OnDeactivating()
			BindPivotGridCustomizationItemToEditor(Nothing)
			MyBase.OnDeactivating()
		End Sub
	End Class
End Namespace

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors

Namespace PivotGridCustomization.Module.Win
	<ToolboxItemFilter("Xaf.Platform.Win")> _
	Public NotInheritable Partial Class PivotGridCustomizationWindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
	Protected Overrides Sub RegisterEditorDescriptors(ByVal editorDescriptors As List(Of DevExpress.ExpressApp.Editors.EditorDescriptor))
			MyBase.RegisterEditorDescriptors(editorDescriptors)
			editorDescriptors.Add(New DetailViewItemDescriptor(New DetailViewItemRegistration(GetType(IModelPivotGridCustomizationItem), GetType(PivotGridCustomizationDetailViewItem), True)))
	End Sub

	End Class
End Namespace

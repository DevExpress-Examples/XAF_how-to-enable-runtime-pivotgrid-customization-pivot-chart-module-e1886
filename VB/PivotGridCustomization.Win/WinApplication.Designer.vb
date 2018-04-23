Imports Microsoft.VisualBasic
Imports System
Namespace PivotGridCustomization.Win
	Partial Public Class PivotGridCustomizationWindowsFormsApplication
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
			Me.module3 = New PivotGridCustomization.Module.PivotGridCustomizationModule()
			Me.module4 = New PivotGridCustomization.Module.Win.PivotGridCustomizationWindowsFormsModule()
			Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
			Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
			Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
			Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
			Me.pivotChartModuleBase1 = New DevExpress.ExpressApp.PivotChart.PivotChartModuleBase()
			Me.pivotChartWindowsFormsModule1 = New DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' module1
			' 
			Me.module1.AdditionalBusinessClasses.Add(GetType(DevExpress.Xpo.XPObjectType))
			' 
			' module4
			' 
			Me.module4.AdditionalBusinessClasses.Add(GetType(DevExpress.Persistent.BaseImpl.Analysis))
			' 
			' module5
			' 
			Me.module5.AllowValidationDetailsAccess = True
			' 
			' sqlConnection1
			' 
			Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=PivotGridCustomization;Integrated Security=SS" & "PI;Pooling=false"
			Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
			' 
			' pivotChartModuleBase1
			' 
			Me.pivotChartModuleBase1.ShowAdditionalNavigation = False
			' 
			' PivotGridCustomizationWindowsFormsApplication
			' 
			Me.ApplicationName = "PivotGridCustomization"
			Me.Connection = Me.sqlConnection1
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module6)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.pivotChartModuleBase1)
			Me.Modules.Add(Me.pivotChartWindowsFormsModule1)
			Me.Modules.Add(Me.module4)
			Me.Modules.Add(Me.module5)
			Me.Modules.Add(Me.module7)
			Me.Modules.Add(Me.securityModule1)
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.PivotGridCustomizationWindowsFormsApplication_DatabaseVersionMismatch);
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
		Private module3 As PivotGridCustomization.Module.PivotGridCustomizationModule
		Private module4 As PivotGridCustomization.Module.Win.PivotGridCustomizationWindowsFormsModule
		Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
		Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
		Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
		Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
		Private sqlConnection1 As System.Data.SqlClient.SqlConnection
		Private pivotChartModuleBase1 As DevExpress.ExpressApp.PivotChart.PivotChartModuleBase
		Private pivotChartWindowsFormsModule1 As DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule
	End Class
End Namespace

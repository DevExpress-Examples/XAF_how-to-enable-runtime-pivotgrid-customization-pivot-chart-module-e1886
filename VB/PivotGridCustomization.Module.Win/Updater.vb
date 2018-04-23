Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.PivotChart
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.PivotChart.Win

Namespace PivotGridCustomization.Module.Win
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Private Sub CreateTestAnalysis()
			Dim testAnalysis As Analysis = ObjectSpace.FindObject(Of Analysis)(CriteriaOperator.Parse("Name='Test Analysis'"))
			If testAnalysis Is Nothing Then
				testAnalysis = ObjectSpace.CreateObject(Of Analysis)()
				testAnalysis.Name = "Test Analysis"
				testAnalysis.ObjectTypeName = GetType(TestObject).FullName
				Using control As New AnalysisControlWin()
					control.DataSource = New AnalysisDataSource(testAnalysis, New XPCollection(Of TestObject)(testAnalysis.Session))
					control.Fields("Name").Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
					control.Fields("Value").Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
					control.Fields("AnotherValue").Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
					PivotGridSettingsHelper.SavePivotGridSettings(New PivotGridControlSettingsStore((control.PivotGrid)), testAnalysis)
				End Using
				testAnalysis.Save()
			End If
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			CreateTestAnalysis()
		End Sub
	End Class
End Namespace

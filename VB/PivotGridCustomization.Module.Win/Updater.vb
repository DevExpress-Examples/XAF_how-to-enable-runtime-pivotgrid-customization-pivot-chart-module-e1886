Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.PivotChart
Imports DevExpress.ExpressApp.PivotChart.Win

Namespace PivotGridCustomization.Module.Win
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Private Sub CreateTestAnalysis()
			Dim testAnalysis As Analysis = Session.FindObject(Of Analysis)(CriteriaOperator.Parse("Name='Test Analysis'"))
			If testAnalysis Is Nothing Then
				testAnalysis = New Analysis(Session)
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

Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace PivotGridCustomization.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim testObject As TestObject = Session.FindObject(Of TestObject)(CriteriaOperator.Parse("Name == 'First'"))
			If testObject Is Nothing Then
				Dim first As New TestObject(Session)
				first.Name = "First"
				first.Value = 5
				first.AnotherValue = 10
				first.Save()
				Dim second As New TestObject(Session)
				second.Name = "Second"
				second.Value = 15
				second.AnotherValue = 3
				second.Save()
				Dim third As New TestObject(Session)
				third.Name = "Third"
				third.Value = 9
				third.AnotherValue = 15
				third.Save()
			End If
		End Sub
	End Class
End Namespace

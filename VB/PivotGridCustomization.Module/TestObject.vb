Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace PivotGridCustomization.Module
	<DefaultClassOptions, VisibleInReports> _
	Public Class TestObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private name_Renamed As String
		Private value_Renamed As Integer
		Private anotherValue_Renamed As Integer

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Renamed, value)
			End Set
		End Property
		Public Property Value() As Integer
			Get
				Return value_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Value", Me.value_Renamed, value)
			End Set
		End Property
		Public Property AnotherValue() As Integer
			Get
				Return anotherValue_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("AnotherValue", Me.anotherValue_Renamed, value)
			End Set
		End Property
	End Class
End Namespace

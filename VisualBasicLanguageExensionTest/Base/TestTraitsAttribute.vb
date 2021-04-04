Imports Microsoft.VisualStudio.TestTools.UnitTesting

Public Enum Trait
    StringExtensionsVbnet
    BoolExtensionsVbnet
    TimeSpanExtensionsVbnet
End Enum
''' <summary>
''' Declarative class for using Trait enum about for traits on test method.
''' </summary>
Public Class TestTraitsAttribute
    Inherits TestCategoryBaseAttribute

    Private traits() As Trait

    Public Sub New(ParamArray ByVal traits() As Trait)
        Me.traits = traits
    End Sub

    Public Overrides ReadOnly Property TestCategories() As IList(Of String)
        Get
            Dim traitStrings = New List(Of String)()

            For Each trait In traits
                Dim value As String = System.Enum.GetName(GetType(Trait), trait)
                traitStrings.Add(value)
            Next trait

            Return traitStrings
        End Get
    End Property
End Class

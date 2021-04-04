Imports CommonLanguageExtensions_vb.CommonLanguageExtensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace VisualBasicLanguageExensionTest
    <TestClass>
    Public Class UnitTest1
        Inherits TestBase

        <TestMethod>
        <TestTraits(Trait.BoolExtensionsVbnet)>
        Sub ToYesNoString()

            Dim boolValue = True

            Assert.IsTrue(boolValue.ToYesNoString() = "Yes")

            boolValue = False
            Assert.IsTrue(boolValue.ToYesNoString() = "No")

        End Sub
        <TestMethod>
        <TestTraits(Trait.TimeSpanExtensionsVbnet)>
        Sub TimeSpanFormatted()

            Dim value = New DateTime(Now.Year, Now.Month, Now.Day, 7, 10, 24, DateTimeKind.Local).TimeOfDay

            Assert.AreEqual(value.Formatted(), "07:10 AM")
            Assert.AreNotEqual(value.Formatted(), "07:10 PM")

        End Sub
        <TestMethod>
        <TestTraits(Trait.StringExtensionsVbnet)>
        Public Sub IsEmptyOrWhitespace()
            ' arrange 
            Dim value As String = ""

            ' Act-assert
            Assert.IsTrue(value.IsNullOrWhiteSpace())

            ' arrange 
            value = "Not empty"

            ' Act-assert
            Assert.IsTrue(Not value.IsNullOrWhiteSpace())

        End Sub

        ''' <summary>
        ''' Here is where preparation is done before specific test
        ''' </summary>
        <TestInitialize>
        Public Sub Init()
            If TestContext.TestName = "TODO" Then

            End If
        End Sub
        <ClassInitialize()>
        Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
            TestResults = New List(Of TestContext)()
        End Sub
        <ClassCleanup()>
        Public Shared Sub ClassCleanup()
        End Sub
    End Class
End Namespace


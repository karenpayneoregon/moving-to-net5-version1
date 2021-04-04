Imports System.Runtime.CompilerServices

Namespace CommonLanguageExtensions
    Public Module TimeSpanExtensions
        ''' <summary>
        ''' Format a TimeSpan with AM PM
        ''' </summary>
        ''' <param name="sender">TimeSpan to format</param>
        ''' <param name="format">Optional format</param>
        ''' <returns></returns>
        <Extension>
        Public Function Formatted(sender As TimeSpan, Optional format As String = "hh:mm tt") As String
            Return DateTime.Today.Add(sender).ToString(format)
        End Function
    End Module
End Namespace

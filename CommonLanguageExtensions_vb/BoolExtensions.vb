Imports System.Runtime.CompilerServices

Namespace CommonLanguageExtensions
    ''' <summary>
    ''' Boolean code samples
    ''' </summary>
    Public Module BoolExtensions
        ''' <summary>
        ''' Convert bool to English text
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns>Yes or No as a string</returns>
        <Extension>
        Public Function ToYesNoString(value As Boolean) As String
            Return If(value, "Yes", "No")
        End Function
    End Module
End Namespace

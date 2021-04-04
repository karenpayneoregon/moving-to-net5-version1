Option Infer On

Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Namespace CommonLanguageExtensions
    Public Module ValidateExtensions
        ''' <summary>
        ''' Validate
        '''   Don't allow "219-09-999" or "078-05-1120" explicitly
        '''   Don't allow the SSN to begin with 666, 000 or anything between 900-999
        '''   Explicit dash (separating Area and Group numbers)
        '''   Don't allow the Group Number to be "00"
        '''   Another dash (separating Group and Serial numbers)
        '''   Don't allow last four digits to be "0000"
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <Extension>
        Public Function IsValidSsnWithoutDashes(value As String) As Boolean
            Return Regex.IsMatch(value.CleanSsn(), "^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$")
        End Function

        ''' <summary>
        ''' Simple validate 9 digits
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <Extension>
        Public Function IsValidSsnSimple(value As String) As Boolean
            Dim regexItem = New Regex("^\d{9}$")
            Dim matcher = regexItem.Match(value)
            Return matcher.Success
        End Function
        ''' <summary>
        ''' Remove hyphens from string
        ''' </summary>
        ''' <param name="ssn"></param>
        ''' <returns></returns>
        <Extension>
        Public Function CleanSsn(ssn As String) As String
            Return ssn.Replace("-", "")
        End Function
    End Module
End Namespace

Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Web

Namespace CommonLanguageExtensions
	Public Module StringExtensions
		''' <summary>
		''' Convert string to an enum member
		''' </summary>
		''' <typeparam name="T">Enum type</typeparam>
		''' <param name="value">Value to convert</param>
		''' <param name="defaultValue">Default value if an issue arises in the form of an empty string</param>
		''' <returns></returns>
		Public Function ToEnum(Of T As Structure)(value As String, defaultValue As T) As T
			If String.IsNullOrWhiteSpace(value) Then
				Return defaultValue
			End If

			Dim result As T

			Return If([Enum].TryParse(Of T)(value, result), result, defaultValue)

		End Function
		''' <summary>
		''' Split string with space e.g. FirstName becomes First Name
		''' </summary>
		''' <param name="sender">string value with value like FirstName</param>
		''' <returns>Original string if not in proper format or a string with space between variable upper cased tokens</returns>
		<Extension>
		Public Function SplitCamelCase(ByVal sender As String) As String
			Return Regex.Replace(Regex.Replace(sender, "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
		End Function

		''' <summary>
		''' Determine if a string can be represented as a numeric.
		''' </summary>
		''' <param name="text">value to determine if can be converted to a string</param>
		''' <returns></returns>
		<Extension>
		Public Function IsNumeric(text As String) As Boolean
			Return Double.TryParse(text, Nothing)
		End Function

		''' <summary>
		''' Strip alpha characters from a string
		''' </summary>
		''' <param name="text">text to work against</param>
		''' <returns>A string devoid of anything other than numeric values</returns>
		<Extension>
		Public Function StripperNumbers(text As String) As String
			Return Regex.Replace(text, "[^A-Za-z]", "")
		End Function

		<Extension>
		Public Function AlphaToInteger(text As String, ByRef result As Integer) As Boolean
			Dim value = Regex.Replace(text, "[^0-9]", "")
			Return Integer.TryParse(value, result)
		End Function

		''' <summary>
		''' Determine if string is empty
		''' </summary>
		''' <param name="sender">String to test if null or whitespace</param>
		''' <returns>true if empty or false if not empty</returns>
		<DebuggerStepThrough>
		<Extension>
		Public Function IsNullOrWhiteSpace(sender As String) As Boolean
			Return String.IsNullOrWhiteSpace(sender)
		End Function

		''' <summary>
		''' Overload of the standard String.Contains method which provides case sensitivity.
		''' </summary>
		''' <param name="sender">String to search</param>
		''' <param name="pSubString">Sub string to match</param>
		''' <param name="pCaseInSensitive">Use case or ignore case</param>
		''' <returns>True if string is in sent string</returns>
		<Extension>
		Public Function Contains(sender As String, pSubString As String, pCaseInSensitive As Boolean) As Boolean
			Return If(pCaseInSensitive, sender?.IndexOf(pSubString, StringComparison.OrdinalIgnoreCase) >= 0, sender IsNot Nothing AndAlso CBool(sender?.Contains(pSubString)))
		End Function

		''' <summary>
		''' Remove extra spaces in a string
		''' </summary>
		''' <param name="sender">string value</param>
		''' <returns>string with no extra spaces</returns>
		<Extension>
		Public Function RemoveExtraSpaces(sender As String) As String
			Const options As RegexOptions = RegexOptions.None
			Dim regex As New Regex("[ ]{2,}", options)
			Return regex.Replace(sender, " ")
		End Function

		''' <summary>
		''' Get parameters from a web address
		''' </summary>
		''' <param name="inputString">web address</param>
		''' <param name="key">parameter name</param>
		''' <returns></returns>
		<Extension>
		Public Function DumpHRefs(inputString As String, key As String) As List(Of String)

			Dim resultList = New List(Of String)()
			Const hRefPattern As String = "href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))"

			Try
				Dim match = Regex.Match(inputString, hRefPattern, RegexOptions.IgnoreCase Or RegexOptions.Compiled, TimeSpan.FromSeconds(1))

				Do While match.Success

					Dim myUri = New Uri(match.Groups(1).Value)
					Dim articleIdValue = HttpUtility.ParseQueryString(myUri.Query).Get(key)

					If Not String.IsNullOrWhiteSpace(articleIdValue) Then
						resultList.Add($"{articleIdValue}")
					End If

					match = match.NextMatch()
				Loop
			Catch e1 As RegexMatchTimeoutException
				Return resultList
			End Try

			Return resultList
		End Function
	End Module

End Namespace

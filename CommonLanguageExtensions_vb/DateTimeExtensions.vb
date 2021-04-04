Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks

Namespace CommonLanguageExtensions
	''' <summary>
	''' Date time extensions
	''' </summary>
	Public Module DateTimeExtensions
		''' <summary>
		''' Returns passed datetime with zero padding using current culture separators
		''' </summary>
		''' <param name="d"></param>
		''' <returns></returns>
		''' <remarks>
		''' order of date parts year, month, day which can be changed to say month, day, year
		''' </remarks>
		<Extension>
		Public Function ZeroPad(d As DateTime) As String
			Dim dateSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
			Dim timeSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator

			Dim resultShort = $"{d.Year:D2}{dateSeparator}{d.Month:D2}{dateSeparator}{d.Day:D2} {d.Hour:D2}{timeSeparator}{d.Minute:D2}{timeSeparator}{d.Second:D2}"
			Dim resultLong = d.Year.ToString("D2") & dateSeparator & d.Month.ToString("D2") & dateSeparator & d.Day.ToString("D2") & " " & d.Hour.ToString("D2") & timeSeparator & d.Minute.ToString("D2") & timeSeparator & d.Second.ToString("D2")

			Return resultShort
		End Function

		''' <summary>
		''' Returns passed datetime with zero padding using user supplied separators
		''' </summary>
		''' <param name="d"></param>
		''' <param name="dateSeparator"></param>
		''' <param name="timeSeparator"></param>
		''' <returns></returns>
		''' <remarks>
		''' order of date parts year, month, day which can be changed to say month, day, year
		''' </remarks>
		<Extension>
		Public Function ZeroPad(d As DateTime, dateSeparator As String, timeSeparator As String) As String
			Return $"{d.Year:D2}{dateSeparator}{d.Month:D2}{dateSeparator}{d.Day:D2} {d.Hour:D2}{timeSeparator}{d.Minute:D2}{timeSeparator}{d.Second:D2}"
		End Function
	End Module
End Namespace

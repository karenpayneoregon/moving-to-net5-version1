Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
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
		''' <param name="dt">Zero padded date time</param>
		''' <returns></returns>
		''' <remarks>
		''' order of date parts year, month, day which can be changed to say month, day, year
		''' </remarks>
		<Extension>
		Public Function ZeroPad(dt As DateTime) As String
			Dim dateSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
			Dim timeSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator

			Dim resultShort = $"{dt.Year:D2}{dateSeparator}{dt.Month:D2}{dateSeparator}{dt.Day:D2} {dt.Hour:D2}{timeSeparator}{dt.Minute:D2}{timeSeparator}{dt.Second:D2}"

			'
			' Too much code, the above is better
			'
			'Dim resultLong =
			'		dt.Year.ToString("D2") &
			'		dateSeparator &
			'		dt.Month.ToString("D2") &
			'		dateSeparator & dt.Day.ToString("D2") & " " &
			'		dt.Hour.ToString("D2") &
			'		timeSeparator &
			'		dt.Minute.ToString("D2") &
			'		timeSeparator & dt.Second.ToString("D2")

			Return resultShort
		End Function
		''' <summary>
		''' Returns passed datetime with zero padding using current culture separators
		''' </summary>
		''' <param name="dt">Zero padded date time, without seconds</param>
		''' <returns></returns>
		''' <remarks>
		''' order of date parts year, month, day which can be changed to say month, day, year
		''' </remarks>
		<Extension>
		Public Function ZeroPadWithoutSeconds(dt As DateTime) As String
			Dim dateSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
			Dim timeSeparator As String = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator

			Dim resultShort = $"{dt.Year:D2}{dateSeparator}{dt.Month:D2}{dateSeparator}{dt.Day:D2} {dt.Hour:D2}{timeSeparator}{dt.Minute:D2}"

			Return resultShort

		End Function

		''' <summary>
		''' Returns passed datetime with zero padding using user supplied separators
		''' </summary>
		''' <param name="dt"></param>
		''' <param name="dateSeparator">user supplied date separator</param>
		''' <param name="timeSeparator">user supplied time separator</param>
		''' <returns></returns>
		''' <remarks>
		''' order of date parts year, month, day which can be changed to say month, day, year
		''' </remarks>
		<Extension>
		Public Function ZeroPad(dt As DateTime, dateSeparator As String, timeSeparator As String) As String
			Return $"{dt.Year:D2}{dateSeparator}{dt.Month:D2}{dateSeparator}{dt.Day:D2} {dt.Hour:D2}{timeSeparator}{dt.Minute:D2}{timeSeparator}{dt.Second:D2}"
		End Function

		''' <summary>
		''' Show possible time zone for a DateTimeOffset
		''' </summary>
		''' <param name="offsetTime"><see cref="DateTimeOffset"/></param>
		''' <returns>list of possible time zones</returns>
		''' <code lang="csharp">
		''' var startDate = New DateTime(2018, 12, 2, 1, 12, 0);
		''' var endDate = New DateTime(2018, 12, 15, 1, 12, 0);
		''' var theDate = New DateTime(2018, 12, 13, 1, 12, 0);
		''' Assert.IsTrue(theDate.Between(startDate,endDate));
		''' </code>
		''' </example>
		''' <remarks>
		''' TODO change code example to vb
		''' </remarks>
		<Extension>
		Public Function ShowPossibleTimeZones(offsetTime As DateTimeOffset) As List(Of String)

			Dim offset As TimeSpan = offsetTime.Offset
			Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()

			Return (From timeZone In timeZones Where timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset) Select timeZone.DisplayName).ToList()

		End Function

	End Module
End Namespace

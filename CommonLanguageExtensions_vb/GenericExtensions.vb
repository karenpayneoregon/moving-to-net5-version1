Imports System
Imports System.Runtime.CompilerServices

Namespace CommonLanguageExtensions
	Public Module GenericExtensions
		''' <summary>
		''' Determine if T is between lower and upper
		''' </summary>
		''' <typeparam name="T">Data type</typeparam>
		''' <param name="sender">Value to determine if between lower and upper</param>
		''' <param name="minimumValue">Lower of range</param>
		''' <param name="maximumValue">Upper of range</param>
		''' <returns>True if in range, false if not in range</returns>
		''' <example>
		''' <code>
		''' var startDate = new DateTime(2018, 12, 2, 1, 12, 0);
		''' var endDate = new DateTime(2018, 12, 15, 1, 12, 0);
		''' var theDate = new DateTime(2018, 12, 13, 1, 12, 0);
		''' Assert.IsTrue(theDate.Between(startDate,endDate));
		''' </code>
		''' </example>
		<Extension>
		Public Function Between(Of T)(sender As IComparable(Of T), minimumValue As T, maximumValue As T) As Boolean
			Return sender.CompareTo(minimumValue) >= 0 AndAlso sender.CompareTo(maximumValue) <= 0
		End Function
		''' <summary>Determines if a value is between two values, exclusive.</summary>
		''' <param name="sender">The source value.</param>
		''' <param name="minimumValue">The minimum value.</param>
		''' <param name="maximumValue">The Maximum value.</param>
		''' <returns><see langword="true"/> if the value is between the two values, exclusive.</returns>
		<Extension>
		Public Function BetweenExclusive(Of T)(sender As IComparable(Of T), minimumValue As T, maximumValue As T) As Boolean
			Return sender.CompareTo(minimumValue) > 0 AndAlso sender.CompareTo(maximumValue) < 0
		End Function
		''' <summary>
		''' Determine if value is positive
		''' </summary>
		''' <typeparam name="T">Type implementing IComparable</typeparam>
		''' <param name="value">Value to test</param>
		''' <returns>true if positive, false otherwise</returns>
		<Extension>
		Public Function IsPositive(Of T As {Structure, IComparable(Of T)})(value As T) As Boolean
			Return value.CompareTo(CType(Nothing, T)) > 0
		End Function
		''' <summary>
		''' Determine if value is negative
		''' </summary>
		''' <typeparam name="T">Type implementing IComparable</typeparam>
		''' <param name="value">Value to test</param>
		''' <returns>true if negative, false otherwise</returns>
		<Extension>
		Public Function IsNegative(Of T As {Structure, IComparable(Of T)})(value As T) As Boolean
			Return value.CompareTo(CType(Nothing, T)) = -1
		End Function
	End Module
End Namespace

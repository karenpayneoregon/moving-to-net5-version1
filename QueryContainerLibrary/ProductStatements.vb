''' <summary>
''' Provides a nice way to take SQL statements written and tested in SSMS, drop them here and
''' use them in C# or VB.NET.
'''
''' Note that there are several functions which accept a integer which are directly inserted
''' without using command parameters. Generally speaking this is not wise although in these cases
''' there is zero harm doing this for integers while not good at all if we did this with a string as
''' a value may contain an apostrophe which needs to be escaped that when using command parameters
''' apostrophes are escaped for them.
''' </summary>
Public Class ProductStatements

    Public Shared Function SelectStatement() As String

        Return _
            <SQL>
                SELECT 
                    P.ProductID, 
                    P.ProductName, 
                    P.SupplierID, 
                    S.CompanyName, 
                    P.CategoryID, 
                    C.CategoryName, 
                    P.QuantityPerUnit, 
                    P.UnitPrice, 
                    P.UnitsInStock, 
                    P.UnitsOnOrder, 
                    P.ReorderLevel, 
                    P.Discontinued, 
                    P.DiscontinuedDate 
                FROM  
                    Products AS P 
                        INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID 
                        INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID
            </SQL>.Value


    End Function
    Public Shared Function SelectStatementByIdentifier(productIdentifier) As String

        Return _
            <SQL>
                SELECT 
                    P.ProductID, 
                    P.ProductName, 
                    P.SupplierID, 
                    S.CompanyName, 
                    P.CategoryID, 
                    C.CategoryName, 
                    P.QuantityPerUnit, 
                    P.UnitPrice, 
                    P.UnitsInStock, 
                    P.UnitsOnOrder, 
                    P.ReorderLevel, 
                    P.Discontinued, 
                    P.DiscontinuedDate 
                FROM  
                    Products AS P 
                        INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID 
                        INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID
                WHERE P.ProductID = <%= productIdentifier %>
            </SQL>.Value


    End Function
    Public Shared Function SelectStatementByCategory(categoryIdentifier) As String

        Return _
            <SQL>
                SELECT 
                    P.ProductID, 
                    P.ProductName, 
                    P.SupplierID, 
                    S.CompanyName, 
                    P.CategoryID, 
                    C.CategoryName, 
                    P.QuantityPerUnit, 
                    P.UnitPrice, 
                    P.UnitsInStock, 
                    P.UnitsOnOrder, 
                    P.ReorderLevel, 
                    P.Discontinued, 
                    P.DiscontinuedDate 
                FROM  
                    Products AS P 
                        INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID 
                        INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID
                WHERE P.CategoryID = <%= categoryIdentifier %>
            </SQL>.Value


    End Function

    Public Shared Function UpdateStatementWithParameters() As String
        Return _
            <SQL>
                UPDATE dbo.Products
                   SET ProductName = @ProductName
                      ,SupplierID = @SupplierID
                      ,CategoryID = @CategoryID
                      ,QuantityPerUnit = @QuantityPerUnit
                      ,UnitPrice = @UnitPrice
                      ,UnitsInStock = @UnitsInStock
                      ,UnitsOnOrder = @UnitsOnOrder
                      ,ReorderLevel = @ReorderLevel
                      ,Discontinued = @Discontinued
                      ,DiscontinuedDate = @DiscontinuedDate
                 WHERE ProductID = @ProductID
               </SQL>.Value
    End Function

End Class

CREATE PROC dbo.usp_FindTotalIncome(@supplierId int = 1, @startDate datetime = '1996-07-15',
@endDate datetime = '1996-08-24')
AS
	SELECT SUM(Quantity * (od.UnitPrice - Discount))
	FROM [Order Details] od INNER JOIN ORDERS o
	ON od.OrderID = o.OrderID AND o.ShippedDate BETWEEN @startDate AND @endDate
	INNER JOIN Products p
	ON p.ProductID = od.ProductID AND p.SupplierID = @supplierId
GO

EXEC usp_FindTotalIncome 1
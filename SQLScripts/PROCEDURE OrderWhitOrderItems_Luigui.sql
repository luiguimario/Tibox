CREATE PROCEDURE OrderWhitOrderItems_Luigui
@orderId int
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id, OrderDate,CustomerId,TotalAmount
	FROM dbo.[Order]
	WHERE Id=@orderId

	SELECT  Id,ProductId,UnitPrice,Quantity 
	FROM dbo.OrderItem 
	WHERE OrderId=@orderId	

END

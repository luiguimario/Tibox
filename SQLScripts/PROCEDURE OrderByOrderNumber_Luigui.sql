CREATE PROCEDURE OrderByOrderNumber_Luigui
@orderNumber int
AS
BEGIN
select Id, OrderDate,CustomerId,TotalAmount from [Order] where OrderNumber = @orderNumber
END

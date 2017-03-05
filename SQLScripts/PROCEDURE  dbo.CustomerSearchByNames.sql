CREATE PROCEDURE  dbo.CustomerSearchByNames ---'Maria','Anders'
 @FirstName nvarchar(40),
 @LastName nvarchar(40)
AS
BEGIN
		SET NOCOUNT ON ;
		SELECT Id,FirstName,LastName,City,Country,Phone FROM dbo.Customer
		WHERE FirstName=@FirstName AND   LastName=@LastName
		SET NOCOUNT OFF ;
END
Create procedure TransportadoraAtualizar
@shipperId int,
@companyName nvarchar(40),
@phone nvarchar(24)
as
UPDATE [dbo].[Shippers]
   SET [CompanyName] = @companyName
      ,[Phone] = @phone
 WHERE ShipperID = @shipperId

Create procedure TransportadoraAtualizar
@companyName nvarchar(40),
@phone nvarchar(24),
@shipperId int
as

UPDATE [dbo].[Shippers]
   SET [CompanyName] = @companyName
      ,[Phone] = @phone
 WHERE [ShipperID] = @shipperId

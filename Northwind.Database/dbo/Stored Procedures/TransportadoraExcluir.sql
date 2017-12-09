Create procedure TransportadoraExcluir
@shipperId int
as
DELETE FROM [dbo].[Shippers]
      WHERE ShipperID = @shipperId

Create procedure TransportadoraExcluir
@shipperId int

as

delete from [dbo].[Shippers]
 where ShipperID = @shipperId


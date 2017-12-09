CREATE procedure [dbo].[TransportadoraSelecionar]
@shipperId int = null
as
SELECT [ShipperID]
      ,[CompanyName]
      ,[Phone]
  FROM [dbo].[Shippers]
  Where [ShipperID] = ISNULL(@shipperId, ShipperID)

CREATE procedure TransportadoraInserir
@companyName nvarchar(40),
@phone nvarchar(24)
as
INSERT INTO [dbo].[Shippers]
           ([CompanyName]
           ,[Phone])
	output inserted.ShipperID
     VALUES
           (@companyName
           ,@phone)

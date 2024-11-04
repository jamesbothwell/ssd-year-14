use CA
go

create procedure Update_Stock

@StockNo int,
@StockDesc varchar (255),
@StockCategory varchar (255),
@StockPrice decimal,
@StockSellingPrice decimal,
@StockQty int,
@StockImage varchar (255)

as

update Stock
set
StockDesc = @StockDesc,
StockCategory = @StockCategory,
StockPrice = @StockPrice,
StockSellingPrice = @StockSellingPrice,
StockQty = @StockQty,
StockImage = @StockImage

where StockNo = @StockNo

go
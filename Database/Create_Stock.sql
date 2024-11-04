use CA
go

create procedure Create_Stock

@StockDesc varchar(255),
@StockCategory varchar(255),
@StockPrice decimal,
@StockSellingPrice decimal,
@StockQty int,
@StockImage varchar(255)

as

insert into Stock
values (@StockDesc, @StockCategory, @StockPrice, @StockSellingPrice, @StockQty, @StockImage)

go
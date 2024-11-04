use CA

create table Stock
(
	StockNo int primary key identity(1,1),
	StockDesc varchar(255),
	StockCategory varchar(255),
	StockPrice decimal,
	StockSellingPrice decimal,
	StockQty int,
	StockImage varchar(255)
)
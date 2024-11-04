use CA
go

create procedure Get_Stock

as

select
Stock.StockNo,
Stock.StockDesc,
Stock.StockCategory,
Stock.StockPrice,
Stock.StockSellingPrice,
Stock.StockQty,
Stock.StockImage


from Stock

group by Stock.StockNo, Stock.StockDesc, Stock.StockCategory, Stock.StockPrice, Stock.StockSellingPrice, Stock.StockQty, Stock.StockImage

go
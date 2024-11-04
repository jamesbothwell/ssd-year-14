use CA
go

create procedure Search_Stock

@SearchString varchar(130)

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
where
	lower(Stock.StockNo) like concat('%', @SearchSTring, '%') or
	lower(Stock.StockDesc)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockCategory)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockPrice)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockSellingPrice)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockQty)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockImage)  like concat('%', @SearchSTring, '%')
group by Stock.StockNo, Stock.StockDesc, Stock.StockCategory, Stock.StockPrice, Stock.StockSellingPrice, Stock.StockQty, Stock.StockImage;

go
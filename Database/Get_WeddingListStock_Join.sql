use CA
go

create procedure Get_WeddingListStock_Join

as

select s.StockNo,
s.StockDesc,
s.StockCategory,
s.StockSellingPrice,
w.QtyOrdered,
w.OrderNo

from Stock s
inner join WeddingListStock w on s.StockNo = w.StockNo

go
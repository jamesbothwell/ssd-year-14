use CA
go

create procedure Get_WeddingListStock

as

select
WeddingListStock.OrderNo,
WeddingListStock.CustNo,
WeddingListStock.StockNo,
WeddingListStock.QtyOrdered

from WeddingListStock

group by WeddingListStock.OrderNo, WeddingListStock.CustNo, WeddingListStock.StockNo, WeddingListStock.QtyOrdered

go
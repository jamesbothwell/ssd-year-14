use CA
go

create procedure Get_WeddingListPurchase

as

select
WeddingListPurchase.OrderNo,
WeddingListPurchase.CustNo,
WeddingListPurchase.StockNo,
WeddingListPurchase.QtyRequired,
WeddingListPurchase.QtyOrdered

from WeddingListPurchase

group by WeddingListPurchase.OrderNo, WeddingListPurchase.CustNo, WeddingListPurchase.StockNo, WeddingListPurchase.QtyRequired, WeddingListPurchase.QtyOrdered

go
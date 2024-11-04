use CA
go

create procedure Update_WeddingListStock

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

update WeddingListStock
set
QtyOrdered = @QtyOrdered

where OrderNo = @OrderNo AND CustNo = @CustNo  AND StockNo = @StockNo

go
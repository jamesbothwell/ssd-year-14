use CA
go

create procedure Update_CustomerOrderStock

@OrderNo int,
@StockNo int,
@QtyOrdered int

as

update CustomerOrderStock
set
QtyOrdered = @QtyOrdered

where OrderNo = @OrderNo AND StockNo = @StockNo

go
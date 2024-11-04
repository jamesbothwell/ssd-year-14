use CA
go

create procedure Delete_WeddingListStock

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

delete from WeddingListStock
where OrderNo = @OrderNo AND CustNo = @CustNo  AND StockNo = @StockNo AND QtyOrdered = @QtyOrdered

go
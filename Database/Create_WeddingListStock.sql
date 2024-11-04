use CA
go

create procedure Create_WeddingListStock

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

insert into WeddingListStock
values (@OrderNo, @CustNo, @StockNo, @QtyOrdered)

go
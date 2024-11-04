use CA
go

create procedure Create_WeddingListPurchase

@OrderNo int,
@Custno int,
@StockNo int,
@QtyRequired int,
@QtyOrdered int

as

insert into WeddingListPurchase
values (@OrderNo, @Custno, @StockNo, @QtyRequired, @QtyOrdered)

go
use CA
go

create procedure Create_CustomerOrderStock

@OrderNo int,
@StockNo int,
@QtyOrdered int

as

insert into CustomerOrderStock
values (@OrderNo, @StockNo, @QtyOrdered)

go
use CA
go

create procedure Get_CustomerOrderStock

as

select
CustomerOrderStock.OrderNo,
CustomerOrderStock.StockNo,
CustomerOrderStock.QtyOrdered

from CustomerOrderStock

group by CustomerOrderStock.OrderNo, CustomerOrderStock.StockNo, CustomerOrderStock.QtyOrdered

go
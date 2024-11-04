use CA
go

create procedure Get_CustomerOrder

as

select
CustomerOrder.OrderNo,
CustomerOrder.DateOfOrder,
CustomerOrder.Delivery,
CustomerOrder.DateOfDelivery,
CustomerOrder.DeliveryYN,
CustomerOrder.CustNo

from CustomerOrder

group by CustomerOrder.OrderNo, CustomerOrder.DateOfOrder, CustomerOrder.Delivery, CustomerOrder.DateOfDelivery, CustomerOrder.DeliveryYN, CustomerOrder.CustNo

go
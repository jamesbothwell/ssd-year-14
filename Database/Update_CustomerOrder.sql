use CA
go

create procedure Update_CustomerOrder

@OrderNo int,
@DateOfOrder datetime,
@Delivery varchar(1),
@DateOfDelivery datetime,
@DeliveryYN varchar(1),
@CustNo int 

as

update CustomerOrder
set
DateOfOrder = @DateOfOrder,
Delivery = @Delivery,
DateOfDelivery = @DateOfDelivery,
DeliveryYN = @DeliveryYN,
CustNo = @CustNo

where OrderNo = @OrderNo

go
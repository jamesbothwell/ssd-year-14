use CA
go

create procedure Create_CustomerOrder

@CustNo int

as

insert into CustomerOrder(CustNo)
values (@CustNo)

go
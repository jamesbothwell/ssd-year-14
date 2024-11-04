use CA
go

create procedure Get_WeddingListPurchase_Join

as

select c.CustNo,
c.CustName

from Customer c
inner join WeddingListPurchase w on c.CustNo = w.CustNo

go
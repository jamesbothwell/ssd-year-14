use CA
go

create procedure Get_Customers

as

select
Customer.CustNo,
Customer.CustName,
Customer.CustAddress1,
Customer.CustAddress2,
Customer.CustPostcode,
Customer.CustPhone,
Customer.CustEmail

from Customer

group by Customer.CustNo, Customer.CustName, Customer.CustAddress1, Customer.CustAddress2, Customer.CustPostcode, Customer.CustPhone, Customer.CustEmail

go
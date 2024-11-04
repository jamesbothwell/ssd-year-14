use CA
go

create procedure Search_Customers

@SearchString varchar(130)

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
where
	lower(Customer.CustNo) like concat('%', @SearchSTring, '%') or
	lower(Customer.CustName)  like concat('%', @SearchSTring, '%') or
	lower(Customer.CustAddress1)  like concat('%', @SearchSTring, '%') or
	lower(Customer.CustAddress2)  like concat('%', @SearchSTring, '%') or
	lower(Customer.CustPostcode)  like concat('%', @SearchSTring, '%') or
	lower(Customer.CustPhone)  like concat('%', @SearchSTring, '%') or
	lower(Customer.CustEmail)  like concat('%', @SearchSTring, '%') 
group by Customer.CustNo, Customer.CustName, Customer.CustAddress1, Customer.CustAddress2, Customer.CustPostcode, Customer.CustPhone, Customer.CustEmail;

go
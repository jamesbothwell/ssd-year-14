use CA

create table Customer
(
	CustNo int primary key identity(1,1),
	CustName varchar(128),
	CustAddress1 varchar(128),
	CustAddress2 varchar(128),
	CustPostcode varchar(8),
	CustPhone varchar(11),
	CustEmail varchar(64)
)
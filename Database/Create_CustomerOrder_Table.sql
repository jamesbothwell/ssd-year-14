use CA

create table CustomerOrder
(
	OrderNo int primary key identity(1,1),
	DateOfOrder datetime default GetDate(),
	Delivery varchar(1) default 'N',
	DateOfDelivery datetime default null,
	DeliveryYN varchar(1) default null,
	CustNo int foreign key references Customer(CustNo)
)
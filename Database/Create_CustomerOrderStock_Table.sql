use CA

create table CustomerOrderStock
(
	OrderNo int foreign key references CustomerOrder(OrderNo),
	StockNo int foreign key references Stock(StockNo),
	QtyOrdered int
)
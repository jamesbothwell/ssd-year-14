use CA

create table WeddingListStock
(
	OrderNo int foreign key references WeddingList(OrderNo),
	CustNo int foreign key references Customer(CustNo),
	StockNo int foreign key references Stock(StockNo),
	QtyOrdered int 
)
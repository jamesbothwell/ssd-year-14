use CA

create table WeddingListPurchase
(
	OrderNo int foreign key references WeddingList(OrderNo),
	CustNo int foreign key references Customer(CustNo),
	StockNo int foreign key references Stock(StockNo),
	QtyRequired int,
	QtyOrdered int 
)
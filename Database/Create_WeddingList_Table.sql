use CA

create table WeddingList
(
	OrderNo int primary key identity(1,1),
	DateOfOrder datetime default GetDate(),
	ReferenceName varchar(255),
	CompletedYN varchar(1)
)
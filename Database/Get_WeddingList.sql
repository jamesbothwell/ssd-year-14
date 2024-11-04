use CA
go

create procedure Get_WeddingList

as

select
WeddingList.OrderNo,
WeddingList.DateOfOrder,
WeddingList.ReferenceName,
WeddingList.CompletedYN

from WeddingList

group by WeddingList.OrderNo, WeddingList.DateOfOrder, WeddingList.ReferenceName, WeddingList.CompletedYN

go
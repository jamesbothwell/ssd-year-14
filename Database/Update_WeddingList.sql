use CA
go

create procedure Update_WeddingList

@OrderNo int,
@DateOfOrder date,
@ReferenceName varchar(255),
@CompletedYN varchar(1)

as

update WeddingList
set
DateOfOrder = @DateOfOrder,
ReferenceName = @ReferenceName,
CompletedYN = @CompletedYN

where OrderNo = @OrderNo

go
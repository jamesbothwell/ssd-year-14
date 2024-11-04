use CA
go

create procedure Create_WeddingList

@ReferenceName varchar(255),
@CompletedYN varchar(1)

as

insert into WeddingList(ReferenceName, CompletedYN)
values (@ReferenceName, @CompletedYN)

go
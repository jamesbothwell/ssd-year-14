use CA
go

create procedure Create_Booking

@DateOfBooking date,
@Slot varchar (255),
@CustNo int,
@StaffNo int

as

insert into Booking
values (@DateOfBooking, @Slot, @CustNo, @StaffNo)
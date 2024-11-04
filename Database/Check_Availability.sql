use CA
go

create procedure Check_Availability

@SelectedDate date

as

select Slot from Booking
where DateOfBooking = @SelectedDate
use CA
go

create procedure Get_Booking

as

select
Booking.BookingNo,
Booking.DateOfBooking,
Booking.Slot,
Booking.CustNo,
Booking.StaffNo

from Booking

group by Booking.BookingNo, Booking.DateOfBooking, Booking.Slot, Booking.CustNo, Booking.StaffNo

go
use CA
go

create procedure Get_Booking_Join

as

select c.CustNo,
c.CustName,
c.CustAddress1,
c.CustAddress2,
c.CustPostcode,
c.CustPhone,
c.CustEmail,
b.BookingNo,
b.DateOfBooking

from Customer c
inner join Booking b on c.CustNo = b.CustNo

go
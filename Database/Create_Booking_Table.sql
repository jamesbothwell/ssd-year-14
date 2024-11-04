use CA

create table Booking
(
	BookingNo int primary key identity(1,1),
	DateOfBooking date,
	Slot varchar(255),
	CustNo int foreign key references Customer(CustNo),
	StaffNo int foreign key references Staff(StaffNo)
)
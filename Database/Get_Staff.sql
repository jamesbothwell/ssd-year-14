use CA
go

create procedure Get_Staff

as

select
Staff.StaffNo,
Staff.StaffName,
Staff.StaffJob

from Staff

group by Staff.StaffNo, Staff.StaffName, Staff.StaffJob

go
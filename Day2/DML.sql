use dbHR
Go

select * from tblLocation

insert into tblLocation(location,zip_code)
values('ABC','12345')
insert into tblLocation
values('CBA','12346')

--Duplicate PK Error
insert into tblLocation(zip_code,location)
values('12347','BBB')
--Null to PK Error
insert into tblLocation
values(null,'12346')

select * from tblEmployee
insert into 
tblEmployee(employee_name,age,
employee_location,employee_status)
values('Ramu',23,'ABC','active')

insert into 
tblEmployee(age,employee_name,
employee_location,employee_status)
values(34,'Somu','BBB','active')

--Check violation for age
insert into 
tblEmployee(age,employee_name,
employee_location,employee_status)
values(19,'Lomu','BBB','inactive')

insert into tblSkill
values('C','PLT'),('C++','OOPS'),('Java','Web'),
('C#','Web'),('SQL','RDBMS')
insert into tblSkill
values('Summa','Dummy')

insert into tblEmployeeSkill
values(101,'C',7),(101,'C++',7),(101,'Java',8)
insert into tblEmployeeSkill
values(102,'C++',7),(102,'Java',8)
insert into tblEmployeeSkill
values(104,'C#',default),(104,'SQL',8)

--Error - Duplication of composite key
insert into tblEmployeeSkill
values(102,'C++',7)

select * from tblEmployeeSkill

update tblEmployeeSkill 
set skill_level=8
where employee_id=101 and employee_skill='C++'


update tblEmployeeSkill 
set skill_level= case
when skill_level = 8 then 7
when skill_level =5 then 6
else skill_level
end

--Update with 0 rows afftected. No error but no selection
update tblEmployeeSkill 
set skill_level=8
where employee_id=103 and employee_skill='C++'




update tblEmployeeSkill set skill_level=null
where employee_id=104 and employee_skill='C#'


delete tblEmployeeSkill where employee_id=104

delete tblSkill where skill='Summa'


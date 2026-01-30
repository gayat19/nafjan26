create database dbHR

use dbHR

create table tblLocation
(location varchar(50) constraint pk_location primary key,
zip_code char(6))

create table tblLocation
(location varchar(50)  primary key,
zip_code char(6))

create table tblLocation
(location varchar(50) ,
zip_code char(6))

alter table tblLocation
alter column location varchar(50) not null

alter table tblLocation
add constraint pk_location primary key(location)

drop table tblLocation

select * from tblLocation

sp_help tblLocation

create table tblEmployee
(employee_id int identity(101,1) constraint pk_employee_id primary key,
employee_name varchar(100) not null,
age int constraint chk_age check(age>=18),
employee_location varchar(50) 
constraint fk_employee_location 
foreign key references tblLocation(location))

sp_help tblEmployee

alter table tblEmployee
add employee_status varchar(15) 
constraint chk_employee_status 
check(employee_status in
('active','in-active'))

create table tblSkill
(skill varchar(100) constraint pk_skill primary key,
skill_description varchar(100))

create table tblEmployeeSkill
(employee_id int constraint fk_employeeskill_employee 
foreign key references tblEmployee(employee_id),
employee_skill varchar(100) constraint fk_emplieeskill_skill
 foreign key references tblSkill(skill),
 skill_level float default 5,
 constraint pk_employeeskill primary key(employee_id,
 employee_skill))

 sp_help tblEmployeeSkill

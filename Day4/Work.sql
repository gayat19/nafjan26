sp_help tblEmployee

create proc proc_InsertEmployee
(@ename varchar(100), @eage int, 
@eloaction varchar(50), @estatus varchar(10))
as
begin
   insert into tblEmployee(employee_name,age, employee_location,employee_status)
   values(@ename,@eage,@eloaction,@estatus)
end

exec proc_InsertEmployee 'Kimu',30, 'ABC','active'

select * from tblEmployee

alter proc proc_InsertEmployee
(@ename varchar(100), @eage int, 
@elocation varchar(50), @estatus varchar(10))
as
begin
   if Exists(select * from tblLocation where location=@elocation)
   begin
	   insert into tblEmployee(employee_name,age, employee_location,employee_status)
	   values(@ename,@eage,@elocation,@estatus)
	   print 'Insert success'
   end
   else
	   print 'Unable to insert!!! Invalid location'
end

exec proc_InsertEmployee 'Pomu',30, 'CBA','active'

drop procedure proc_InsertEmployee

create proc proc_InsertEmployee
(@ename varchar(100), @eage int, 
@elocation varchar(50), @estatus bit,
@eid int out)
as
begin
   if Exists(select * from tblLocation where location=@elocation)
   begin
       declare @stat varchar(10) = 'In-Active'
	   if @estatus = 1
			set @stat = 'Active'
	   insert into tblEmployee(employee_name,age, employee_location,employee_status)
	   values(@ename,@eage,@elocation,@stat)
	   set @eid = @@IDENTITY
	   print concat('Insert success and the id is : ',cast(@eid as varchar(3)))
   end
   else
	   print 'Unable to insert!!! Invalid location'
end

alter proc proc_InsertEmployee
(@ename varchar(100), @eage int, 
@elocation varchar(50), @estatus bit,
@eid int out)
as
begin
    set nocount on
	Begin try
	   if Exists(select * from tblLocation where location=@elocation)
	   begin
			

		   declare @stat varchar(10) = 'In-Active'
		   if @estatus = 1
				set @stat = 'Active'
		   insert into tblEmployee(employee_name,age, employee_location,employee_status)
		   values(@ename,@eage,@elocation,@stat)
		   set @eid = @@IDENTITY
		   print concat('Insert success and the id is : ',cast(@eid as varchar(3)))
	   end
	   else
		   print 'Unable to insert!!! Invalid location'
	End Try
	Begin Catch
		select 0 'Status',
		Error_Message() 'Error Message',
		Error_Number() 'Error Number',
		Error_Line() 'Error Line Number'
	end Catch
end



declare @id int
exec proc_InsertEmployee 'Vimu',31, 'ABC',1, @id out
print @id



--Create a procedure that will take 
--Employee ID, skill aand skill level for insert into employeeskill
--Before inserting check if teh employee and the skill are present
--handle errors for skilllevel that are negative
--if the skill level is null then insert the default value

create table tblErrorLog
(id int identity(1,1) primary key,
errornumber int,
errormessage text,
errordatetime datetime default GetDate())
create proc proc_InsertSkillWithDetails
(@eid int, @eskill varchar(50), @eskilldesc varchar(100)
,@slevel float)
as
begin
   begin tran
	   begin try
		if not exists(select * from tblSkill where skill=@eskill)
			insert into tblSkill values(@eskill,@eskilldesc)
		else
			if exists(select * from tblEmployee where employee_id=@eid)
			begin
				if(@slevel<0)
					rollback
				else
				begin
					if(@slevel is null)
						set @slevel = 5
					insert into tblEmployeeSkill
					values(@eid,@eskill,@slevel)
					commit
				end
			end
	   end try
	   begin catch
			rollback
			insert into tblErrorLog(errornumber,errormessage,errordatetime)
			values(Error_Number(),Error_Message(),default)
			select 0 'Status',
			Error_Message() 'Error Message',
			Error_Number() 'Error Number',
			Error_Line() 'Error Line Number'
	   end catch
end
proc_InsertSkillWithDetails 101,'python',null,7
select * from tblEmployeeSkill
select * from tblSkill
select * from tblErrorLog

sp_help tblSkill

alter table tblSkill
alter column skill_description varchar(100) not null
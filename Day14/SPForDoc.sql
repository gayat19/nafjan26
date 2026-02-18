create proc  proc_GetAllDoctors(@skip int, @next int)
as
begin
  select * from doctors 
  order by Experience
  offset @skip rows fetch next @next rows only
end

sp_help proc_GetAllDoctors
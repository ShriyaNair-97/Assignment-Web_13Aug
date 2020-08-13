Create Procedure sp_DeleteEmp 
@empid int
as
begin
  delete from EmployeeTable where empId=@empid
end
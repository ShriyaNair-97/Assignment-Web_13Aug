CREATE PROCEDURE sp_Update
	@empId int,
	@empName varchar(20),
	@empSal float ,
	@gender varchar (6)
AS
Begin

	update EmployeeTable set empName=@empName , empSal=@empSal ,gender=@gender 
	where empId=@empId

end
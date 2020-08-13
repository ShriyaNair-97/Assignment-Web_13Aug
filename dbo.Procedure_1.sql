Create PROCEDURE sp_InsertEmp1
	(@empname varchar (20) ,
	@empsal float ,
	@gender varchar (6))
	
AS
Begin

	insert into EmployeeTable(empName,empSal,gender) values (@empname ,@empsal ,@gender)

end



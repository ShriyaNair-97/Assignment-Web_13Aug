CREATE PROCEDURE sp_Search
	@empId int
AS
	SELECT EmpName,EmpSal from EmployeeTable
	where @empId = EmpId


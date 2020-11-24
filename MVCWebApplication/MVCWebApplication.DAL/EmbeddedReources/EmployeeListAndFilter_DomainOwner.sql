DECLARE
--@statusId AS INT,  --will be passed from backend
--@employeeName AS VARCHAR(50) , ----will be passed from backend
--@employeeCode AS INT,--will be passed from backend
--@resignationStatus AS VARCHAR(20),--will be passed from backend
--@approvedFromDate AS DATE = null,--will be passed from backend
--@approvedToDate AS DATE = GETDATE(), --never be null, 
--@initiatedFromDate AS DATE = null, --will be passed from backend
--@limit as int = 10 , --will be passed from backend
--@exitCheckListStatus as tinyint , --will be passed from backend i.e status which is in request
--@resignationStatusBit AS INT = 5, -- will be passed from backend
--@pageNumber AS INT = 1, -- will be passed from backend
--@IsEnabledFilter as bit,
--@initiatedToDate AS DATE = GETDATE(), --never null,
--@employeeRegisterid UNIQUEIDENTIFIER='13481B4F-C647-40DA-BBAA-8681BF2C34B2',
@deafaultApprovedDate AS DATE = (SELECT Min(ResignationApprovedDate) FROM Resignation.Resignation),
@defaultInitiatedDate AS DATE = (SELECT Min(InitiatedDate) FROM Resignation.ExitActivity),
@limit as int = 10  ---Requirement : Sending Ten Records Everytime fixed

SELECT DISTINCT(resignation.ResignationId), 
CONCAT(Employee.FirstName,' ',employee.LastName) AS EmployeeName,
employee.EmployeeCode,
resignation.ResignationApprovedDate,
exitAct.InitiatedDate,
Resignation.DeletedDate,
resignation.ExitActivityStatusId	
FROM Resignation.Resignation resignation	
INNER JOIN Employee.Employee employee
ON resignation.EmployeeId = employee.EmployeeId
JOIN Resignation.ExitActivity exitAct
ON exitAct.ResignationId=resignation.ResignationId
WHERE resignation.DeletedDate IS NULL 
AND DomainId= (SELECT DomainId FROM Employee.Employee
					WHERE EmployeeRegisterId=@employeeRegisterid) 
			 
AND resignation.ResignationStatusId = @resignationStatusBit 
AND resignation.ExitActivityStatusId = ISNULL(@exitCheckListStatus, resignation.ExitActivityStatusId)
AND CONCAT((employee.FirstName), ' ',(employee.LastName)) LIKE '%'+ISNULL(@employeeName,CONCAT((employee.FirstName), ' ',(employee.LastName))) + '%'
AND employee.EmployeeCode = IsNull(@employeeCode,employee.EmployeeCode)
AND resignation.ResignationApprovedDate >= ISNULL(@approvedFromDate,@deafaultApprovedDate) 
AND exitAct.InitiatedDate >= ISNULL(@initiatedFromDate,@defaultInitiatedDate)	 
AND exitAct.InitiatedDate <= case when( @IsEnabledFilter = 1)then
													 @initiatedToDate
										   else
													exitAct.InitiatedDate
										   END

AND resignation.ResignationApprovedDate <= case when(@IsEnabledFilter = 1)then
													@approvedToDate
										   else
													resignation.ResignationApprovedDate
										   END
ORDER BY ResignationId desc
OFFSET (@pageNumber-1)*@limit ROW FETCH NEXT @limit ROWS ONLY


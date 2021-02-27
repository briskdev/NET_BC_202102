CREATE TABLE Employees(
	Emp_Id INT NOT NULL,
	Emp_Name NVARCHAR(50) NOT NULL,
	Emp_Job_Name NVARCHAR(50) NOT NULL,
	Emp_Manager_Id INT NULL,
	Emp_Hire_Date DATETIME NOT NULL,
	Emp_Salary DECIMAL(8,2) NOT NULL,
	Emp_Department_Id INT NOT NULL
)

CREATE TABLE Salary_Grades(
	Grade_Id INT NOT NULL,
	Grade_Min_Salary INT NOT NULL,
	Grade_Max_Salary INT NOT NULL
)

CREATE TABLE Departments(
	Dep_Id INT NOT NULL,
	Dep_Name NVARCHAR(50) NOT NULL,
	Dep_Location NVARCHAR(200) NULL
)

INSERT INTO Departments (Dep_Id, Dep_Name, Dep_Location)
VALUES (101, 'HQ', 'SYDNEY')
INSERT INTO Departments (Dep_Id, Dep_Name, Dep_Location)
VALUES (201, 'SUPPORT', 'MELBOURNE')
INSERT INTO Departments (Dep_Id, Dep_Name, Dep_Location)
VALUES (301, 'MARKETING', 'PERTH')
INSERT INTO Departments (Dep_Id, Dep_Name, Dep_Location)
VALUES (401, 'PRODUCTION', 'BRISBANE')


INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10010, 'JOHN', 'PRESIDENT', '1990-12-19', 6000.00, 101)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10020, 'MISTY', 'MANAGER', 10010, '1990-06-02', 2750.00, 301)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10030, 'ADAM', 'MANAGER', 10010, '1990-07-08', 2550.00, 101)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10040, 'PEPPER', 'EXECUTIVE', 10010, '1990-03-31', 2957.00, 201)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10050, 'SCARLET', 'ANALYST', 10040, '1996-03-18', 3100.00, 201)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES (10060, 'PATRICK', 'TECHNICIAN', 10040, '1990-12-03', 3100.00, 201)


INSERT INTO Salary_Grades (Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES (1, 800, 1300)
INSERT INTO Salary_Grades (Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES (2, 1301, 1500)
INSERT INTO Salary_Grades (Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES (3, 1501, 2100)
INSERT INTO Salary_Grades (Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES (4, 2101, 3100)
INSERT INTO Salary_Grades (Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES (5, 3101, 9999)
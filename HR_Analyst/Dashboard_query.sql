USE master
GO
CREATE DATABASE HR_ANALYST
GO
use HR_ANALYST
CREATE TABLE [Employee_DIM] (
  [EmployeeID] integer PRIMARY KEY,
  [FirstName] nvarchar(50),
  [LastName] nvarchar(50),
  [Gender] nvarchar(10),
  [Age] int,
  [BusinessUnitID] integer,
  [SeniorityID] int,
  [DepartmentID] int
)
GO

CREATE TABLE [Department_DIM] (
  [DepartmentID] integer PRIMARY KEY,
  [DP_Name] nvarchar(50)
)
GO

CREATE TABLE [DATE_DIM] (
  [DATEID] integer PRIMARY KEY,
  [DAY] INT,
  [DAY_NAME] NVARCHAR(40),
  [MONTH] INT,
  [MONTH_NAME] NVARCHAR(40),
  [QUARTER] INT,
  [QUARTER_NAME] NVARCHAR(40),
  [YEAR] INT
)
GO

CREATE TABLE [Seniority_DIM] (
  [SeniorityID] integer PRIMARY KEY,
  [SeniorityName] nvarchar(50)
)
GO

CREATE TABLE [AgeBanding_DIM] (
  [AgeBandingID] integer PRIMARY KEY,
  [Name] nvarchar(50),
  [AgeRangeFrom] integer,
  [AgeRangeTo] int
)
GO

CREATE TABLE [TenureBanding_DIM] (
  [TenureBandingID] integer PRIMARY KEY,
  [Name] nvarchar(50),
  [TenureFrom] integer,
  [TenureTo] int
)
GO

CREATE TABLE [BusinessUnit_DIM] (
  [BusinessUnitID] integer PRIMARY KEY,
  [Name] nvarchar(50)
)
GO

CREATE TABLE [ContractType_DIM] (
  [ContractTypeID] integer PRIMARY KEY,
  [Name] nvarchar(50)
)
GO

CREATE TABLE [SalaryRange_DIM] (
  [SalaryRangeID] integer PRIMARY KEY,
  [Name] nvarchar(50),
  [SalaryFrom] integer,
  [SalaryTo] int
)
GO

CREATE TABLE [Headcount_FACT] (
  [HeadcountID] integer PRIMARY KEY,
  [EmployeeID] integer,
  [DepartmentID] int,
  [DATEID] int,
  [Gender] nvarchar(10),
  [BaseSalary] float,
  [AgeBandingID] int,
  [TenureBandingID] int,
  [ContractTypeID] int,
  [SeniorityLevelID] int
)
GO

CREATE TABLE [Hiring_FACT] (
  [ID] integer PRIMARY KEY,
  [EmployeeID] integer,
  [DATEID] int,
  [Gender] nvarchar(10),
  [ContractTypeID] int,
  [HireDate] date,
  [AgeBandingID] int
)
GO

CREATE TABLE [Leave_FACT] (
  [ID] integer PRIMARY KEY,
  [EmployeeID] integer,
  [BusinessUnitID] integer,
  [DATEID] int,
  [Category] nvarchar(50),
  [Days] float
)
GO

CREATE TABLE [Termination_FACT] (
  [ID] integer PRIMARY KEY,
  [EmployeeID] integer,
  [Category] nvarchar(50),
  [DATEID] int,
  [SeniorityID] int,
  [TenureBandingID] int
)
GO

ALTER TABLE [Employee_DIM] ADD FOREIGN KEY ([BusinessUnitID]) REFERENCES [BusinessUnit_DIM] ([BusinessUnitID])
GO

ALTER TABLE [Employee_DIM] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department_DIM] ([DepartmentID])
GO

ALTER TABLE [Employee_DIM] ADD FOREIGN KEY ([SeniorityID]) REFERENCES [Seniority_DIM] ([SeniorityID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([AgeBandingID]) REFERENCES [AgeBanding_DIM] ([AgeBandingID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([ContractTypeID]) REFERENCES [ContractType_DIM] ([ContractTypeID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([DATEID]) REFERENCES [DATE_DIM] ([DATEID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department_DIM] ([DepartmentID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([EmployeeID]) REFERENCES [Employee_DIM] ([EmployeeID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([SeniorityLevelID]) REFERENCES [Seniority_DIM] ([SeniorityID])
GO

ALTER TABLE [Headcount_FACT] ADD FOREIGN KEY ([TenureBandingID]) REFERENCES [TenureBanding_DIM] ([TenureBandingID])
GO

ALTER TABLE [Hiring_FACT] ADD FOREIGN KEY ([EmployeeID]) REFERENCES [Employee_DIM] ([EmployeeID])
GO

ALTER TABLE [Hiring_FACT] ADD FOREIGN KEY ([ContractTypeID]) REFERENCES [ContractType_DIM] ([ContractTypeID])
GO

ALTER TABLE [Hiring_FACT] ADD FOREIGN KEY ([AgeBandingID]) REFERENCES [AgeBanding_DIM] ([AgeBandingID])
GO

ALTER TABLE [Leave_FACT] ADD FOREIGN KEY ([EmployeeID]) REFERENCES [Employee_DIM] ([EmployeeID])
GO

ALTER TABLE [Leave_FACT] ADD FOREIGN KEY ([BusinessUnitID]) REFERENCES [BusinessUnit_DIM] ([BusinessUnitID])
GO

ALTER TABLE [Leave_FACT] ADD FOREIGN KEY ([DATEID]) REFERENCES [DATE_DIM] ([DATEID])
GO

ALTER TABLE [Termination_FACT] ADD FOREIGN KEY ([EmployeeID]) REFERENCES [Employee_DIM] ([EmployeeID])
GO

ALTER TABLE [Termination_FACT] ADD FOREIGN KEY ([DATEID]) REFERENCES [DATE_DIM] ([DATEID])
GO

ALTER TABLE [Termination_FACT] ADD FOREIGN KEY ([SeniorityID]) REFERENCES [Seniority_DIM] ([SeniorityID])
GO

ALTER TABLE [Termination_FACT] ADD FOREIGN KEY ([TenureBandingID]) REFERENCES [TenureBanding_DIM] ([TenureBandingID])
GO

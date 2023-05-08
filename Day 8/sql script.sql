create database employeeManagement

use employeeManagement

create table deptInfo
(
	deptNo int primary key,
	deptName varchar(20),
	deptCity varchar(20),
	
	constraint unk_deptName unique (deptName)
)
insert into deptInfo values(10,'Accounts','Pune')
insert into deptInfo values(20,'IT','San Franscico')
insert into deptInfo values(30,'Sales','NYK')
insert into deptInfo values(40,'HR','Mumbai')
insert into deptInfo values(50,'Advt','Chennai')

create table empInfo
(
	empNo int primary key,
	empName varchar(20) not null,
	empDesignation varchar(20) not null,
	empSalary int not null,
	empDeptNo int not null,
	empIsPermenant bit not null,

	constraint chk_empName_length check(len(empName) > 2),
	constraint chk_empDesignation check(empDesignation in ('Developer','Manager','HR')),
	constraint chk_empSalary_range check (empSalary between 12000 and 50000),
	constraint fk_empDeptNo foreign key (empDeptNo) references deptInfo
)





INSERT INTO empInfo (empNo, empName, empDesignation, empSalary, empDeptNo, empIsPermenant)VALUES  (1, 'John Smith', 'Developer', 35000, 30, 1),  (2, 'Jane Doe', 'Manager', 45000, 20, 1),  (3, 'Bob Johnson', 'HR', 28000, 30, 0),  (4, 'Mary Brown', 'Developer', 42000, 30, 0),  (5, 'Tom Lee', 'Manager', 48000, 20, 1),  (6, 'Samantha Chen', 'Developer', 39000, 10, 1),  (7, 'David Kim', 'HR', 32000, 20, 0)









  select * from deptInfo
  select * from empInfo


















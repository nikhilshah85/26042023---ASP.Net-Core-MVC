create database bankingDB

use bankingDB

create table AccountsInfo
(
	accNo int primary key,
	accName varchar(20),
	accType varchar(20),
	accBalance int,
	accIsActive bit
)


insert into AccountsInfo values(101,'Nikhil','Savings',8000,1)
insert into AccountsInfo values(102,'Rahul','Current',18000,1)
insert into AccountsInfo values(103,'Sumit','Savings',28000,0)
insert into AccountsInfo values(104,'Karan','Savings',38000,1)
insert into AccountsInfo values(105,'Mohan','Current',48000,1)
insert into AccountsInfo values(106,'Rohan','Savings',86000,0)
insert into AccountsInfo values(107,'Sohan','Current',12000,1)




select * from AccountsInfo


create table branchInfo
(
	brNo int primary key,
	brName varchar(20),
	brCity varchar(20)
)
insert into branchInfo values(10,'Hi-tech','Hyderabad')
insert into branchInfo values(20,'Navallur','Chennai')
insert into branchInfo values(30,'Baner','Pune')
insert into branchInfo values(40,'Whitefield','Bangalore')


alter table accountsInfo add accLastName varchar(20)

select * from AccountsInfo
















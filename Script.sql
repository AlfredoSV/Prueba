CREATE DATABASE Exercise2;
Use Exercise2;

if object_id('employees') is not null
BEGIN
	drop table employees;
	CREATE TABLE employees(employeeId int,
	firstName varchar(40), lastName varchar(40),
	salary money);

END
else
begin
CREATE TABLE employees(employeeId int,
	firstName varchar(40), lastName varchar(40),
	salary money);
end
create database DbEmpl

use DBEmpl

create table employee(
EmpId int primary key identity,
Department varchar(50),
FName varchar(50),
Gender varchar(50),
MaritalStatus varchar(50)
)

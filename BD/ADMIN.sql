create database Colegio
go
use colegio
go

create table Usuarios(
UsuarioID int identity(1,1) primary key,
LoginName nvarchar(100) unique not null,
Password nvarchar(100) not null, 
FirsName nvarchar(100) not null, 
LastName nvarchar(100) not null, 
Position nvarchar(100) not null, 
Email nvarchar(100) not null, 
);

insert into Usuarios values ('admin','admin','Danny','Crisostomo','Administrador','Kyuren@gmail.com');
insert into Usuarios values ('Dominic','abc123456','Brayan','Villar','Gerente','Dominic@gmail.com');
insert into Usuarios values ('kity','abc123456','Viviana','Nuñez','CFO','Kity@gmail.com');

select * from usuarios;

declare @Usuario nvarchar(100)='admin';
declare @Contraseña nvarchar(100)='admin';

select * from usuarios where LoginName=@usuario and Password=@Contraseña
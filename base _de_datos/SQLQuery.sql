USE DBVentas
create table Acceso(
AccesoId int primary key identity,
Usuario varchar(18) not null,
Passw varchar(15) not null 

)
select*from Acceso

Insert into Acceso(Usuario,Passw) Values('SergioN','0024')

Insert into Acceso(Usuario,Passw) Values(,)
create database Ph0n3_St0r3;
GO

use Ph0n3_St0r3;
GO

create table Rol(
Role_Id int identity(1,1) primary key not null,
Rol_Desc nvarchar(50) not null,
Creation_Date date default getdate()
);
GO

create table Proveedores(
Prov_Id int identity(1,1) primary key not null,
Document nvarchar(50) not null,
Prov_Name nvarchar(50) not null,
Gmail nvarchar(60) not null,
Telephone char(8) check(Telephone like '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,
Prov_Address nvarchar(120),
Prov_State bit default 1 not null,
Creation_Date date default getdate()
);
GO


create table Cliente(
Client_Id int identity(1,1) primary key not null,
Cedula char(16) CHECK (Cedula LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]') not null,
Client_FullName nvarchar(50) not null,
Gmail nvarchar(60),
Pssword nvarchar(60),
Telephone char(8) check(Telephone like '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,
Creation_Date date default getdate()
);
GO


create table Empleado(
Id_Empleado int identity(1,1) primary key not null,
Cedula char(16) CHECK (Cedula LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]') not null,
Employee_FullName nvarchar(50) not null,
Gmail nvarchar(60) not null,
Pssword nvarchar(50) not null,
Role_Id int foreign key references Rol(Role_Id) not null,
User_State bit default 1 not null,
Creation_Date date default getdate()
);
GO


create table Marca(
Id_Marca int identity(1,1) primary key not null,
Marca_Name nvarchar(50) not null,
Marca_State bit default 1 not null,
Creation_Date date default getdate()
);
GO



create table Producto(
Prod_Id int identity(1,1) primary key not null,
Prod_Cod nvarchar(50) not null,
Prod_Name nvarchar(25) not null,
Prod_Description nvarchar(50) not null,
Id_Marca int foreign key references Marca(Id_Marca) on update cascade not null,
Stock int not null default 0,
Purchase_Price numeric(18,2) default 0,
Sale_Price numeric(18,2) default 0,
Prod_State bit default 1,
Imagen nvarchar(250),
Reg_Date date default getdate()
);
GO


create table Compra(
Purchase_Id int identity(1,1) primary key not null,
Id_Empleado int foreign key references Empleado(Id_Empleado) not null,
Prov_ID int foreign key references Proveedores(Prov_Id) not null,
Doc_Num nvarchar (50) not null,
Doc_Type nvarchar(50) not null,
Total numeric(18,2) not null,
Reg_Date date default getdate()
);
GO


create table Det_Compra(
Purc_Det_Id int identity(1,1) primary key not null,
Purchase_Id int foreign key references Compra(Purchase_Id) not null,
Prod_Id int foreign key references Producto(Prod_Id) not null,
Purchase_Price numeric(18,2) not null,
Sale_Price numeric(18,2) not null,
Stock int not null,
Total Decimal(18,2) not null,
Reg_Date date
);
GO

create table Tipos_Pago(
Id_Tipo_Pago int identity (1,1) primary key not null,
Descripcion nvarchar(50) not null
);
go
--Credito 1
--Efectivo 2

insert into Tipos_Pago values ('Credito'),('Efectivo')

create table Estado_Pago(
Id_Estado_Pago int identity (1,1) primary key not null,
Descripcion nvarchar(50) not null
);
go
--Pagada 1
--Anulada 2

insert into Estado_Pago values ('Pagada'),('Anulada')

create table Venta(
Sale_Id int identity(1,1) primary key not null,
Id_Empleado int foreign key references Empleado(Id_Empleado),
Client_Id int foreign key references Cliente(Client_Id) not null,
Id_Tipo_Pago int foreign key references Tipos_Pago(Id_Tipo_Pago) default 1 not null,
Id_Estado_Pago int foreign key references Estado_Pago(Id_Estado_Pago) default 1 not null,
Card_Num char(19) Check (Card_Num like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
Pay_Amount numeric(18,2) not null,
Change_Amount numeric(18,2)  not null,
Total_Amount numeric(18,2)  not null,
Reg_Date date default getdate()
);
GO


create table Det_Venta(
Det_Sale_Id int identity(1,1) primary key not null,
Sale_Id int foreign key references Venta(Sale_Id) not null,
Prod_Id int foreign key references Producto(Prod_Id) not null,
Sale_Price numeric(18,2) not null,
Quantity int not null,
SubTotal decimal(10,2) not null,
Creation_Date date default getdate()
);
GO

----NUEVA TABLA------

Create table Negocio(
Id_Negocio int primary key not null,
Nombre Nvarchar (60) not null,
RUC nvarchar(60) not null,
Direccion nvarchar(60) not null,
Logo varbinary(max) NULL
);
GO
insert into Negocio(Id_Negocio, Nombre, RUC, Direccion)
values (1, 'Phone Store', '091101', '12.1959769, -86.0959492 pQCT');
GO



insert into Rol(Rol_Desc)
values ('ADMIN'),('EmpleadoVentas'),('EmpleadoCompras');
GO


 ---DBCC CHECKIDENT ('Marca', RESEED, 0);


insert into Empleado(Cedula, Employee_FullName, Gmail, Pssword, Role_Id, User_State)
values ('001-101010-1031D', 'ADMIN-nombre', 'CR7@gmail.com', '123', 1,1),
('001-202020-1023D', 'Empleado-Ventas1', 'MESSI@gmail.com', '456', 2,1),
('001-303030-1042D','Empleado-Compras1','NEYMAR@gmail.com','789',3,1),
('001-505050-1032D','Empleado-Ventas2','Modric@gmail.com','147',2,1),
('001-606060-1022D','Empleado-Compras2','Iniesta@gmail.com','258',3,1);
GO



--select * from Rol
--select * from Permiso
--select * from Empleado



-- Desde aqui los procedimientos relacionados a Usuario del ModuloPresentacion ------

-- --
create procedure SP_REGISTRAREMPLEADO(
@Cedula char(14),
@User_Fullname nvarchar(50),
@Gmail nvarchar(60),
@Pssword nvarchar(50),
@Role_Id int,
@User_State bit,
@IdUsuarioResultado int output,
@Mensaje nvarchar(500) output
)
as
begin
   set @IdUsuarioResultado=0
   set @Mensaje=''  --   <-- Originalmente esto no lo puso engel, voy a ver si con esto igual corre, si no lo quiot
   if  not exists(select * from Empleado where Cedula=@Cedula)
   begin
    insert into Empleado(Cedula,Employee_FullName,Gmail,Pssword,Role_Id,User_State) values
	(@Cedula,@User_Fullname,@Gmail,@Pssword,@Role_Id ,@User_State)

	set @IdUsuarioResultado=SCOPE_IDENTITY()
   end
   else
    set @Mensaje='No se Puede Repetir el documento para mas de un usuario'
end;
GO


-- --
create procedure SP_EDITAREMPLEADO(
@Id_User int,
@Cedula nvarchar(50),
@User_Fullname nvarchar(50),
@Gmail nvarchar(60),
@Pssword nvarchar(50),
@Role_Id int,
@User_State bit,
@IdUsuarioResultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @IdUsuarioResultado=0
  set @Mensaje=''

  if not exists(select * from Empleado where Cedula=@Cedula and Id_Empleado!=@Id_User)
  begin
   update Empleado set
   Cedula=@Cedula,
   Employee_FullName=@User_Fullname,
   Gmail=@Gmail,
   Pssword=@Pssword,
   Role_Id=@Role_Id,
   User_State=@User_State
   where Id_Empleado=@Id_User 

   set @IdUsuarioResultado=1
  end
  else
    set @Mensaje='No se Puede Repetir El Documento para mas de un Usuario'
end;
GO


-- --
create procedure SP_ELIMINARUSUARIO(
@Id_User int,
@IdUsuarioResultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @IdUsuarioResultado=0
  set @Mensaje=''
  declare @rulepass bit=1

  if exists(select * from Compra C inner join
  Empleado U on U.Id_Empleado=C.Id_Empleado
  where U.Id_Empleado=@Id_User
  )
  begin
    set @rulepass=0
    set @IdUsuarioResultado=0
	set @Mensaje = @Mensaje + 'El Usuario se Encuentra Relacionado a la Compra\n'
  end

  if exists(select * from Venta V inner join
  Empleado U on U.Id_Empleado=V.Id_Empleado
  where U.Id_Empleado=@Id_User
  )
  begin
    set @rulepass=0
    set @IdUsuarioResultado=0
	set @Mensaje = @Mensaje + 'El Usuario se Encuentra Relacionado a la Venta\n'
  end

  if(@rulepass=1)
  begin
    delete from Empleado WHERE Id_Empleado = @Id_User  ---  <--Le agrege un where no se
	set @IdUsuarioResultado=1
  end
end;
GO




-- Desde aqui los procedimientos relacionados a Marca ------

insert into Marca(Marca_Name, Marca_State) values('Samsung', 1)
,('Xiaomi', 1)
,('OnePLus', 1);
GO



create procedure SP_RegistrarMarca(
@Marca_Name nvarchar(500),
@Marca_State bit,
@Resultado int output,
@Mensaje nvarchar(500) output
)
as
begin
   set @Resultado=0
   if not exists(Select * from Marca where Marca_Name=@Marca_Name)
   begin
     insert into Marca(Marca_Name, Marca_State) values (@Marca_Name, @Marca_State)
	 set @Resultado=SCOPE_IDENTITY()
   end
   else
     set @Mensaje='No Se Puede Repetir la descripcion de una Marca'
end;
GO



create procedure SP_EditarMarca(
@Id_Marca int,
@Marca_State bit,
@Marca_Name nvarchar(50),
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @Resultado=1
  if not exists (select * from Marca where @Marca_Name=Marca_Name and Id_Marca!=@Id_Marca)

     update Marca set
     	 Marca_Name=@Marca_Name,
	 Marca_State=@Marca_State
     where Id_Marca=@Id_Marca
  else
     set @Resultado=0
	 set @Mensaje='No se Puede Repetir la Descripcion de una Marca'
end;
GO


create procedure sp_EliminarMarca(
@Id_Marca int,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @Resultado=1
  if not exists (select * from Marca m inner join Producto p on p.Id_Marca = m.Id_Marca
  where m.Id_Marca=@Id_Marca)
  begin
     delete top (1) from Marca where Id_Marca=@Id_Marca
  end
  else
  begin
    set @Resultado=0
	set @Mensaje='La Marca se encuentra relacionada a un producto'
  end
end;
GO





-- Desde aqui los procedimientos relacionados a Producto ------
insert into Producto(Prod_Cod, Prod_Name, Prod_Description, Id_Marca, Stock, Purchase_Price, Sale_Price, Prod_State, Reg_Date)
values ('TEL001', 'S24 Ultra', 'SP-885gen2/12-ram/512gb', 1, 50, 799.99, 999.99, 1, GETDATE());
GO



create procedure sp_RegistrarProducto(
@Prod_Cod nvarchar(50),
@Prod_name nvarchar(25),
@Prod_description nvarchar(50),
@Id_Marca int,
@Prod_State bit,
@Image nvarchar(250),
@Resultado bit output,
@Mensaje nvarchar(50) output
)
as
begin
   set @Resultado=0
   if not exists(select * from Producto where Prod_Cod=@Prod_Cod)
   begin
       insert into Producto(Prod_Cod,Prod_Name,Prod_Description,Id_Marca, Prod_State, Imagen) values (@Prod_Cod,@Prod_name,@Prod_description,@Id_Marca, @Prod_State, @Image)
	   set @Resultado=SCOPE_IDENTITY()
	end
	else
	  set @Mensaje='Ya Existe un producto con el mismo Codigo'
end;
GO





create procedure sp_ModificarProducto(
@Prod_Id int,
@Prod_Cod nvarchar(50),
@Prod_Name nvarchar(25),
@Prod_Description nvarchar(50),
@Id_Marca int,
@Prod_State bit,
@Image nvarchar(250),
@Resultado bit output,
@Mensaje nvarchar(50) output
)
as
begin
    set @Resultado=1
	if not exists(select * from Producto where Prod_Cod=@Prod_Cod and Prod_Id!=@Prod_Id)

          update Producto set
		  Prod_Cod=@Prod_Cod,
		  Prod_Name=@Prod_Name,
		  Prod_Description=@Prod_Description,
		  Id_Marca=@Id_Marca,
		  Prod_State=@Prod_State,
		  Imagen=@Image
		  where Prod_Id=@Prod_Id
	else
	begin
	  set @Resultado=0
	  set @Mensaje='Ya Existe un producto con el mismo codigo'
	end
end;
GO




create procedure sp_EliminarProducto(
@Prod_Id int,
@Respuesta bit output,
@Mensaje nvarchar(50) output
)
as
begin
   set @Respuesta=0
   set @Mensaje=''
   declare @rulepass bit=1

   if exists (select * from Det_Compra dc inner join Producto p on p.Prod_Id=dc.Prod_Id
   where p.Prod_Id=@Prod_Id)
   begin
     set @rulepass=0
	 set @Respuesta=0
	 set @Mensaje=@Mensaje + 'No Se Puede eliminar porque se encuentra relacionado a una Compra\n'
   end

   if exists (select * from Det_Venta dv inner join Producto p on p.Prod_Id=dv.Prod_Id 
   where p.Prod_Id=@Prod_Id)
   begin
      set @rulepass=0
	  set @Respuesta=0
	  set @Mensaje=@Mensaje + 'No se puede eliminar por que se encuentra relacionado a una Venta\n'
   end

   if(@rulepass=1)
   begin
     delete from Producto where Prod_Id=@Prod_Id
	 set @Respuesta=1
   end
end;
GO


--select * from Producto
--select * from Marca





-- Desde aqui los procedimientos relacionados a Cliente ------



create procedure sp_RegistrarCliente(
@Cedula char(14),
@Client_Fullname nvarchar(50),
@Gmail nvarchar(60),
@clave nvarchar(50),
@Telephone char(8),
@Resultado bit output,
@Mensaje nvarchar(50) output
)
as
begin
   set @Resultado=0
   declare @IdPerson int
   if not exists (select * from Cliente 
   where Cedula=@Cedula)
   begin
      insert into Cliente(Cedula,Client_FullName,Gmail, Pssword,Telephone) values (@Cedula,@Client_Fullname,@Gmail, @clave,@Telephone)

	  set @Resultado=SCOPE_IDENTITY()
	end
	else
	  set @Mensaje='El Numero de Cedula ya Existe'
end;
GO



create procedure sp_ModificarCliente(
@Client_Id int,
@Cedula char(14),
@Client_Fullname nvarchar(50),
@gmail nvarchar(60),
@clave nvarchar(50),
@telephone char(8),
@Resultado bit output,
@Mensaje nvarchar(50) output
)
as
begin
  set @Resultado=1
  declare @IdPerson int
  if not exists(select * from Cliente where Cedula=@Cedula and Client_Id!=@Client_Id)     
  begin
    update Cliente set
	Cedula=@Cedula,
	Client_FullName=@Client_Fullname,
	Gmail=@gmail,
	Pssword=@clave,
	Telephone=@telephone
	where Client_Id=@Client_Id
  end
  else
  begin
    set @Resultado=0
	set @Mensaje='El Numero de Cedula Ya Existe'
  end
end;
GO




-- Desde aqui los procedimientos relacionados a Proveedores ------

create procedure sp_RegistrarProveedor(
@Documen nvarchar(50),
@Prov_name nvarchar(50),
@Gmail nvarchar(60),
@Telephone char(8),
@Prov_State bit,
@Resultado bit output,
@Mensaje nvarchar(50) output
)
as
begin
   set @Resultado=0
   declare @IdPerson int
   if not exists (select * from Proveedores 
   where Document=@Documen)
   begin
      insert into Proveedores(Document,Prov_Name,Gmail,Telephone,Prov_State) values (@Documen,@Prov_name,@Gmail,@Telephone,@Prov_State)

	  set @Resultado=SCOPE_IDENTITY()
	end
	else
	  set @Mensaje='El Numero de Documento ya Existe'
end;
GO



create procedure sp_ModificarProveedor(
@Prov_Id int,
@Documen nvarchar(50),
@Prov_name nvarchar(50),
@Gmail nvarchar(60),
@Telephone char(8),
@Prov_State bit,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @Resultado=1
  declare @IdPerson int
  if not exists(select * from Proveedores where Document=@Documen and Prov_Id!=@Prov_Id)     
  begin
    update Proveedores set
	Document=@Documen,
	Prov_Name=@Prov_name,
	Gmail=@Gmail,
	Telephone=@Telephone,
	Prov_State=@Prov_State
	where Prov_Id=@Prov_Id
  end
  else
  begin
    set @Resultado=0
	set @Mensaje='El Numero de Documento Ya Existe'
  end
end;
GO

create procedure sp_EliminarProveedor(
@Prov_Id int,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
  set @Resultado=1
  if not exists (select * from Proveedores p inner join Compra c on p.Prov_Id = c.Prov_ID
  where p.Prov_Id=@Prov_Id)
  begin
     delete top (1) from Proveedores where Prov_Id = @Prov_Id
  end
  else
  begin
    set @Resultado=0
	set @Mensaje='El Proveedor se encuentra relacionado a una Compra'
  end
end;
GO


----Desde Aqui Los Proc de Compras------

create type [dbo].[Det_Compra] as table(
	[Prod_Id] int null,
	[Purchase_Price] numeric(18,2) null,
	[Sale_Price] numeric(18,2) null,
	[Stock] int null,
	[Total] numeric(18,2) null
);
GO



create procedure sp_RegistrarCompra(
@Id_User int,
@Prov_ID int,
@Doc_Type nvarchar(50),
@Doc_Num nvarchar(50),
@total numeric(18,2),
@DetalleCompra [Det_Compra] readonly,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin

	begin try
			declare @Purchase_Id int = 0
			set @Resultado = 1
			set @Mensaje = ''

			begin transaction registro
			--registro compra
			insert into Compra(Id_Empleado, Prov_Id, Doc_Type, Doc_Num, Total)
			values(@Id_User, @Prov_Id, @Doc_Type, @Doc_Num, @Total)

			set @Purchase_Id = SCOPE_IDENTITY()
			
			--registro Det_compra
			insert into Det_Compra(Purchase_Id, Prod_Id, Purchase_Price, Sale_Price, Stock, Total)
			select @Purchase_Id,Prod_Id, Purchase_Price, Sale_Price, Stock, Total from @DetalleCompra

			--Actualizar Stock

			update p set p.Stock = p.Stock + dc.Stock,
			p.Purchase_Price = dc.Purchase_Price,
			p.Sale_Price = dc.Sale_Price 
			from Producto p inner join @DetalleCompra dc on dc.Prod_Id = p.Prod_Id

			commit transaction registro
	end try
	begin catch
		
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()

		rollback transaction registro

	end catch
end;
GO


----Desde Aqui Los Proc de Ventas------

create type [dbo].[Det_Venta] as table(
	[Prod_Id] int null,
	[Sale_Price] numeric(18,2) null,
	[Quantity] int null,
	[SubTotal] numeric(18,2) null
);
GO

CREATE PROCEDURE sp_RegistrarVenta(
    @Id_User INT,
    @Client_Id INT,
    @Pay_Type INT, -- FK a Tipos_Pago
    @Sale_Status INT, -- FK a Estado_Pago
	@Card_Num char(19),
    @Pay_Amount numeric(18,2),
    @Change_Amount numeric(18,2),
    @Total_Amount numeric(18,2),
    @DetalleVenta [Det_Venta] READONLY,
    @Resultado BIT OUTPUT,
    @Mensaje NVARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        DECLARE @Sale_Id INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        -- Validar existencia de Usuario
        IF NOT EXISTS (SELECT 1 FROM Empleado WHERE Id_Empleado = @Id_User)
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'El usuario no existe.';
            RETURN;
        END

		IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Client_Id=@Client_Id)
		BEGIN
			SET @Resultado=0;
			SET @Mensaje='El Cliente no existe';
			RETURN;
		END

        -- Validar existencia de tipo de pago
        IF NOT EXISTS (SELECT 1 FROM Tipos_Pago WHERE Id_Tipo_Pago = @Pay_Type)
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'El tipo de pago especificado no existe.';
            RETURN;
        END

        -- Validar existencia del estado de pago
        IF NOT EXISTS (SELECT 1 FROM Estado_Pago WHERE Id_Estado_Pago = @Sale_Status)
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'El estado de pago especificado no existe.';
            RETURN;
        END

        BEGIN TRANSACTION registro;

        -- Registrar Venta
        INSERT INTO Venta(
            Id_Empleado, Client_Id,
            Id_Tipo_Pago, Id_Estado_Pago ,Card_Num ,Pay_Amount, Change_Amount, Total_Amount
        )
        VALUES (
            @Id_User, @Client_Id,
            @Pay_Type, @Sale_Status, @Card_Num, @Pay_Amount, @Change_Amount, @Total_Amount
        );

        SET @Sale_Id = SCOPE_IDENTITY();

        -- Registrar Detalles de Venta
        INSERT INTO Det_Venta(Sale_Id, Prod_Id, Sale_Price, Quantity, SubTotal)
        SELECT @Sale_Id, Prod_Id, Sale_Price, Quantity, SubTotal FROM @DetalleVenta;

        COMMIT TRANSACTION registro;
    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        ROLLBACK TRANSACTION registro;
    END CATCH
END;
GO


--select * from Compra
--select * from Det_Compra
--select * from Marca
--select * from Producto
--select * from Venta
--select * from Det_Venta

INSERT INTO Producto (Prod_Cod, Prod_Name, Prod_Description, Id_Marca, Stock, Purchase_Price, Sale_Price, Prod_State, Reg_Date)
VALUES 
('TEL002', 'Galaxy S23', 'Samsung Galaxy S23, 128GB', 1, 50, 799.99, 999.99, 1, GETDATE()),   -- Samsung
('TEL003', 'Galaxy A54', 'Samsung Galaxy A54, 128GB', 1, 40, 499.99, 599.99, 1, GETDATE()),    -- Samsung
('TEL004', 'Xiaomi 13 Pro', 'Xiaomi 13 Pro, 256GB', 2, 30, 649.99, 749.99, 1, GETDATE()),      -- Xiaomi
('TEL005', 'Redmi Note 12', 'Xiaomi Redmi Note 12, 128GB', 2, 25, 299.99, 399.99, 1, GETDATE()), -- Xiaomi
('TEL006', 'OnePlus 11', 'OnePlus 11, 256GB', 3, 20, 729.99, 929.99, 1, GETDATE());;
GO

INSERT INTO Proveedores (Document, Prov_Name, Gmail, Telephone, Prov_Address, Prov_State, Creation_Date)
VALUES 
('RUC001', 'Proveedor Tech', 'contacto@proveedortech.com', '25123456', 'Av. Central 123, Ciudad', 1, GETDATE()),
('RUC002', 'Distribuciones Globales', 'ventas@distglobales.com', '71234567', 'Calle Principal 456, Ciudad', 1, GETDATE()),
('RUC003', 'Suministros Digitales', 'info@suministrosdigitales.com', '87123456', 'Plaza Comercial 789, Ciudad', 1, GETDATE()),
('RUC004', 'ElectroMundo', 'contacto@electromundo.com', '58123456', 'Avenida Tecnológica 321, Ciudad', 1, GETDATE()),
('RUC005', 'Innovaciones y Servicios', 'servicios@innovserv.com', '72123456', 'Boulevard Industrial 654, Ciudad', 1, GETDATE());;
GO

update Producto set
	Imagen='Productos\Samsung Galaxy S24 Ultra.png'
where Prod_Id=1
go

update Producto set
	Imagen='Productos\Samsung Galaxy S23.png'
where Prod_Id=2
go
	
update Producto set
	Imagen='Productos\Samsung Galaxy A54.png'
where Prod_Id=3
go
	
update Producto set
	Imagen='Productos\Xiaomi 13 PRO.png'
where Prod_Id=4
go
	
update Producto set
	Imagen='Productos\Redmi Note 12.png'
where Prod_Id=5
go
	
update Producto set
	Imagen='Productos\oneplus-11.png'
where Prod_Id=6
go

insert into Cliente(Cedula,Client_FullName,Gmail,Pssword,Telephone)
values ('001-102030-1014D','Jose Manolo','Djxd@gmail.com','ventana','57211615')
go

insert into Cliente(Cedula,Client_FullName,Gmail,Pssword,Telephone)
values('002-405060-1021N','Sean Combs','seancombs@gmail.com','ibuprofeno','89721243')


select * from Cliente

select * from Empleado

select * from Producto

select * from Compra
select * from Det_Compra

select * from Venta
select * from Det_Venta



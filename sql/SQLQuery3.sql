select * from Clientes
select NombreCli, apellido from clientes
select nombreCli, apellido, ciudad from Clientes where Ciudad = 'envigado' or ciudad ='caldas'
select nombreCli, apellido, ciudad from Clientes where Ciudad in ('envigado','caldas')
drop database bancoDb
create database bancoDb
use BancoDB
CREATE TABLE [Cuenta] (
          [cuenta_id] int NOT NULL IDENTITY,
          [owner_name] nvarchar(150) NOT NULL,
          [initial_balance] int NOT NULL,
          CONSTRAINT [PK_Cuenta] PRIMARY KEY ([cuenta_id])
      );
INSERT INTO cuenta values (1,'Richard',100)
select * from cuenta
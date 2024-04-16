use hiperalmacen
drop database BancoDB
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


SELECT sqltext.TEXT,
req.session_id,
req.status,
req.command, db_name(req.database_id) as db_name,
req.cpu_time,
req.total_elapsed_time
FROM sys.dm_exec_requests req
CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS sqltext
WHERE req.status = 'running'
ORDER BY total_elapsed_time DESC
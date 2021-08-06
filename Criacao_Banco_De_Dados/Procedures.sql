CREATE PROCEDURE TodosClientes
AS
SELECT * FROM Logradouro
RETURN

CREATE PROCEDURE DeletarClientes
@email varchar(200)
AS
DELETE FROM dbo.Clientes WHERE Clientes.Email = @email
RETURN

CREATE PROCEDURE ClientesIndividuais
@email varchar(200)
AS
select * from dbo.Clientes as c WHERE c.Email = @email
RETURN
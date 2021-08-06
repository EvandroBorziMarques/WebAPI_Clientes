create database WebAPI

use WebAPI

create table Logradouro(
	_idLogradouro int Primary Key IDENTITY (1, 1),
	Cep char(8) not null,
	Endereco varchar(100),
	Numero varchar(10),
	Complemento varchar(20),
	Bairro varchar(50),
	Localidade varchar(100),
	Uf varchar(2))

create table Clientes(
	Email varchar(200) Primary Key,
	Nome varchar(100) not null,
	Logotipo varchar(100),
	IdLogradouro int not null

CONSTRAINT FK_Clientes_Logradouro_IdLogradouro FOREIGN KEY (IdLogradouro) REFERENCES Logradouro (_idLogradouro)
)

INSERT INTO [dbo].[Logradouro]
           ([Cep]
           ,[Endereco]
		   ,[Numero]
           ,[Complemento]
           ,[Bairro]
           ,[Localidade]
           ,[Uf])
     VALUES
           ('37701074',
           'Rua: Teste',
		   100,
           'APT',
           'Santa Clara',
           'Sao Paulo',
           'SP');

INSERT INTO [dbo].[Clientes]
        ([Email]
        ,[Nome]
        ,[Logotipo]
		,[IdLogradouro])
    VALUES
        ('gustavo@gmail.com',
        'Gustavo',
        'sth4whw4j56j',
		1);

INSERT INTO [dbo].[Clientes]
        ([Email]
        ,[Nome]
        ,[Logotipo]
		,[IdLogradouro])
    VALUES
        ('guilherme@gmail.com',
        'Guilherme',
        'srgrtjrg464hwrjeruw45',
		2);


	
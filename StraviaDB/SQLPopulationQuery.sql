USE [StraviaDB]
GO

-- INSERT FOR CATEGORY ITEMS --

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Junior'
           ,'menor de 15 a�os');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Sub-23'
           ,'de 15 a 23 a�os');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Open'
           ,'de 24 a 30 a�os');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Elite'
           ,'cualquiera que quiera inscribirse');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Master A'
           ,'de 30 a 40 a�os');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Master B'
           ,'de 41 a 50 a�os');

INSERT INTO [dbo].[Category]
           ([category]
           ,[description])
     VALUES
           ('Master C'
           ,'m�s de 51 a�os');

-- INSERT FOR SPORT ITEMS --

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Correr');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Nadar');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Ciclismo');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Senderismo');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Kayak');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Caminata');
GO
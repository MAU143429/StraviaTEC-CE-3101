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
           ('Running');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Swimming');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Cycling');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Hiking');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Kayaking');

INSERT INTO [dbo].[Sport]
           ([sport])
     VALUES
           ('Walking');

-- INSERT FOR SPONSOR ITEMS --

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Nike'
           ,22216106
           ,'Mark Parker'
           ,'https://static.nike.com/a/images/f_jpg,q_auto:eco/61b4738b-e1e1-4786-8f6c-26aa0008e80b/swoosh-logo-black.png');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Movistar'
           ,8000001693
           ,'José María Álvarez-Pallete'
           ,'https://movistar.cr/documents/294678201/0/Banner.jpg');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Coca-Cola'
           ,22472800
           ,'James Quincey'
           ,'https://www.bebidaslatam.com/images/stories/2019/febrero/coca.jpg');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Adidas'
           ,22016275
           ,'Kasper Rørsted'
           ,'https://www.publimark.cl/media/k2/items/cache/22c02097e4438bd2f2f3fe4a6a3ab0e1_XL.jpg');


INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Powerade'
           ,22169827
           ,'Gary Smith'
           ,'https://seeklogo.com/images/P/powerade-logo-CBAE906E36-seeklogo.com.png');
   
INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Crystal'
           ,84962514
           ,'Darner Mora Alvarado'
           ,'https://pbs.twimg.com/profile_images/699990355157127169/kyFclhRH_400x400.png');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Garmin'
           ,934972373
           ,'Clifton A. Pemble'
           ,'https://www.theoddspoke.com.au/assets/webshop/cms/74/174.jpg');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Nuun'
           ,83810665
           ,'David Mutzel'
           ,'http://napawomenshalf.events/wp-content/uploads/2017/01/lockup_logo_new_blue-01-1024x1004.png');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Kolbi'
           ,20025146
           ,'Charlie Mora'
           ,'https://halberdbastion.com/sites/default/files/styles/medium/public/2017-11/kolbi-costa-rica-logo.png');

INSERT INTO [dbo].[Sponsor]
           ([tradename]
           ,[phone]
           ,[ceo]
           ,[logo])
     VALUES
           ('Speedo'
           ,22016321
           ,'Andrew Rubin'
           ,'https://www.logopik.com/wp-content/uploads/edd/2018/08/Speedo-Logo-Vector.png');

-- INSERT FOR ORGANIZER ITEMS --

INSERT INTO [dbo].[Organizer]
           ([o_username]
           ,[o_password])
     VALUES
           ('admin1'
           ,'password1');

INSERT INTO [dbo].[Organizer]
           ([o_username]
           ,[o_password])
     VALUES
           ('admin2'
           ,'password2');

GO
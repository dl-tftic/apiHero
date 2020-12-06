CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY, 
    [FirstName] NvarCHAR(20) NOT NULL,
	[LastName] NvarCHAR(20) NOT NULL,
	[Pseudo] Nvarchar(20) NOT NULL,
	[Password] varbinary(32) not null, /*SHA2_256*/
	[Salt] nvarchar(8) not null,
	constraint PK_Users PRIMARY KEY ([Id]),
	constraint UK_Users_Pseudo UNIQUE ([Pseudo])
)

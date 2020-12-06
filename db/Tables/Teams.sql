CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL identity, 
    [Nom] NVARCHAR(16) NOT NULL, 
    [UserId] INT NOT NULL,
    [LeaderId] INT NULL, 
    constraint PK_Teams Primary key ([Id]),
    constraint FK_Teams_Users foreign key ([Userid]) references [Users]([Id])
)

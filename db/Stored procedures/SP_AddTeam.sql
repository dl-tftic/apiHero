CREATE PROCEDURE [dbo].[SP_AddTeam]
	@name nvarchar(16),
	@userId int
AS
	insert into [Teams]([Nom], [UserId]) 
		--output @@IDENTITY
		values (@name, @userId)
		select SCOPE_IDENTITY();
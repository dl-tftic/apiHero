CREATE PROCEDURE [dbo].[SP_GetUserById]
	@id int
AS
	SELECT [Id], [FirstName], [LastName], [Pseudo], '********' as [Password]
		from [Users]
		where [Id] = @id
RETURN 0

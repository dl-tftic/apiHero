CREATE PROCEDURE [dbo].[SP_GetUserAll]
AS
	SELECT [Id], [FirstName], [LastName], [Pseudo], '********' as [Password]
		from [Users]
RETURN 0

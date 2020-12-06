CREATE PROCEDURE [dbo].[SP_CheckPasswordUser]
	@pd nvarchar(16),
	@pwd nvarchar(16)
AS
	SELECT [Id]
		from [Users]
		where @pd = [Pseudo]
		and HASHBYTES('SHA2_256', [salt] + @pwd) = [Password]
		
RETURN 0

CREATE PROCEDURE [dbo].[SP_GetTeamById]
	@id int
AS
	SELECT [Id], [Nom], [UserId], [LeaderId]
		from [Teams]
		where [Id] = @id
RETURN 0

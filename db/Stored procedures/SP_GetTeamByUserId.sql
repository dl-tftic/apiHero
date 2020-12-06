CREATE PROCEDURE [dbo].[SP_GetTeamByUserId]
	@userId int
AS
	SELECT [Id], [Nom], [UserId], [LeaderId]
		from [Teams]
		where [UserId] = @userId
RETURN 0

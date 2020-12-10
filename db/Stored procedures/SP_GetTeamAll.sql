CREATE PROCEDURE [dbo].[SP_GetTeamAll]
AS
	SELECT [Id], [Nom], [UserId], [LeaderId]
		from [Teams]
RETURN 0

CREATE PROCEDURE [dbo].[SP_GetHeroesByTeamId]
	@teamId int
AS
	select [HeroId]
		from [Teams_Heroes]
		where [TeamId] = @teamId
RETURN 0

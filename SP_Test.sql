--exec [dbo].[SP_GetUserById] @id=3
--exec [dbo].[SP_AddTeam] @name = 'Team A', @userId = 3
--exec [dbo].[SP_AddHeroInTeam] @heroId=154, @teamId=1
exec [dbo].[SP_GetHeroesByTeamId] @teamId=1
exec [dbo].[SP_GetTeamById] @id=1
exec [dbo].[SP_GetUserById] @id=3
exec [dbo].[SP_CheckPasswordUser] @pd='dave', @pwd='1234'

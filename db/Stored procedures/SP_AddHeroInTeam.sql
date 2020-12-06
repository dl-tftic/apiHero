CREATE PROCEDURE [dbo].[SP_AddHeroInTeam]
	@heroId int,
	@teamId int
AS
	insert into [Teams_Heroes]([HeroId], [TeamId])
		--output @@IDENTITY
		values (@heroId, @teamId)
		select SCOPE_IDENTITY();

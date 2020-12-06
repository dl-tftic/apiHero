CREATE TABLE [dbo].[Teams_Heroes]
(
	[Id] int not null identity,
	[TeamId] INT NOT NULL , 
    [HeroId] INT not null,
	constraint PK_Teams_Heroes primary key ([TeamId], [HeroId]),
	constraint CK_FiveHeroes check (dbo.SF_GetHeroesContByTeamId(TeamId) < 5)

)

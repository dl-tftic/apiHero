CREATE FUNCTION [dbo].[SF_GetHeroesContByTeamId]
(
	@teamId int
)
RETURNS INT
AS
BEGIN
	if (OBJECT_ID('Teams_Heroes', 'T') != null)
	begin
		RETURN (select count(TeamId) FROM Teams_Heroes where TeamId = @teamId)
	end
	return 0;
END

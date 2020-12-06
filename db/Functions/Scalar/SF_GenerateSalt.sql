CREATE FUNCTION [dbo].[SF_GenerateSalt]
(
)
RETURNS nchar(8)
AS
BEGIN
	--declare @saltResult nvarchar(8), 
	--		@randomValue smallint,
	--		@i smallint
	--set @i = 0
	--while @i < 8
	--begin
	--	set @randomValue = floor(rand()*10);
	--	set @saltResult = concat(@saltResult, @randomValue);
	--	set @i = @i + 1;
	--end

	--RETURN @saltResult;
	return '00000000';
END

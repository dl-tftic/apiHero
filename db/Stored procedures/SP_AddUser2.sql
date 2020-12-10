CREATE PROCEDURE [dbo].[SP_AddUser2]
    @FirstName NvarCHAR(20),
	@LastName NvarCHAR(20),
	@Pseudo Nvarchar(20),
	@Password nvarchar(16) /*SHA2_256*/
AS
	declare @salt nchar(8);
	set @salt = dbo.SF_GenerateSalt();
	insert into [Users]([FirstName], [LastName], [Pseudo], [Password], [Salt])
		--output @@IDENTITY
		values (@FirstName, @LastName, @Pseudo, HASHBYTES('SHA2_256', concat(@salt, @Password)), @Salt)
		select SCOPE_IDENTITY();

CREATE PROCEDURE [dbo].[AjoutCategorie]
	@param1 varchar(50)
AS
	insert into categories values (@param1);

RETURN 0

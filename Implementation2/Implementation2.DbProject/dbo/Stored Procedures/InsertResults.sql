CREATE PROCEDURE [dbo].[InsertResults]
	@start int,
	@end int,
	@first varchar(100),
	@last varchar(100)
AS
	TRUNCATE TABLE [dbo].[Results];
	INSERT INTO [dbo].[Results]
	SELECT [Result] FROM [dbo].[Iterate](@start, @end, @first, @last);

	SELECT [Id], [Value] FROM [dbo].[Results];

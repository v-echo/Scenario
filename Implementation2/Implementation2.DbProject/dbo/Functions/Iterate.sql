CREATE FUNCTION [dbo].[Iterate]
(
	@start int,
	@end int,
	@first varchar(100),
	@last varchar(100)
)
RETURNS TABLE
AS
RETURN
(
	SELECT [dbo].[Divide]([Value], @first, @last) AS Result
	FROM [dbo].[GenerateIntegers](@start, @end) AS G
)

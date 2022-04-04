/* Credit to https://stackoverflow.com/a/43280746/2463738 */
CREATE FUNCTION [dbo].[GenerateIntegers]
(
	@start int,
	@end int
)
RETURNS TABLE
AS
RETURN
(
	WITH CTE AS (
		SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS [Value]
		FROM 
			(VALUES(0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) x1(x),
			(VALUES(0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) x2(x),
			(VALUES(0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) x3(x),
			(VALUES(0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) x4(x),
			(VALUES(0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) x5(x)
	)
	SELECT CTE.[Value]
	FROM CTE
	WHERE [Value] BETWEEN @start and @end
)

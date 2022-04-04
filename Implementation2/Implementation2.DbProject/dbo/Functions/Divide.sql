CREATE FUNCTION [dbo].[Divide]
(
	@value int,
	@first varchar(100),
	@last varchar(100)
)
RETURNS varchar(201)
AS
BEGIN
	RETURN
		CASE 
			WHEN @value % 15 = 0 THEN @first + ' ' +  @last
			WHEN @value % 3 = 0  THEN @first
			WHEN @value % 5 = 0 THEN @last
			ELSE CONVERT(varchar(100), @value)
		END
END


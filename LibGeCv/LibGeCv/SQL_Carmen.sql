CREATE PROCEDURE VisualizzaCV
	@Matricola nvarchar(20)
AS
SELECT Matricola FROM Curriculum WHERE Matricola=@Matricola;
GO
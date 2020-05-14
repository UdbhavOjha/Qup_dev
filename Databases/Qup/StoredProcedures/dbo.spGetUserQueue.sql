CREATE PROCEDURE [dbo].[spGetUserQueue](
	@sessionId varchar(50),
	@businessId int 
)
AS
	SELECT 
		QT.Id,
		QT.QueueJoinDateTime,
		QT.PatronId,
		QT.ActualEntryDateTime,
		U.FirstName,
		U.LastName,
		U.Email,
		U.PhoneNumber 
	FROM Users U
	INNER JOIN QueueTransactions QT ON QT.Patronid = U.Id AND QT.BusinessId = @businessId	
	WHERE U.SessionKey = @sessionId
	AND QT.ExitTime IS NULL 
GO
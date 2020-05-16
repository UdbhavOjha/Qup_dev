CREATE PROCEDURE [dbo].[spGetCustomersInQueueByDate] (
@fromDate DATETIME,
@toDate DATETIME,
@businessId INT 
)
AS
BEGIN 
	SELECT
		QT.Id AS QueueId,
		CONCAT(U.FirstName, ' ', U.LastName) AS Name, 
		QT.ActualEntryDateTime AS EntryTime,
		QT.ExitTime,
		B.Capacity 
	FROM dbo.QueueTransactions QT
		JOIN dbo.Business B ON B.Id = QT.BusinessId
		JOIN dbo.Users U ON U.Id = QT.PatronId
	WHERE 
	QT.ActualEntryDateTime BETWEEN @fromDate AND @toDate
	AND QT.BusinessId = @businessId

	UNION

	SELECT
		QT.Id AS QueueId,
		UL.Name, 
		QT.ActualEntryDateTime AS EntryTime,
		QT.ExitTime,
		B.Capacity  
	FROM dbo.QueueTransactions QT
		JOIN dbo.Business B ON B.Id = QT.BusinessId
		JOIN dbo.UserLedger UL ON UL.Id = QT.UserLedgerId
	WHERE 
	QT.ActualEntryDateTime BETWEEN @fromDate AND @toDate
	AND QT.BusinessId = @businessId
END

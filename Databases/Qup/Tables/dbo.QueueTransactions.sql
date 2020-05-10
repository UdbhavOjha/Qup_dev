CREATE TABLE [dbo].[QueueTransactions] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	BusinessId INT NOT NULL,
	QueueJoinDateTime DATETIME DEFAULT GETDATE(),
	PatronId INT NULL,
	ExpectedEntryDateTime DATETIME DEFAULT GETDATE(),
	ActualEntryDateTime DATETIME NULL,
	ExitTime DATETIME NULL,
	UserLedgerId INT NULL
)
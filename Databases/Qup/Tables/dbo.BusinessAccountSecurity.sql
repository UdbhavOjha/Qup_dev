CREATE TABLE [dbo].[BusinessAccountSecurity] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT FOREIGN KEY REFERENCES dbo.Users(Id),
	BusinessId INT FOREIGN KEY REFERENCES dbo.Business(Id)
)
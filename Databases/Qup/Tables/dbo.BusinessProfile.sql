CREATE TABLE [dbo].[BusinessProfile] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	BusinessId INT FOREIGN KEY REFERENCES Business(Id),
	ProfileImage IMAGE
)
CREATE TABLE dbo.Business (
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Name VARCHAR(200) NOT NULL, 
	[Address] VARCHAR(200) NOT NULL, 
	Capacity INT NOT NULL, 
	IsActive BIT NOT NULL, 
	DateCreated DATETIME NOT NULL DEFAULT GETDATE() 
)
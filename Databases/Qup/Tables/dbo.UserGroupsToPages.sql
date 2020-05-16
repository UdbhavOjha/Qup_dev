CREATE TABLE [dbo].[UserGroupsToPages] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserGroupId INT FOREIGN KEY REFERENCES dbo.UserGroups(Id),
	PageId INT FOREIGN KEY REFERENCES dbo.PlatformPages(Id)
)
 
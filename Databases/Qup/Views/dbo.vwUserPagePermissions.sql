CREATE VIEW [dbo].[vwUserPagePermissions] 
As
SELECT
	P.Id,
	P.Url,
	UTUG.UserId, 
	UTUG.UserGroupId, 
	UGTP.PageId 	  
FROM PlatformPages P
	INNER JOIN UserGroupsToPages UGTP ON P.Id = UGTP.PageId
	INNER JOIN UsersToUserGroups UTUG ON UGTP.UserGroupId = UTUG.UserGroupId  
	INNER JOIN  Users U ON U.Id = UTUG.UserId;
	
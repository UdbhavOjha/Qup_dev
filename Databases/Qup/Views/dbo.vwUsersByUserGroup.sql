CREATE PROCEDURE [dbo].[vwUsersByUserGroup] (
	@userGroup VARCHAR(20) = 'Patron'
)
AS
BEGIN 
	SELECT 
		FirstName, 
		LastName, 
		CONCAT(FirstName, ' ', LastName) AS FullName,
		Email, 
		PhoneNumber
	FROM dbo.Users U
		INNER JOIN dbo.UsersToUserGroups UTG ON U.Id = UTG.UserId
		INNER JOIN dbo.UserGroups UG ON UTG.UserGroupId = UG.Id
	WHERE UG.Name = @userGroup 
END
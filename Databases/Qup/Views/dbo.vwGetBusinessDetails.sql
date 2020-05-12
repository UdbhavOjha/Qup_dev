CREATE VIEW [dbo].[vwGetBusinessDetails] 
AS
SELECT
	B.Id, 
	B.Name, 
	B.[Address],
	B.Capacity,
	B.DateCreated,
	BP.ProfileImage
FROM dbo.Business B
INNER JOIN dbo.BusinessProfile BP ON BP.BusinessId = B.Id 

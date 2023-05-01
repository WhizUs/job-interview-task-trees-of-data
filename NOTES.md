# Statements

According to Alice this statement seems to be slow

```SQL
-- Get all the teams for a member from all the tree paths where the specified country is set
SET STATISTICS TIME ON

SELECT t.Id as TeamId, t.Name as TeamName, c.Id as CountryId
FROM dbo.MemberCountries mc 
JOIN Countries c ON c.Id = mc.CountryId 
JOIN Teams t ON t.Id = mc.TeamId 
JOIN Members m ON m.Id = mc.MemberId 
WHERE mc.MemberId = 1 -- Some member id
AND mc.CountryId IN (17) -- Some country id

SET STATISTICS TIME OFF
```
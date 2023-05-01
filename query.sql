SET STATISTICS TIME ON

SELECT t.Id as TeamId, t.Name as TeamName, c.Id as CountryId
FROM dbo.MemberCountries mc 
JOIN Countries c ON c.Id = mc.CountryId 
JOIN Teams t ON t.Id = mc.TeamId 
JOIN Members m ON m.Id = mc.MemberId 
WHERE mc.MemberId = 1 -- Some member id
AND mc.CountryId IN (1) -- Some country id

SET STATISTICS TIME OFF
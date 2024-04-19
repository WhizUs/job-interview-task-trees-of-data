# Notes

## Statements

According to Alice this statement seems to be slow

```SQL
-- Get all the teams for a member from all the tree paths where the specified country is set
-- see https://learn.microsoft.com/en-us/sql/t-sql/statements/set-statistics-time-transact-sql
SET STATISTICS TIME ON

SELECT t.Id as TeamId, t.Name as TeamName, c.Id as CountryId
FROM dbo.MemberCountries mc 
JOIN Countries c ON c.Id = mc.CountryId 
JOIN Teams t ON t.Id = mc.TeamId 
JOIN Members m ON m.Id = mc.MemberId 
WHERE mc.MemberId = 1 -- Some member id
AND mc.CountryId IN (1) -- Some country id

SET STATISTICS TIME OFF
```

*(see [query.sql](query.sql) file to use with the mssql extension)*

## Possible Solutions

`Bob` has already told you about a possible solution path; do you have any alternative (maybe better) ideas?
Can you compare the solutions you found?

## SQL Server

* You can start the SQL Server with `docker compose`:
```bash
docker compose up db -d
```
* Have a look at the [appsettings.json](appsettings.json) to see how to connect to the development DB

## App

If there are any issues with starting the app using `docker`one can start it directly using `dotnet`

```bash
dotnet run
```

## Codespaces

Have a look at the installed extensions (in your Codespace) if you need help with the usage of
one (or multiple) of them.

## References
* https://learn.microsoft.com/en-us/sql/t-sql/data-types/hierarchyid-data-type-method-reference
* https://learn.microsoft.com/en-us/sql/t-sql/statements/set-statistics-time-transact-sql
* https://learn.microsoft.com/en-us/sql/t-sql/statements/set-showplan-all-transact-sql

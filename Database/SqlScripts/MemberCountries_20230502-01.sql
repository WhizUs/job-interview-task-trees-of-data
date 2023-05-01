create or alter view [dbo].MemberCountries
as
select
    memberCountries.MemberId,
    memberCountries.TeamId,
    memberCountries.CountryId
from (
     select
         mt.MembersId as MemberId,
         tc.TeamId,
         tc.CountryId
     from
         [dbo].TeamCountries tc
         inner join
         [dbo].MemberTeam mt on mt.TeamsId = tc.TeamId
 ) as memberCountries
group by
    memberCountries.MemberId,
    memberCountries.TeamId,
    memberCountries.CountryId
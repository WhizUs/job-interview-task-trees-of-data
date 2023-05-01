create or alter view [dbo].TeamCountries
as
with cte as (
    select
        t.*,
        Id as BaseTeamId
    from
        [dbo].Teams as t
    union all
    select
        t.*,
        c.BaseTeamId
    from
        [dbo].Teams as t
    inner join cte as c on t.Id = c.ParentId
)
select
    t.Id as TeamId,
    cte.Id as SourceId,
    ct.CountriesId as CountryId,
    cast((case when cte.Id = t.Id then 0 else 1 end) as bit) as IsInherited
from cte
         join [dbo].Teams t on t.Id = cte.BaseTeamId
    join [dbo].CountryTeam ct on ct.TeamsId = cte.Id
    join [dbo].Countries co on co.Id = ct.CountriesId
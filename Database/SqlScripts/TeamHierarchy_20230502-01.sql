create or alter view [dbo].TeamHierarchy
as 
with cte as (
    select
        t.Id,
        t.Name,
        t.ParentId,
        Id as TeamId,
        0 as Distance
    from [dbo].Teams as t
    union all
    select
        t.Id,
        t.Name,
        t.ParentId,
        c.TeamId,
        c.Distance + 1
    from [dbo].Teams as t
    inner join cte as c on t.Id = c.ParentId
)
select
    t.Id as TeamId,
    t.Name as TeamName,
    cte.Id as ParentId,
    cte.Name as ParentName,
    cte.Distance
from cte
join [dbo].Teams t on t.Id = cte.TeamId
where t.Id != cte.Id
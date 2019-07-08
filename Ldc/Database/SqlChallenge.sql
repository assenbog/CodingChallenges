select b.Business, 
ISNULL(p.StreetNo,'') StreetNo, 
p.Street, p.PostCode, 
SUM(f.Count) FootfallCount 
from [dbo].[Footfall] f
inner join [dbo].[Premises] p on f.PremiseId = p.Id
inner join [dbo].[Businesses] b on p.BusinessId = b.Id
group by f.PremiseId, b.Business, p.StreetNo, p.Street, p.PostCode
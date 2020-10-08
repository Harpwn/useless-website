--delete from Games
--delete from Images
--delete from characters

BEGIN TRAN

PRINT 'games'
--Games
insert into Games (CreatedDate,LastModified,Name,Description,Status,Type)
SELECT GETDATE(),GETDATE(),g.Name,[dbo].[udf_StripHTML](g.Bio),(CASE WHEN g.IsActive = 1 THEN 1 ELSE 2 END),1 FROM MMOBA.dbo.Games g

--GameLogos
DECLARE @GameLogos TABLE (
	Game nvarchar(max),
	blob varbinary(max)
)

insert into @GameLogos (game,blob)
SELECT g.[Name],i.[File] From MMOBA.dbo.Images i
inner join mmoba.dbo.Games g on g.ImageId = i.Id

PRINT 'GameLogos'
INSERT into Images (CreatedDate,LastModified,[File])
SELECT GETDATE(),GETDATE(),blob FROM @GameLogos

UPDATE g set GameLogoId = i.Id
FROM Games g
inner join @GameLogos gl on gl.Game = g.Name
inner join Images i on i.[File] = gl.blob
----

COMMIT TRAN

BEGIN TRAN

DECLARE @Characters TABLE (
	[Name] nvarchar(max),
	[Description] nvarchar(max),
	[LocalGameId] nvarchar(max),
	[Icon] varbinary(max),
	[Profile] varbinary(max)
)

INSERT INTO @Characters ([Name],[LocalGameId],[Icon],[Profile],[Description])
SELECT k.[Name], gg.Id, icon.[File], prof.[File],[dbo].[udf_StripHTML](k.Bio) FROM MMOBA.dbo.Kits k
inner join mmoba.dbo.Games g on k.GameId = g.Id
inner join Games gg on gg.[Name] = g.[Name]
LEFT JOIN MMOBA.dbo.Images icon on k.KitIconId = icon.Id
LEFT JOIN MMOBA.dbo.Images prof on k.KitIconId = prof.Id

Print 'Icons'
INSERT INTO Images (LastModified,CreatedDate,[File])
SELECT GETDATE(),GETDATE(),Icon from @Characters


Print 'Profile'
INSERT INTO Images (LastModified,CreatedDate,[File])
SELECT GETDATE(),GETDATE(),[Profile] from @Characters

PRINT 'characters'
INSERT into Characters(CreatedDate,LastModified,Name,Status,Description,IconImageId,ProfileImageId,GameId)
SELECT GETDATE(),GETDATE(),c.Name,1,c.Description,null,null,c.LocalGameId From @Characters  c

PRINT 'charactersIcons'
UPDATE c set c.IconImageId = icon.Id
from Characters c
inner join @Characters cr on  cr.Name = c.Name and cr.LocalGameId = c.GameId
inner join images icon on icon.[File] = cr.Icon
where c.IconImageId is null

PRINT 'charactersProfiles'
UPDATE c set c.ProfileImageId = profile.Id
from Characters c
inner join @Characters cr on cr.Name = c.Name and cr.LocalGameId = c.GameId
inner join images profile on profile.[File] = cr.Profile
where c.ProfileImageId is null

COMMIT TRAN


select * from Games
select * from characters
select * from Images
--select * from AspNetUsers
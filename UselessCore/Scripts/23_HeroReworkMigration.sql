BEGIN TRAN

SET IDENTITY_INSERT Characters ON
INSERT INTO Characters (Id, CreatedDate, LastModified, Name, IconImageID,GameId, Status)
SELECT Id,CreatedDate,LastModified,Name,IconImageId,GameId,Status FROM Heros
SET IDENTITY_INSERT Characters OFF

INSERT INTO ValueEntries (CreatedDate,LastModified,UserId,CharacterId,Value,Type)
SELECT CreatedDate, LastModified, UserId,CharacterId,Value, 0 FROM [CharacterTierEntry<Hero>]

SET IDENTITY_INSERT StringEntries ON
INSERT INTO StringEntries (ID,CreatedDate,LastModified,UserId,CharacterId,Text,Type)
SELECT ID,CreatedDate,LastModified,UserId,CharacterId,Text,0 FROM [CharacterTipsEntry<Hero>]
SET IDENTITY_INSERT StringEntries OFF

INSERT INTO TagEntries (CreatedDate,LastModified,UserId,CharacterId,LinkedTagID,Type)
SELECT CreatedDate,LastModified,UserId,CharacterId,LinkedTagID,0 FROM [MainCharacterTagEntry<Hero>]

INSERT INTO LinkEntries (CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,Type)
SELECT CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,0 FROM [SimilarToInGameCharacterLinkEntry<Hero>]
INSERT INTO LinkEntries (CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,Type)
SELECT CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,1 FROM [SimilarToInGenreCharacterLinkEntry<Hero>]
INSERT INTO LinkEntries (CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,Type)
SELECT CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,2 FROM [CounteredByCharacterLinkEntry<Hero>]
INSERT INTO LinkEntries (CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,Type)
SELECT CreatedDate,LastModified,UserId,CharacterId,LinkedCharacterId,3 FROM [StrongAgainstCharacterLinkEntry<Hero>]

UPDATE EntryVote set CharacterStringEntryId = CharacterValueEntryId, CharacterValueEntryId = null

COMMIT TRAN
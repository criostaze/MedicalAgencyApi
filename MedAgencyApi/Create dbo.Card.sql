USE [MedAgencyApiContext-27549eba-f9f9-4ab5-914d-e9ed7f31f055]
GO

/****** Object: Table [dbo].[Card] Script Date: 24.09.2020 12:21:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Card] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate] DATETIME2 (7)  NOT NULL,
    [PersonalId]   NVARCHAR (MAX) NULL,
    [UserLink]     NVARCHAR (MAX) NULL,
    [UserId]       INT            NULL
);

INSERT INTO [dbo].[Card] (Id, CreationDate, PersonalId, UserLink, UserId) VALUES ('1',  '2012-02-21T18:10:00', '1fdsfsdf', '1', '1')
INSERT INTO [dbo].[Card] (Id, CreationDate, PersonalId, UserLink, UserId) VALUES ('2',  '2012-02-21T18:10:00', '1fdsfsdf', '2', '2')
INSERT INTO [dbo].[Card] (Id, CreationDate, PersonalId, UserLink, UserId) VALUES ('3',  '2012-02-21T18:10:00', '1fdsfsdf', '3', '3')
INSERT INTO [dbo].[Card] (Id, CreationDate, PersonalId, UserLink, UserId) VALUES ('4',  '2012-02-21T18:10:00', '1fdsfsdf', '4', '4')
INSERT INTO [dbo].[Card] (Id, CreationDate, PersonalId, UserLink, UserId) VALUES ('5',  '2012-02-21T18:10:00', '1fdsfsdf', '5', '5')

set identity_insert [dbo].[Card] ON


GO
CREATE NONCLUSTERED INDEX [IX_Card_UserId]
    ON [dbo].[Card]([UserId] ASC);


GO
ALTER TABLE [dbo].[Card]
    ADD CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Card]
    ADD CONSTRAINT [FK_Card_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);



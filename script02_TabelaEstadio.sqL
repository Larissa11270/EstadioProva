BEGIN TRANSACTION;
CREATE TABLE [TB_ESTADIO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NULL,
    [Cidade] varchar(200) NULL,
    [Capacidade] int NOT NULL,
    CONSTRAINT [PK_TB_ESTADIO] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] ON;
INSERT INTO [TB_ESTADIO] ([Id], [Capacidade], [Cidade], [Nome])
VALUES (1, 50000, 'Rio de Janeiro', 'Maracanã'),
(2, 20000, 'São Paulo', 'Pacaembu'),
(3, 80000, 'São Paulo', 'Morumbi'),
(4, 90000, 'São Paulo', 'Allianz Parque'),
(5, 30000, 'São Paulo', 'Canindé'),
(6, 100000, 'São Paulo', 'Neo Química Arena'),
(7, 40000, 'Santos', 'Rua Javari');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacidade', N'Cidade', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ESTADIO]'))
    SET IDENTITY_INSERT [TB_ESTADIO] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406114132_MigracaoEstadios', N'10.0.5');

COMMIT;
GO


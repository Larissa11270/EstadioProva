IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_JOGADORES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NULL,
    [NumeroCamisa] int NOT NULL,
    [Posicao] varchar(200) NULL,
    [SelecaoId] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_TB_JOGADORES] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'NumeroCamisa', N'Posicao', N'SelecaoId', N'Status') AND [object_id] = OBJECT_ID(N'[TB_JOGADORES]'))
    SET IDENTITY_INSERT [TB_JOGADORES] ON;
INSERT INTO [TB_JOGADORES] ([Id], [Nome], [NumeroCamisa], [Posicao], [SelecaoId], [Status])
VALUES (1, 'Hugo Souza', 1, 'Goleiro', 0, 1),
(2, 'Yuri Alberto', 9, 'Atacante', 0, 1),
(3, 'Danilo', 2, 'Lateral Direito', 0, 1),
(4, 'Marquinhos', 4, 'Zagueiro', 0, 1),
(5, 'Casemiro', 5, 'Volante', 0, 1),
(6, 'Alex Sandro', 6, 'Lateral Esquerdo', 0, 1),
(7, 'Lucas Paquetá', 7, 'Meio Campo', 0, 1),
(8, 'Bruno Guimarães', 8, 'Meio Campo', 0, 2),
(9, 'Richarlison', 10, 'Atacante', 0, 1),
(10, 'Vinicius Jr', 11, 'Atacante', 0, 1),
(11, 'Rodrygo', 19, 'Atacante', 0, 3),
(12, 'Alisson', 23, 'Goleiro', 0, 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'NumeroCamisa', N'Posicao', N'SelecaoId', N'Status') AND [object_id] = OBJECT_ID(N'[TB_JOGADORES]'))
    SET IDENTITY_INSERT [TB_JOGADORES] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260322231645_InitialCreate', N'10.0.5');

COMMIT;
GO


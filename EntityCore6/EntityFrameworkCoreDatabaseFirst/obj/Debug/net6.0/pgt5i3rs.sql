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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221124162210_MigrationInicialdeSinc')
BEGIN
    CREATE TABLE [notas] (
        [idnota] int NOT NULL IDENTITY,
        [titulo] nvarchar(50) NOT NULL,
        [descripcion] nvarchar(200) NULL,
        [fecha] date NOT NULL,
        [usuario_id] int NULL,
        CONSTRAINT [PK_notas] PRIMARY KEY ([idnota])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221124162210_MigrationInicialdeSinc')
BEGIN
    CREATE TABLE [usuario] (
        [id] int NOT NULL IDENTITY,
        [email] nvarchar(50) NOT NULL,
        [nombre] nvarchar(200) NOT NULL,
        [telefono] nvarchar(30) NULL,
        [password] varchar(100) NOT NULL,
        [es_admin] int NULL,
        CONSTRAINT [PK_usuario] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221124162210_MigrationInicialdeSinc')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221124162210_MigrationInicialdeSinc', N'7.0.0');
END;
GO

COMMIT;
GO


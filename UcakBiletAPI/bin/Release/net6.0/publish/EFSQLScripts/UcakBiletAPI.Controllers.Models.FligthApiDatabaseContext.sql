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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221108221926_initial')
BEGIN
    CREATE TABLE [Flight] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Arrivetime] nvarchar(max) NULL,
        [Starttime] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [Start] nvarchar(max) NULL,
        [End] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        [UpdatedBy] int NOT NULL,
        [DeletedAt] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Flight] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221108221926_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221108221926_initial', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110122951_last-migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221110122951_last-migration', N'6.0.11');
END;
GO

COMMIT;
GO


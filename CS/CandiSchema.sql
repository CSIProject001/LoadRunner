Project CS (.NETCoreApp,Version=v1.1) will be compiled because inputs were modified
Compiling CS for .NETCoreApp,Version=v1.1
Compilation succeeded.
    0 Warning(s)
    0 Error(s)
Time elapsed 00:00:01.5688348
 
IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO
CREATE TABLE [Address] (
    [ID] int NOT NULL IDENTITY,
    [Category] nvarchar(max),
    [City] nvarchar(max),
    [Country] nvarchar(max),
    [Line1] nvarchar(max),
    [Line2] nvarchar(max),
    [State] nvarchar(max),
    [Zip] nvarchar(max),
    CONSTRAINT [PK_Address] PRIMARY KEY ([ID])
);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170217175237_InitialCreate', N'1.1.0-rtm-22752');
GO

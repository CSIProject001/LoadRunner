Project CS (.NETCoreApp,Version=v1.1) was previously compiled. Skipping compilation.
IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO
CREATE TABLE [Customer] (
    [ID] int NOT NULL IDENTITY,
    [DOB] datetime2 NOT NULL,
    [FirstName] nvarchar(max),
    [LastName] nvarchar(max),
    [Organization] nvarchar(max),
    [UserId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([ID])
);
GO
CREATE TABLE [Address] (
    [ID] int NOT NULL IDENTITY,
    [Category] nvarchar(max),
    [City] nvarchar(max),
    [Country] nvarchar(max),
    [CustomerID] int,
    [Line1] nvarchar(max),
    [Line2] nvarchar(max),
    [State] nvarchar(max),
    [Zip] nvarchar(max),
    CONSTRAINT [PK_Address] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Address_Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customer] ([ID]) ON DELETE NO ACTION
);
GO
CREATE TABLE [Phone] (
    [ID] int NOT NULL IDENTITY,
    [Category] nvarchar(max),
    [CustomerID] int,
    [PhoneNumber] nvarchar(max),
    CONSTRAINT [PK_Phone] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Phone_Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customer] ([ID]) ON DELETE NO ACTION
);
GO
CREATE INDEX [IX_Address_CustomerID] ON [Address] ([CustomerID]);
GO
CREATE INDEX [IX_Phone_CustomerID] ON [Phone] ([CustomerID]);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170221195012_InitialCreate', N'1.1.0-rtm-22752');
GO
CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [BillingAddressID] int,
    [CCAuthorizationCode] nvarchar(max),
    [CustomerId] int NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [OrderNumber] nvarchar(max),
    [OrderReceivedDate] datetime2 NOT NULL,
    [OrderTotal] decimal(18, 2) NOT NULL,
    [PromotionAmount] decimal(18, 2) NOT NULL,
    [PromotionCode] nvarchar(max),
    [ShippedDate] datetime2 NOT NULL,
    [ShippingAddressID] int,
    [ShippingCost] decimal(18, 2) NOT NULL,
    [ShippingVia] nvarchar(max),
    [ShippingWeightTotal] decimal(18, 2) NOT NULL,
    [Tax] decimal(18, 2) NOT NULL,
    [TrackingCode] nvarchar(max),
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Address_BillingAddressID] FOREIGN KEY ([BillingAddressID]) REFERENCES [Address] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_Address_ShippingAddressID] FOREIGN KEY ([ShippingAddressID]) REFERENCES [Address] ([ID]) ON DELETE NO ACTION
);
GO
CREATE TABLE [Product] (
    [ID] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [ImageName] nvarchar(max),
    [IsActive] bit NOT NULL,
    [Name] nvarchar(max),
    [QuantityPerUnit] nvarchar(max),
    [ReOrderLevel] int NOT NULL,
    [UnitPrice] decimal(18, 2) NOT NULL,
    [UnitsInOrder] int NOT NULL,
    [UnitsInStock] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([ID])
);
GO
CREATE TABLE [OrderItem] (
    [ID] int NOT NULL IDENTITY,
    [Coupon] nvarchar(max),
    [CouponPrice] int NOT NULL,
    [OrderId] int,
    [OrderQuantity] decimal(18, 2) NOT NULL,
    [Price] decimal(18, 2) NOT NULL,
    [ProductId] int NOT NULL,
    [Total] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([ID]) ON DELETE NO ACTION
);
GO
CREATE INDEX [IX_Order_BillingAddressID] ON [Order] ([BillingAddressID]);
GO
CREATE INDEX [IX_Order_ShippingAddressID] ON [Order] ([ShippingAddressID]);
GO
CREATE INDEX [IX_OrderItem_OrderId] ON [OrderItem] ([OrderId]);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170222053717_AddProductOrder_OrderItems', N'1.1.0-rtm-22752');
GO
CREATE TABLE [ShoppingCart] (
    [ID] int NOT NULL IDENTITY,
    [Coupon] nvarchar(max),
    [DiscountPrice] decimal(18, 2) NOT NULL,
    [ItemID] int,
    [Price] decimal(18, 2) NOT NULL,
    [Quantity] decimal(18, 2) NOT NULL,
    [UnitPrice] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_ShoppingCart_Product_ItemID] FOREIGN KEY ([ItemID]) REFERENCES [Product] ([ID]) ON DELETE NO ACTION
);
GO
CREATE INDEX [IX_ShoppingCart_ItemID] ON [ShoppingCart] ([ItemID]);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170222054737_AddShoppingCart', N'1.1.0-rtm-22752');
GO
EXEC sp_rename N'Order.ID', N'ID', N'COLUMN';
GO
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Product') AND [c].[name] = N'QuantityPerUnit');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Product] ALTER COLUMN [QuantityPerUnit] nvarchar(max) NOT NULL;
GO
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Product') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Product] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
GO
DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Product') AND [c].[name] = N'ImageName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Product] ALTER COLUMN [ImageName] nvarchar(500) NOT NULL;
GO
ALTER TABLE [Product] ADD [Description] nvarchar(500);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170314053419_Description field added to Product', N'1.1.0-rtm-22752');
GO
ALTER TABLE [ShoppingCart] DROP CONSTRAINT [FK_ShoppingCart_Product_ItemID];
GO
DROP INDEX [IX_ShoppingCart_ItemID] ON [ShoppingCart];
GO
DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'Coupon');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [Coupon];
GO
DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'DiscountPrice');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [DiscountPrice];
GO
DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'ItemID');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [ItemID];
GO
DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'Price');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [Price];
GO
DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'Quantity');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [Quantity];
GO
DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'UnitPrice');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [UnitPrice];
GO
CREATE TABLE [CartItem] (
    [Id] int NOT NULL IDENTITY,
    [CartId] int NOT NULL,
    [Coupon] nvarchar(max),
    [DiscountPrice] decimal(18, 2) NOT NULL,
    [ItemID] int,
    [Price] decimal(18, 2) NOT NULL,
    [Quantity] decimal(18, 2) NOT NULL,
    [ShoppingCartID] int,
    [UnitPrice] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CartItem_Product_ItemID] FOREIGN KEY ([ItemID]) REFERENCES [Product] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CartItem_ShoppingCart_ShoppingCartID] FOREIGN KEY ([ShoppingCartID]) REFERENCES [ShoppingCart] ([ID]) ON DELETE NO ACTION
);
GO
CREATE INDEX [IX_CartItem_ItemID] ON [CartItem] ([ItemID]);
GO
CREATE INDEX [IX_CartItem_ShoppingCartID] ON [CartItem] ([ShoppingCartID]);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322173344_Added CartItem', N'1.1.0-rtm-22752');
GO
EXEC sp_rename N'Order.ID', N'Id', N'COLUMN';
GO
EXEC sp_rename N'CartItem.ID', N'Id', N'COLUMN';
GO
ALTER TABLE [ShoppingCart] ADD [SessionId] nvarchar(max);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322181502_Added Session to ShoppingCart', N'1.1.0-rtm-22752');
GO
DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'SessionId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [ShoppingCart] ALTER COLUMN [SessionId] nvarchar(50);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322181640_Adjusted stringlength to 50 to ShoppingCart', N'1.1.0-rtm-22752');
GO
DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'SessionId');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [ShoppingCart] DROP COLUMN [SessionId];
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322184430_Removed Sessions from ShoppingCart', N'1.1.0-rtm-22752');
GO
ALTER TABLE [ShoppingCart] ADD [UserId] nvarchar(max);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322184851_Connect User to ShoppingCart for SaveCart', N'1.1.0-rtm-22752');
GO
DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ShoppingCart') AND [c].[name] = N'UserId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCart] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [ShoppingCart] ALTER COLUMN [UserId] nvarchar(50);
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170322185034_Made string length of user to 50 in ShoppingCart', N'1.1.0-rtm-22752');
GO

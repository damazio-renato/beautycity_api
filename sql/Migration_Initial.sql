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

CREATE TABLE [Categorias] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(50) NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cidadaos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Sobrenome] varchar(100) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [Email] varchar(50) NOT NULL,
    [Celular] varchar(11) NOT NULL,
    [Ativo] bit NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_Cidadaos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Estado] varchar(200) NOT NULL,
    [Cidade] varchar(200) NOT NULL,
    [Bairro] varchar(200) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] int NOT NULL,
    [Complemento] varchar(200) NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    [CidadaoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Cidadaos_CidadaoId] FOREIGN KEY ([CidadaoId]) REFERENCES [Cidadaos] ([Id])
);
GO

CREATE TABLE [Solicitacoes] (
    [Id] uniqueidentifier NOT NULL,
    [Latitude] decimal(10,6) NOT NULL,
    [Longitude] decimal(10,6) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [Imagem] varchar(200) NOT NULL,
    [Situacao] int NOT NULL,
    [Inclusao] datetime2 NOT NULL,
    [Alteracao] datetime2 NOT NULL,
    [CategoriaId] uniqueidentifier NOT NULL,
    [CidadaoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Solicitacoes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Solicitacoes_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]),
    CONSTRAINT [FK_Solicitacoes_Cidadaos_CidadaoId] FOREIGN KEY ([CidadaoId]) REFERENCES [Cidadaos] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Enderecos_CidadaoId] ON [Enderecos] ([CidadaoId]);
GO

CREATE UNIQUE INDEX [IX_Solicitacoes_CategoriaId] ON [Solicitacoes] ([CategoriaId]);
GO

CREATE INDEX [IX_Solicitacoes_CidadaoId] ON [Solicitacoes] ([CidadaoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240428032223_Initial', N'8.0.4');
GO

COMMIT;
GO



-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/02/2020 11:26:14
-- Generated from EDMX file: C:\Users\Anas FAOUR\source\repos\LINQ\WpfAppAutresApprochesEF\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Bibiotheque];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AuteurLivre_Auteur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuteurLivre] DROP CONSTRAINT [FK_AuteurLivre_Auteur];
GO
IF OBJECT_ID(N'[dbo].[FK_AuteurLivre_Livre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuteurLivre] DROP CONSTRAINT [FK_AuteurLivre_Livre];
GO
IF OBJECT_ID(N'[dbo].[FK_LivreCategorie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Livres] DROP CONSTRAINT [FK_LivreCategorie];
GO
IF OBJECT_ID(N'[dbo].[FK_AuteurClub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Auteurs] DROP CONSTRAINT [FK_AuteurClub];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auteurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auteurs];
GO
IF OBJECT_ID(N'[dbo].[Livres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Livres];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[ClubSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubSet];
GO
IF OBJECT_ID(N'[dbo].[AuteurLivre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuteurLivre];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Auteurs'
CREATE TABLE [dbo].[Auteurs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [Adresse_Numero] int  NOT NULL,
    [Adresse_Rue] nvarchar(max)  NOT NULL,
    [Adresse_CP] nvarchar(max)  NOT NULL,
    [Adresse_Complement] nvarchar(max)  NOT NULL,
    [Club_Id] int  NOT NULL
);
GO

-- Creating table 'Livres'
CREATE TABLE [dbo].[Livres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [ISBN] int  NOT NULL,
    [AnneeParuation] nvarchar(max)  NOT NULL,
    [Categorie_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ClubSet'
CREATE TABLE [dbo].[ClubSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'AuteurLivre'
CREATE TABLE [dbo].[AuteurLivre] (
    [Auteurs_Id] int  NOT NULL,
    [Livres_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Auteurs'
ALTER TABLE [dbo].[Auteurs]
ADD CONSTRAINT [PK_Auteurs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Livres'
ALTER TABLE [dbo].[Livres]
ADD CONSTRAINT [PK_Livres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClubSet'
ALTER TABLE [dbo].[ClubSet]
ADD CONSTRAINT [PK_ClubSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Auteurs_Id], [Livres_Id] in table 'AuteurLivre'
ALTER TABLE [dbo].[AuteurLivre]
ADD CONSTRAINT [PK_AuteurLivre]
    PRIMARY KEY CLUSTERED ([Auteurs_Id], [Livres_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Auteurs_Id] in table 'AuteurLivre'
ALTER TABLE [dbo].[AuteurLivre]
ADD CONSTRAINT [FK_AuteurLivre_Auteur]
    FOREIGN KEY ([Auteurs_Id])
    REFERENCES [dbo].[Auteurs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Livres_Id] in table 'AuteurLivre'
ALTER TABLE [dbo].[AuteurLivre]
ADD CONSTRAINT [FK_AuteurLivre_Livre]
    FOREIGN KEY ([Livres_Id])
    REFERENCES [dbo].[Livres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuteurLivre_Livre'
CREATE INDEX [IX_FK_AuteurLivre_Livre]
ON [dbo].[AuteurLivre]
    ([Livres_Id]);
GO

-- Creating foreign key on [Categorie_Id] in table 'Livres'
ALTER TABLE [dbo].[Livres]
ADD CONSTRAINT [FK_LivreCategorie]
    FOREIGN KEY ([Categorie_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LivreCategorie'
CREATE INDEX [IX_FK_LivreCategorie]
ON [dbo].[Livres]
    ([Categorie_Id]);
GO

-- Creating foreign key on [Club_Id] in table 'Auteurs'
ALTER TABLE [dbo].[Auteurs]
ADD CONSTRAINT [FK_AuteurClub]
    FOREIGN KEY ([Club_Id])
    REFERENCES [dbo].[ClubSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuteurClub'
CREATE INDEX [IX_FK_AuteurClub]
ON [dbo].[Auteurs]
    ([Club_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
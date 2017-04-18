
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2017 01:16:27
-- Generated from EDMX file: c:\users\ecenur\documents\visual studio 2017\Projects\TasarimDesenleri_odev1\TasarimDesenleri_odev1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TasarimDesenleri];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DosyalamaArsivlemes'
CREATE TABLE [dbo].[DosyalamaArsivlemes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'KagitUrunleris'
CREATE TABLE [dbo].[KagitUrunleris] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'Mikroskops'
CREATE TABLE [dbo].[Mikroskops] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'HesapMakinesis'
CREATE TABLE [dbo].[HesapMakinesis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'OkulCantalaris'
CREATE TABLE [dbo].[OkulCantalaris] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'OkulDefterleris'
CREATE TABLE [dbo].[OkulDefterleris] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL,
    [fiyat] float  NOT NULL,
    [urun_bilgisi] nvarchar(max)  NOT NULL,
    [ResimYolu_id] int  NOT NULL
);
GO

-- Creating table 'ResimYolus'
CREATE TABLE [dbo].[ResimYolus] (
    [id] int IDENTITY(1,1) NOT NULL,
    [adi] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'DosyalamaArsivlemes'
ALTER TABLE [dbo].[DosyalamaArsivlemes]
ADD CONSTRAINT [PK_DosyalamaArsivlemes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'KagitUrunleris'
ALTER TABLE [dbo].[KagitUrunleris]
ADD CONSTRAINT [PK_KagitUrunleris]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Mikroskops'
ALTER TABLE [dbo].[Mikroskops]
ADD CONSTRAINT [PK_Mikroskops]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'HesapMakinesis'
ALTER TABLE [dbo].[HesapMakinesis]
ADD CONSTRAINT [PK_HesapMakinesis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'OkulCantalaris'
ALTER TABLE [dbo].[OkulCantalaris]
ADD CONSTRAINT [PK_OkulCantalaris]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'OkulDefterleris'
ALTER TABLE [dbo].[OkulDefterleris]
ADD CONSTRAINT [PK_OkulDefterleris]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ResimYolus'
ALTER TABLE [dbo].[ResimYolus]
ADD CONSTRAINT [PK_ResimYolus]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ResimYolu_id] in table 'DosyalamaArsivlemes'
ALTER TABLE [dbo].[DosyalamaArsivlemes]
ADD CONSTRAINT [FK_ResimYoluDosyalamaArsivleme]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluDosyalamaArsivleme'
CREATE INDEX [IX_FK_ResimYoluDosyalamaArsivleme]
ON [dbo].[DosyalamaArsivlemes]
    ([ResimYolu_id]);
GO

-- Creating foreign key on [ResimYolu_id] in table 'HesapMakinesis'
ALTER TABLE [dbo].[HesapMakinesis]
ADD CONSTRAINT [FK_ResimYoluHesapMakinesi]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluHesapMakinesi'
CREATE INDEX [IX_FK_ResimYoluHesapMakinesi]
ON [dbo].[HesapMakinesis]
    ([ResimYolu_id]);
GO

-- Creating foreign key on [ResimYolu_id] in table 'KagitUrunleris'
ALTER TABLE [dbo].[KagitUrunleris]
ADD CONSTRAINT [FK_ResimYoluKagitUrunleri]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluKagitUrunleri'
CREATE INDEX [IX_FK_ResimYoluKagitUrunleri]
ON [dbo].[KagitUrunleris]
    ([ResimYolu_id]);
GO

-- Creating foreign key on [ResimYolu_id] in table 'Mikroskops'
ALTER TABLE [dbo].[Mikroskops]
ADD CONSTRAINT [FK_ResimYoluMikroskop]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluMikroskop'
CREATE INDEX [IX_FK_ResimYoluMikroskop]
ON [dbo].[Mikroskops]
    ([ResimYolu_id]);
GO

-- Creating foreign key on [ResimYolu_id] in table 'OkulCantalaris'
ALTER TABLE [dbo].[OkulCantalaris]
ADD CONSTRAINT [FK_ResimYoluOkulCantalari]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluOkulCantalari'
CREATE INDEX [IX_FK_ResimYoluOkulCantalari]
ON [dbo].[OkulCantalaris]
    ([ResimYolu_id]);
GO

-- Creating foreign key on [ResimYolu_id] in table 'OkulDefterleris'
ALTER TABLE [dbo].[OkulDefterleris]
ADD CONSTRAINT [FK_ResimYoluOkulDefterleri]
    FOREIGN KEY ([ResimYolu_id])
    REFERENCES [dbo].[ResimYolus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResimYoluOkulDefterleri'
CREATE INDEX [IX_FK_ResimYoluOkulDefterleri]
ON [dbo].[OkulDefterleris]
    ([ResimYolu_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
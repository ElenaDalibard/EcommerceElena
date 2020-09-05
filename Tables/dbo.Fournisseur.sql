CREATE TABLE [dbo].[Fournisseur] (
    [idFourn]          INT            IDENTITY (1, 1) NOT NULL,
    [nomFourn]         NVARCHAR (20)  NOT NULL,
    [descriptionFourn] NVARCHAR (MAX) NULL,
    [telephoneFourn]   VARCHAR (15)   NULL,
    [paysFourn]        NVARCHAR (25)  NULL,
    [villeFourn]       NVARCHAR (30)  NULL,
    [adresseFourn]     NVARCHAR (100) NULL,
    [codePostal]       NVARCHAR (7)   NULL,
    [emailFourn]       NVARCHAR (50)  NULL,
    [status]           NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([idFourn] ASC)
);


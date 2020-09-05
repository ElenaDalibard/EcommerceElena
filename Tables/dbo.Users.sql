CREATE TABLE [dbo].[Users] (
    [IdUser]        INT           IDENTITY (1, 1) NOT NULL,
    [nomUser]       NVARCHAR (20) NOT NULL,
    [PrenomUser]    NVARCHAR (20) NULL,
    [sexe]          NCHAR (10)    NULL,
    [emailUser]     NVARCHAR (30) NULL,
    [telephoneUser] NVARCHAR (15) NULL,
    [paysUser]      NVARCHAR (15) NULL,
    [villeUser]     NVARCHAR (20) NULL,
    [adresseUser]   NVARCHAR (50) NULL,
    [codePostal]    NVARCHAR (7)  NULL,
    [statusUser]    NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC)
);


CREATE TABLE [dbo].[Roles] (
    [idRole]  INT            IDENTITY (1, 1) NOT NULL,
    [email]   NVARCHAR (100) NULL,
    [roleNom] NVARCHAR (15)  NULL,
    PRIMARY KEY CLUSTERED ([idRole] ASC)
);


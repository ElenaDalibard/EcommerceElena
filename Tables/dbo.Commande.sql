CREATE TABLE [dbo].[Commande] (
    [IdCommande]     INT        IDENTITY (1, 1) NOT NULL,
    [idUser]         INT        NOT NULL,
    [dateCommande]   DATETIME   NULL,
    [statusCommande] INT        NULL,
    [PrixTotal]      FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([IdCommande] ASC),
    FOREIGN KEY ([idUser]) REFERENCES [dbo].[Users] ([IdUser])
);


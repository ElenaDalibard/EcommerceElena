CREATE TABLE [dbo].[Facture] (
    [idFacture]     INT        IDENTITY (1, 1) NOT NULL,
    [idCommande]    INT        NOT NULL,
    [prixHT]        FLOAT (53) NULL,
    [prixTVA]       FLOAT (53) NULL,
    [prixLivraison] FLOAT (53) NULL,
    [dateFacture]   DATETIME   NULL,
    [prixTotal]     FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([idFacture] ASC),
    FOREIGN KEY ([idCommande]) REFERENCES [dbo].[Commande] ([IdCommande])
);


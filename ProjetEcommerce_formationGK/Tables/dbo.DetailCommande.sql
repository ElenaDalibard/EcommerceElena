CREATE TABLE [dbo].[DetailCommande] (
    [idDetCom]   INT IDENTITY (1, 1) NOT NULL,
    [idCommande] INT NULL,
    [idProd]     INT NULL,
    [quantite]   INT NULL,
    PRIMARY KEY CLUSTERED ([idDetCom] ASC),
    FOREIGN KEY ([idCommande]) REFERENCES [dbo].[Commande] ([IdCommande]),
    FOREIGN KEY ([idProd]) REFERENCES [dbo].[Produit] ([idProd])
);


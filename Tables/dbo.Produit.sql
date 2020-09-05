CREATE TABLE [dbo].[Produit] (
    [idProd]          INT            IDENTITY (1, 1) NOT NULL,
    [nomProd]         NVARCHAR (20)  NOT NULL,
    [PrixProd]        FLOAT (53)     NULL,
    [statusProd]      NVARCHAR (20)  NULL,
    [couleur]         NVARCHAR (20)  NULL,
    [capacite]        INT            NULL,
    [poids]           FLOAT (53)     NULL,
    [longeur]         FLOAT (53)     NULL,
    [largeur]         FLOAT (53)     NULL,
    [hauteur]         FLOAT (53)     NULL,
    [idFourn]         INT            NULL,
    [descriptionProd] NVARCHAR (400) NULL,
    [idCategory]      INT            NULL,
    [imageUrl]        NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([idProd] ASC),
    FOREIGN KEY ([idFourn]) REFERENCES [dbo].[Fournisseur] ([idFourn]),
    FOREIGN KEY ([idCategory]) REFERENCES [dbo].[Category] ([idCategory])
);


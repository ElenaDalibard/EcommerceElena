CREATE TABLE [dbo].[Avis] (
    [idAvis]     INT            IDENTITY (1, 1) NOT NULL,
    [idUser]     INT            NULL,
    [idProd]     INT            NULL,
    [note]       INT            NULL,
    [texte]      NVARCHAR (200) NULL,
    [statusAvis] INT            NULL,
    [dateAvis]   DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([idAvis] ASC),
    FOREIGN KEY ([idUser]) REFERENCES [dbo].[Users] ([IdUser]),
    FOREIGN KEY ([idProd]) REFERENCES [dbo].[Produit] ([idProd])
);


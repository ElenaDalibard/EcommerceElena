# Ecommerce

Projet MVC (ASP .net Core), C#

## Pour lancer
Base de données : Produits_Entity.mdf
Lancer la solution : Ecommerce/Ecommerce.sln

## Fonctionnamités
* S'autoriser comme :
	- nouveau client
	- client existant
	- administrateur (email : admin@admin.com, mot de passe : admin)
* Lister les produits
* Regarder les details de produit
* Ajouter au panier
* Passer la commande (user)
* Regarder toutes les commandes (admin)
* Regarder ses commandes (user)
* Regarder les details d'une commande (user)
* Ajouter un produit dans le catalogue (admin)
* Modifier un produit (admin)
* 2 langues à choisir

## Frameworks
Asp .Net Core
Entity 3.1.8
AspNetCore.Authorization
AspNetCore.Authentication
AspNetCore.Session

Utilisation des microservices

### Sans authentication
- Lister les produits
- Regarder les details de produit
- Ajouter au panier la quantité souhaité
- Supprimer le produit de panier
- Recherche par les lettre de titre de produit

![](/ProjetEcommerce/gif/show.gif)

### Mode User
- Passer la commande
- Regarder ses commandes
- Regarder les details d'une commande

![](/ProjetEcommerce/gif/show_user.gif)

### Mode Admin
- Regarder toutes les commandes
- Ajouter un produit dans le catalogue
- Modifier un produit
- Supprimer une des images de produit
- Supprimer un produit

![](/ProjetEcommerce/gif/show_admin.gif)

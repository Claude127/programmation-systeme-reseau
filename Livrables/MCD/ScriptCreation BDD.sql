------------------------------------------------------
        --Script de creation de la base de donnees 

-------------------------------------------------------


--TABLE MATERIEL

CREATE TABLE materiel(
        id_materiel int IDENTITY(1,1) NOT NULL,
        nom Varchar(50) NOT NULL,
        quantite int NOT NULL,
        CONSTRAINT materiel_pk PRIMARY KEY (id_materiel)

);

--Insertion dans la table Materiel 
INSERT INTO 'materiel'('nom', 'quantite')VALUES
('assiettes_entrees', 150),
('assiettes_plats', 150),
('assiettres creuses', 30),
('assiettes_desserts', 150),
('fourchettes',150),
('couteaux',150),
('cuilleres_soupe', 150),
('cuilleres_cafe', 150),
('verre_eau', 150),
('verre_vin', 150),
('flutes_champagne', 150),
('tasses_assiettes_cafe', 50),
('servietes',150),
('nappes',40),
('corbeilles_pain', 40),
('casserole',10),
('poele', 10),
('cuillere_bois', 10),
('mixeur', 1),
('bols_salade', 5),
('autocuiseur',2),
('presse_agrumes',1),
('tamis',1),
('entonnoir', 1),
('couteaux_cuisine',5);


--TABLE CLIENT

CREATE TABLE client(
    id_cli int IDENTITY(1,1) NOT NULL,
    nom VARCHAR(50) NOT NULL,
    CONSTRAINT client_pk PRIMARY KEY (id_cli)
);


--Insertion de clients ayant reserves 

INSERT INTO 'client'('nom')VALUES 
('esmeralda VIGNON'),
('borel DUBOIS'),
('alexander CASTILLO'),
('mike SPICE');

--TABLE RECETTE 

CREATE TABLE recette (
    id_recette int IDENTITY(1,1) NOT NULL,
    nom VARCHAR(50) NOT NULL,
    categorie VARCHAR(50),
    CONSTRAINT recette_pk PRIMARY KEY (id_recette)
);

--Insertion des recettes

INSERT INTO 'recette'('nom', 'categorie')VALUES
('feuillete au crabe', 'entree'),
('oeufs cocotte','entree'),
('gaspatcho','entree'),
('pate de sanglier cliente christian', 'entree'),
('pate de sanglier lolotte','entree'),
('tarte au thon','entree'),
('quiche-lorraine', 'entree'),
('foie gras a la vapeur', 'entree'),
('soupe chinoise', 'entree'),
('les cagouilles a la charentaise','entree'),
('tagliatelles de concombre au saumon fume','entree'),
("bouillinade d'anguille",'plat'),
("bouillinade de poissons", 'plat'),
('boles de picoulats','plat'),
('blanquettes de veau','plat'),
('pate de porc','plat'),
('blancs de poulet a la creme et au miel', 'plat'),
('escargots a la catalane', 'plat'),
('foie garas au muscat', 'plat'),
('chorba', 'plat'),
('gaufres', 'dessert'),
('crepes','dessert'),
('tiramisu', 'dessert'),
('madeleine au miel', 'dessert');


--TABLE INGREDIENTS

CREATE TABLE ingredients(
    id_ingred int IDENTITY(1,1) NOT NULL,
    nom VARCHAR(50) NOT NULL,
    quantite int NOT NULL,
    Categorie VARCHAR(50) NOT NULL,
    COrNSTRAINT ingred_pk PRIMARY KEY (id_ingred)
);

--Insertion dans la table Ingredients 

INSERT INTO 'ingredients'('nom','quantite','categorie')VALUES 
('sel',50,'longue conservation'),
('poivre',80,'longue conservation'),
('boeuf',150,'frais'),
('poulet', 70,'frais'),
('saumon',50,'frais'),
('pate a pizza',20,'surgele'),
('conserve de tomates',80,'frais'),
('salade',70,'frais'),
('tomate',200,'frais'),
('mozzarella',45,'frais'),
('cheddar',50,'surgle'),
('pomme de terre',1000,'longue conservation'),
('lardon',100,'surgele'),
('jambon',90,'frais'),
('olive',200,'frais'),
('champignon',80,'frais'),
('anchois',250,'longue conservation'),
('bacon',133,'frais'),
('glace chocolat',1200,'surgele'),
('glace vanille',1200,'surgele'),
('glace pomme',120,'surgele'),
('glace pistache',125,'surgele'),
('glace fraise',1200, 'surgele'),
('cafe',1500,'longue conservation'),
('champagne',70,'frais'),
('vin blanc', 46,'frais'),
('vin rouge',46,'frais');

--TABLE INGREDIENTS RECETTE 
CREATE TABLE ingredient_recette(
    id_ingrec int IDENTITY(1,1)NOT NULL,
    id_recette int NOT NULL,
    id_ingred int NOT NULL,
    quantite int NOT NULL,
    CONSTRAINT ingredient_recette_pk PRIMARY KEY (id_ingrec),
    CONSTRAINT recette_FK FOREIGN KEY (id_recette) REFERENCES (id_recette),
    CONSTRAINT ingredients_FK FOREIGN KEY (id_ingred) REFERENCES (id_ingred)
);

--Insertion Ingredients_recette 

INSERT INTO 'ingredient_recette'('id_recette','id_ingred','quantite')VALUES

(2,6,4),
(1,8,2),
(7,2,1),
(5,7,3),
(8,2,4),
(6,3,1),
(8,4,2),
(5,15,8),
(12,16,4),
(10,5,6),
(17,8,3),
(8,7,4),
(9,10,5),
(7,15,9),
(8,6,8),
(10,10,2),
(4,6,2),
(8,9,2),
(15,10,6),
(8,4,3),
(9,10,5),
(2,4,3),
(16,10,5),
(6,9,7),
(12,4,8),
(7,12,3);

--TABLE RESERVATION 
CREATE TABLE reservation (
    id_reserv int IDENTITY(1,1) NOT NULL,
    nom VARCHAR(50) NOT NULL,
    id_cli int NOT NULL,
    nbre_personne int NOT NULL,
    CONSTRAINT reservation_pk PRIMARY KEY (id_resev),
    CONSTRAINT client_FK FOREIGN KEY (id_cli) REFERENCES client(id_cli)
);

--Insertion RESERVATION 

INSERT INTO 'client'('nom','id_cli','nbre_personne')VALUES 
('Esmaralda',1,6),
('Spice',4,9),
('Castillo',3,2),
('Dubois',2,5);

CREATE TABLE TProjet (
TPro_Id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
TPro_Nom VARCHAR(100) NOT NULL,
TPro_Tri VARCHAR(3) NOT NULL,
TPro_Responsable VARCHAR(3) NOT NULL
)

CREATE TABLE TExigence (
TExi_Id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
TExi_Description VARCHAR(max) NOT NULL,
TExi_Type INTEGER NOT NULL,
TExi_FK_TPro INTEGER FOREIGN KEY REFERENCES TProjet(TPro_Id) NOT NULL
)

CREATE TABLE TJalon (
TJal_Id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
TJal_Libelle VARCHAR(100) NOT NULL,
TJal_DateLivraisonTheorique DATETIME NOT NULL,
TJal_Responsable VARCHAR(3),
TJal_DateLivraisonReel DATETIME NULL,
TJal_FK_TPro INTEGER FOREIGN KEY REFERENCES TProjet(TPro_Id) NULL
)

CREATE TABLE TTache (
TTac_Id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
TTac_Libelle VARCHAR(100) NOT NULL,
TTac_Description VARCHAR(max) NOT NULL,
TTac_Responsable VARCHAR(3) NOT NULL,
TTac_DateDebutTheorique DATETIME NOT NULL,
TTac_NbJours INTEGER NOT NULL,
TTac_FK_TTac INTEGER FOREIGN KEY REFERENCES TTache(TTac_Id) NULL,
TTac_DateDebutReel DATETIME NULL,
TTac_Statut INTEGER NOT NULL,
TTac_FK_TJal INTEGER FOREIGN KEY REFERENCES TJalon(TJal_Id) NOT NULL
)

CREATE TABLE TAss_TExi_TTac(
    TAss_TExi_Id INTEGER FOREIGN KEY REFERENCES TExigence(TExi_Id) NOT NULL,
    TAss_TTac_Id INTEGER FOREIGN KEY REFERENCES TTache(TTac_Id) NOT NULL,
	PRIMARY KEY(TAss_TExi_Id,TAss_TTac_Id)
)

INSERT INTO TProjet(TPro_Nom,TPro_Tri,TPro_Responsable) VALUES ('Projet JAVA','jav','aym'),('Projet CSharp','csh','jea'),('Projet PHP','php','jol')

INSERT INTO TExigence(TExi_Description,TExi_Type,TExi_FK_TPro) VALUES 
    ('creationdu projet java',1,1),('Creation des donnees java',2,1),('ameliorer les performances java',3,1),
    ('creationdu projet csharp',1,2),('Creation des donnees csharp',2,2),('ameliorer les performances csharp',3,2),
    ('creationdu projet php',1,3),('Creation des donnees php',2,3),('ameliorer les performances php',3,3)

INSERT INTO TJalon(TJal_libelle,TJal_DateLivraisonTheorique,TJal_Responsable,TJal_FK_TPro) VALUES ('livrer JAVA',2018-11-30,'aym',1),('livrer CSharp',2018-11-30,'jea',2),('livrer PHP',2018-11-30,'jol',3)

INSERT INTO TTache(TTac_Libelle,TTac_Description,TTac_Responsable,TTac_DateDebutTheorique,TTac_NbJours,TTac_Statut,TTac_FK_TJal) VALUES 
		('faire le projet java','faire des trucs pour le projet java','aym',2018-11-29,1,0,1),('faire le projet java 2','faire plus de trucs pour le projet java','aym',2018-11-30,1,0,1),
		('faire le projet csharp','faire des trucs pour le projet csharp','jea',2018-11-29,1,0,2),('faire le projet csharp 2','faire plus de trucs pour le projet csharp','jea',2018-11-30,1,0,2),
		('faire le projet php','faire des trucs pour le projet php','jol',2018-11-29,1,0,3),('faire le projet php 2','faire plus de trucs pour le projet php','jol',2018-11-30,1,0,3)

INSERT INTO TAss_TExi_TTac(TAss_TExi_Id,TAss_TTac_Id)VALUES(1,1),(1,2),(2,3),(2,4),(3,5),(3,6)



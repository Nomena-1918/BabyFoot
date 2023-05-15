/*create table Joueur(
	id int identity(1,1) primary key, 
	nom nchar(20)
);

insert into Joueur(nom) values ('Player1'), ('Player2');



create table MatchBabyFoot(
	id int identity(1,1) primary key,
	idJ1 int not null, 
	idJ2 int not null,
	valeurJeton int check( valeurJeton > 0 ),
	dateMatch datetime default getdate(),
	foreign key (idJ1) references Joueur(id), 
	foreign key (idJ2) references Joueur(id)
);
ALTER TABLE MatchBabyFoot
ADD CHECK (idJ1!=idJ2);


--insert into MatchBabyFoot values(1, 1, 2, 500, default); 
--select * from MatchBabyFoot;

create table Mise(
	id int identity(1,1) primary key,
	idM int not null, 
	idJ int not null,
	valeurMise int check( valeurMise > 0 ),
	foreign key (idM) references MatchBabyFoot(id), 
	foreign key (idJ) references Joueur(id)
);
*/
--insert into matchbabyfoot(idJ1, idJ2, valeurJeton ,dateMatch) values (1, 2, 200, default);

--select * from MatchBabyFoot;

--insert into mise(idM, idJ, valeurMise) values (1, 1, 500);
--insert into mise(idM, idJ, valeurMise) values (1, 2, 500);

--select * from Mise;

--type action : tir direct 0, tir indirect 1
--valeur : 1 but
/*
create table Action(
	id int identity(1,1) primary key,
	idM int, 
	idJ int, 
	typeAction int default 0, 
	valeur int default 1,
	dateAction date default getdate(),
	foreign key (idJ) references Joueur(id),
	foreign key (idM) references MatchBabyFoot(id)
);
*/
--insert into Action(idM, idJ, typeAction, valeur ,dateAction) values (1, 2, 0, 1, default);
--select * from Action;
/*
create view v_lastMatch as 
select max(id) as idLastMatch from MatchBabyFoot;
*/
/*
create view v_score as
select Action.idM, Action.idJ, Joueur.nom, sum(Action.valeur) as nbButs
	from Action 
	join Joueur on Joueur.id=Action.idJ
	group by Action.idM, Action.idJ, Joueur.nom;
*/

select id, idJ1, idJ2, valeurJeton, dateMatch from MatchBabyFoot where id=(select * from v_lastMatch);


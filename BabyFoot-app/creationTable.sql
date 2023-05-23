/*
create table Joueur(
	id int identity(1,1) primary key, 
	nom nchar(20)
);


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


create table Mise(
	id int identity(1,1) primary key,
	idM int not null, 
	idJ int not null,
	valeurMise int check( valeurMise > 0 ),
	foreign key (idM) references MatchBabyFoot(id), 
	foreign key (idJ) references Joueur(id)
);



/*
create table ActionFoot(
	id int identity(1,1) primary key,
	idM int, 
	idJ int, 
	typeAction nchar(20) default 'tir', 
	valeur int default 1,
	dateAction datetime default getdate(),
	foreign key (idJ) references Joueur(id),
	foreign key (idM) references MatchBabyFoot(id)
);

*/
--create or replace view v_lastMatch as 
	--select max(id), idJ1, idJ2, valeurJeton, dateMatch as idLastMatch from MatchBabyFoot;


*/
/*
create view v_lastMatchComp as 
select id, idJ1, idJ2, valeurJeton, dateMatch 
from MatchBabyFoot
where id=(select * from v_lastMatch);
*/

select * from v_lastMatchComp;

/*
create view v_miseJoueurDernierMatch as
select idM, idJ, sum(valeurMise) as miseJoueur from Mise 
where idM=(select * from v_lastMatch)
group by idM, idJ ;
*/

select * from v_miseJoueurDernierMatch;


/*
create view v_score as
select ActionFoot.idM, ActionFoot.idJ, Joueur.nom, sum(ActionFoot.valeur) as nbButs
	from ActionFoot 
	join Joueur on Joueur.id=ActionFoot.idJ
	where idM=(select * from v_lastMatch)
	group by ActionFoot.idM, ActionFoot.idJ, Joueur.nom;
*/


select * from v_score;







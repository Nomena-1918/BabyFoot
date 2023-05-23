delete from MatchBabyFoot;
delete from Mise;
delete from ActionFoot;
delete from Joueur;
DBCC CHECKIDENT('MatchBabyFoot', RESEED, 0);
DBCC CHECKIDENT('Mise', RESEED, 0);
DBCC CHECKIDENT('ActionFoot', RESEED, 0);
DBCC CHECKIDENT('Joueur', RESEED, 0);
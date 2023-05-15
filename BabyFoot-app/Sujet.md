# Sujet Programmation : <p style="color:green">BabyFoot</p>
## Objectif général :
    Créer un jeu de babyfoot gasy

<br>
<br>

## Règles du jeu :
- Match 12 vs 12 : 1-3-5-3 des 2 côtés
    <br>

- Système de jetons et de mises :
    - Une valeur de jeton J
    - Chaque joueur paie une même somme M
    - Le vainqueur gagne un montant de M*2-J

<br>
<br>

## Technologies :
- Winform (C#)
- SGBDR open (mon choix : PostgreSQL)

<br>
<br>

## Notions mobilisées (Winform et C#) :
- Structure de l'application
- Structure d'une fenêtre
- Formulaire d'insertion
- Connexion BDD : insertion, sélection
- Animation 2D : balle et changement de main
- Listeners (click fenêtre et clavier) sur les composants de la fenêtre

<br>
<br>

## Fonctionnalités : 
- Insertion :
    - Joueurs J1 - J2
    - Valeur jeton
    - Mise J1
    - Mise J2

    <br>

- Terrain avec les joueurs et les buts
    <br>
    
- Listeners : (J1 - J2) 
    - Tir direct avec touche : Q - J
    - Tir indirect avec touche : F - M
        - Choix : choix joueur qui tire (clic) , touche Y but (puis remise en jeu) et N pas but (6m pour le gardien) 
        - Possible but direct depuis le gardien"
    - Passe avec touche : E - O 
        - Choix joueur à passer, clic sur le terrain
    - Interception avec touche I : changement de possession
        - Choix joueur qui a le ballon
    <br>
- Animation changement de main et changement possession ballon
    
    <br>
- Bouton passer son tour

    <br>
- Bouton fin match
    
    <br>
- Fin match automatique avec 3 buts d'écart
    
    <br>
- Fenêtre score avec :
    - Nom gagnant
    - Résumé transactions :
        - Valeur jeton
        - Mise de chacun des joueurs
        - Somme gagnée par le vainqueur

<br>
<br>


# Conception base :
Tables :
   
- Configuration match :
    - Joueur(id, nom)
    - Match(id, idJ1, idJ2, valeurJeton, date) check idJ1 != idJ2, valeurJeton > 0
    - Mise(id, idMatch, idJ, valeurMise) check valeur >= 0 

- Jeu :
    - Action(id, idM, idJ, typeAction(tir d ou i), valeur)

    <br>
Vues : 

- Résultats :
    - v_lastMatch(idM)
    - v_score(idM, idJ1, nomJ1, nbButs(sum(Action.valeur1)) ,idJ2, nomJ2, nbButs(sum(Action.valeur2))
    - v_AffResultatsDernierMatch(idM, v_score, valeurJeton, miseJ1 (sum(MiseJ1)), miseJ2 (sum(MiseJ2)), sommeGagnéeVainqueur)

<br>
<br>

# Possible aléa :
- Mise d'un joueur augmentant par but marqué
    - Insertion step augmentation des mises au début   


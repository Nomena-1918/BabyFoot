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

## Fonctionnalités : 
- Insertion :
    - Joueurs J1 - J2
    - Valeur jeton
    - Mise J1
    - Mise J2

    <br>

- Terrain avec les joueurs et les buts
    <br>
    
- 6 listeners : (J1 - J2) 
    - Tir direct avec touche : Q - J
    - Tir indirect avec touche : F - M
        - Choix : touche Y but (puis remise en jeu) et N pas but (6m pour le gardien) 
        - Possible but direct depuis le gardien"
    - Passe avec touche : E - O 
        - Choix joueur à passer, clic sur le terrain

    <br>
- Animation changement de main et changement possession ballon
    
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

# Possible aléa :
- Mise d'un joueur augmentant par but marqué
    - Insertion step augmentation des mises au début   


# Plummet Game

## Description du jeu

**Plummet Game** est un jeu de plateforme où le joueur contrôle un personnage qui se déplace de gauche à droite sur un tableau. L'objectif est de franchir des obstacles sous forme de murs en les détruisant ou en les évitant. Chaque collision avec un mur réduit l'énergie du joueur. À la fin de la partie, le score du joueur est calculé en fonction du nombre de collisions, des murs restants et de l'énergie restante. Le joueur doit donc éviter les obstacles autant que possible pour maximiser son score.

## Hiérarchie des classes

Le projet **Plummet Game** est structuré autour de plusieurs classes clés qui interagissent entre elles pour créer l'expérience de jeu. Voici un aperçu des principales classes et de leur hiérarchie :

1. **Player** :
   - La classe `Player` gère les actions du personnage principal. Elle est responsable des déplacements, des collisions avec les obstacles et de la gestion de la barre d'énergie. Elle peut contenir des méthodes pour déplacer le joueur et détecter les impacts avec les obstacles.
   
2. **Obstacle** :
   - La classe `Obstacle` représente les murs que le joueur rencontre. Ces murs peuvent être détruits lorsque le joueur entre en collision avec eux. La classe gère aussi la logique de destruction des murs.

3. **GameManager** :
   - La classe `GameManager` est le cœur du jeu. Elle coordonne les différentes mécaniques de jeu, comme la gestion des scores, le calcul des collisions et le suivi de l'énergie du joueur. Elle peut également suivre l'état du jeu (en cours, terminé, etc.).

4. **EnergyBar** :
   - La classe `EnergyBar` est responsable de l'affichage et de la gestion de la barre d'énergie du joueur. Elle diminue chaque fois qu'une collision se produit et est utilisée pour informer le joueur du niveau d'énergie restant.

5. **ScoreManager** :
   - Cette classe gère le calcul et l'affichage du score à la fin du jeu, en prenant en compte des facteurs comme le nombre de collisions, l'énergie restante et les murs détruits.

### Fonctionnement du jeu :
- Le joueur se déplace de gauche à droite pour atteindre la ligne d'arrivée.
- Il doit éviter ou détruire les obstacles en les heurtant, mais chaque collision réduit sa barre d'énergie.
- Le **GameManager** gère l'ensemble de la logique, comme la détection des collisions et le calcul du score.

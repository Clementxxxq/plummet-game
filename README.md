# Plummet Game

## Description du jeu

**Plummet Game** est un jeu de plateforme où le joueur contrôle un personnage qui se déplace de gauche à droite sur un tableau. L'objectif est de franchir des obstacles sous forme de murs en les détruisant ou en les évitant. Chaque collision avec un mur réduit l'énergie du joueur. À la fin de la partie, le score du joueur est calculé en fonction du nombre de collisions, des murs restants et de l'énergie restante. Le joueur doit donc éviter les obstacles autant que possible pour maximiser son score.

## Hiérarchie des classes

Le projet **Plummet Game** est structuré autour de plusieurs classes clés qui interagissent entre elles pour créer l'expérience de jeu. Voici un aperçu des principales classes et de leur hiérarchie :

    PlummetGame (Singleton)
    ├── GameManager (Composite)
    │   ├── Player
    │   ├── Obstacle
    │   └── ScoreManager
    └── GameUI (Composite)
        ├── EnergyBar
        ├── ScoreDisplay
        └── Timer

### Class  A： PlummetGame (Singleton)

| Attribut | Fonctions |
|-----:|---------------|
|Instance|public static PlummetGame instance|
|IsGameRunning|public bool getIsGameRunning(), public void setIsGameRunning(bool)|

| Méthodes |
|-----|
|startGame()|
|endGame()|
|restartGame()|

### Class  B： GameManager  (Composite)

| Attribut | Fonctions |
|-----:|---------------|
|Player|public Player player|
|Obstacles|public List<Obstacle> obstacles|
|Score|public ScoreManager scoreManager|
|Energy|public float energy|
|GameTimer|public float timer|

| Méthodes |
|-----|
|updateGame()|
|checkCollisions()|
|calculateScore()|

### Class  C： Player

| Attribut | Fonctions |
|-----:|---------------|
|Position|public Vector3 position, public void setPosition(Vector3)|
|Speed|public float speed, public void setSpeed(float)|
|Energy|public float energy, public void setEnergy(float)|
|IsAlive|public bool isAlive, public void setIsAlive(bool)|

| Méthodes |
|-----|
|move()|
|collideWithObstacle()|
|decreaseEnergy()|

### Class  D： Obstacle

| Attribut | Fonctions |
|-----:|---------------|
|Position|public Vector3 position, public void setPosition(Vector3)|
|IsDestructible|public bool isDestructible, public void setIsDestructible(bool)|

| Méthodes |
|-----|
|destroy()|
|move()|

### Class  E： ScoreManager

| Attribut | Fonctions |
|-----:|---------------|
|Score|public int score, public void setScore(int)|

| Méthodes |
|-----|
|increaseScore()|
|decreaseScore()|
|resetScore()|



### Fonctionnement du jeu :
- Le joueur se déplace de gauche à droite pour atteindre la ligne d'arrivée.
- Il doit éviter ou détruire les obstacles en les heurtant, mais chaque collision réduit sa barre d'énergie.
- Le **GameManager** gère l'ensemble de la logique, comme la détection des collisions et le calcul du score.

### Système de Score

Le système de score a été ajouté pour suivre la progression du joueur en fonction de son énergie, du nombre de collisions subies et du nombre de murs restants. Le score est calculé selon la formule suivante :

Chaque fois qu'une collision se produit, l'énergie du joueur est réduite de 50 points, le nombre de collisions augmente, et le score est recalculé en fonction de la nouvelle énergie et des murs restants.

### Gestion de la fin du jeu

L'événement `OnGameOver` est déclenché lorsque l'énergie du joueur atteint 0 ou qu'il franchit la ligne d'arrivée. La fonction `RestartGame()` réinitialise le jeu après la fin.


Le score, l'énergie, le nombre de collisions et le nombre de murs restants sont affichés en temps réel dans l'interface utilisateur du jeu. Le score est mis à jour à chaque événement (collision, destruction de mur).



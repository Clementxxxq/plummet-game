using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText, energyText, collisionText, wallText;
    private int score = 0;
    private float maxEnergy = 1000f;
    private float currentEnergy;
    private int collisionCount = 0;
    private int remainingWalls = 10;

    private void Start()
    {
        currentEnergy = maxEnergy;
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();  // Recalcule le score à chaque ajout de points
        UpdateUI();
    }

    public void RegisterCollision()
    {
        collisionCount++;
        DecreaseEnergy(50);
        UpdateScore();  // Recalcule le score à chaque collision
        UpdateUI();
    }

    public void RemoveWall()
    {
        remainingWalls--;
        if (remainingWalls < 0) remainingWalls = 0;
        UpdateScore();  // Recalcule le score à chaque mur détruit
        UpdateUI();
    }

    private void DecreaseEnergy(float amount)
    {
        currentEnergy -= amount;
        if (currentEnergy < 0) currentEnergy = 0;
    }
    private void UpdateScore()
    {
        // Calcul du score selon la formule : (Niveau d’énergie – Nombre de collisions) + Nombre de murs restants
        score = (int)(currentEnergy - collisionCount) + remainingWalls;
    }
    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        energyText.text = "Energy: " + currentEnergy + "/" + maxEnergy;
        collisionText.text = "Collisions: " + collisionCount;
        wallText.text = "Walls Remaining: " + remainingWalls;
    }

    public void ResetScore()
    {
        score = 0;
        collisionCount = 0;
        remainingWalls = 10;
        currentEnergy = maxEnergy;
        UpdateScore();  // Recalcule le score après réinitialisation
        UpdateUI();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText, energyText, collisionText, wallText;
    private int score = 0;
    private float maxEnergy = 1000f;
    public float currentEnergy;
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
        UpdateUI();
    }

    public void RegisterCollision()
    {
        collisionCount++;
        DecreaseEnergy(50);
        UpdateScore();
        UpdateUI();
    }

    public void RemoveWall()
    {
        remainingWalls--;
        if (remainingWalls < 0) remainingWalls = 0;
        UpdateScore();
        UpdateUI();
    }

    private void DecreaseEnergy(float amount)
    {
        currentEnergy -= amount;
        if (currentEnergy < 0) currentEnergy = 0;
    }

    private void UpdateScore()
    {
        score = (int)(currentEnergy - collisionCount) + remainingWalls;
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        energyText.text = "Energy: " + currentEnergy + "/" + maxEnergy;
        collisionText.text = "Collisions: " + collisionCount;
        wallText.text = "Walls Remaining: " + remainingWalls;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetEnergy()
    {
        currentEnergy = maxEnergy;
    }

    public void ResetCollisions()
    {
        collisionCount = 0;
    }

    public void ResetWalls()
    {
        remainingWalls = 10;
    }
}

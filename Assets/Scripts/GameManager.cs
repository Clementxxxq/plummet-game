using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText, energyText, collisionText, wallText;
    private int score = 0;
    private float maxEnergy = 1000f;
    private float currentEnergy;
    private int collisionCount = 0;
    private int remainingWalls = 10;

    public delegate void GameOverDelegate();
    public static event GameOverDelegate OnGameOver;

    private void Start()
    {
        currentEnergy = maxEnergy;
        OnGameOver += RestartGame;
    }

    private void Update()
    {
        if (currentEnergy <= 0 || PlayerCrossedFlags()) TriggerGameOver();
    }

    public void RegisterCollision()
    {
        collisionCount++;
        DecreaseEnergy(50);
        UpdateUI();
    }

    private void DecreaseEnergy(float amount)
    {
        currentEnergy -= amount;
        if (currentEnergy < 0) currentEnergy = 0;
    }

    private void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    private void RestartGame()
    {
        score = 0;
        collisionCount = 0;
        remainingWalls = 10;
        currentEnergy = maxEnergy;
        UpdateUI();
    }

    private bool PlayerCrossedFlags()
    {
        return false; 
    }

    private void OnDestroy()
    {
        OnGameOver -= RestartGame;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        energyText.text = "Energy: " + currentEnergy + "/" + maxEnergy;
        collisionText.text = "Collisions: " + collisionCount;
        wallText.text = "Walls Remaining: " + remainingWalls;
    }
}

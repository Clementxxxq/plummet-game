using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOverDelegate();
    public static event GameOverDelegate OnGameOver;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        OnGameOver += RestartGame;
    }

    private void Update()
    {
        if (scoreManager.currentEnergy <= 0 || PlayerCrossedFlags())
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    private void RestartGame()
    {
        scoreManager.ResetScore();
        scoreManager.ResetEnergy();
        scoreManager.ResetCollisions();
        scoreManager.ResetWalls();

        scoreManager.UpdateUI();
    }

    private bool PlayerCrossedFlags()
    {
        return false;
    }

    private void OnDestroy()
    {
        OnGameOver -= RestartGame;
    }
}

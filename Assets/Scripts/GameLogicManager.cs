using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    public int score = 0;

    public GameLevel gameLevel = GameLevel.Easy;

    public SceneBehaviourManager sceneBehaviourManager;

    public Text scoreText;

    public bool isGameOnPause = false;

    public void IncrementScoreAndUpdateUIBy(int increment)
    {
        SetPlayerScoreTo(score + increment);
        UpdatePlayerScoreText();
    }

    public void GameOver()
    {
        sceneBehaviourManager.GameOver();
    }

    public void PauseGame()
    {
        isGameOnPause = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isGameOnPause = false;
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        SetPlayerScoreTo(0);
        UpdatePlayerScoreText();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetPlayerScoreTo(int newScore)
    {
        score = newScore;

        UpdateGameLevel();
    }

    private void UpdatePlayerScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void UpdateGameLevel()
    {
        if (score > 10)
        {
            gameLevel = GameLevel.Medium;
        }
        else if (score > 20)
        {
            gameLevel = GameLevel.Hard;
        }
        else if (score > 30)
        {
            gameLevel = GameLevel.Legendary;
        }
        else
        {
            gameLevel = GameLevel.Easy;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviourManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

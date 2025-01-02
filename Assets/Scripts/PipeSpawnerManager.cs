using UnityEngine;

public class PipeSpawnerManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 4f;
    private float timer = 0f;

    private readonly float offsetY = 3;

    private GameLogicManager gameLogicManager;

    void Awake()
    {
        gameLogicManager = FindFirstObjectByType<GameLogicManager>();
    }

    void Update()
    {
        if (gameLogicManager.isGameOnPause)
        {
            return;
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }

        UpdateSpawnRate();
    }

    private void UpdateSpawnRate()
    {
        if (gameLogicManager.gameLevel >= GameLevel.Medium)
        {
            spawnRate = 3f;
        }
        else if (gameLogicManager.gameLevel >= GameLevel.Hard)
        {
            spawnRate = 2f;
        }
        else if (gameLogicManager.gameLevel >= GameLevel.Legendary)
        {
            spawnRate = 0.8f;
        }
        else
        {
            spawnRate = 4f;
        }
    }

    private void SpawnPipe()
    {
        float lowestY = transform.position.y - offsetY;
        float highestY = transform.position.y + offsetY;
        float randomY = Random.Range(lowestY, highestY);

        Instantiate(
            pipePrefab,
            new Vector3(transform.position.x, randomY, transform.position.z),
            transform.rotation
        );
    }
}

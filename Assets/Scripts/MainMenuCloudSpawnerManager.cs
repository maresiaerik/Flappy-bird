using UnityEngine;

public class MainMenuCloudSpawnerManager : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnRate = 180f;
    private float timer = -20f;

    private readonly float offsetY = 3;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCloud();
            timer = 0;
        }
    }

    private void SpawnCloud()
    {
        float lowestY = transform.position.y - offsetY;
        float highestY = transform.position.y + offsetY;
        float randomY = Random.Range(lowestY, highestY);

        Instantiate(
            cloudPrefab,
            new Vector3(transform.position.x, randomY, transform.position.z),
            transform.rotation
        );
    }
}

using UnityEngine;

public class PillarBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;
    private readonly float deadZone = -10f;

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

        UpdatePosition();

        UpdateMoveSpeed();
    }

    private void UpdatePosition()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateMoveSpeed()
    {
        if (gameLogicManager.gameLevel >= GameLevel.Medium)
        {
            moveSpeed = 1.3f;
        }
        else if (gameLogicManager.gameLevel >= GameLevel.Hard)
        {
            moveSpeed = 1.5f;
        }
        else if (gameLogicManager.gameLevel >= GameLevel.Legendary)
        {
            moveSpeed = 2f;
        }
        else
        {
            moveSpeed = 1f;
        }
    }
}

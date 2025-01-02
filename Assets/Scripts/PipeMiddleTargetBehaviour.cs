using UnityEngine;

public class PillarMiddleTargetBehaviour : MonoBehaviour
{
    private GameLogicManager gameLogicManager;

    void Awake()
    {
        gameLogicManager = FindFirstObjectByType<GameLogicManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerId collisionLayerId = (LayerId)collision.gameObject.layer;

        if (collisionLayerId == LayerId.Bird)
        {
            gameLogicManager.IncrementScoreAndUpdateUIBy(1);
        }
    }
}

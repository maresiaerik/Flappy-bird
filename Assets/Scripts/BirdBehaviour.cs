using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBehaviour : MonoBehaviour
{
    public Rigidbody2D bird;
    private bool isAlive = true;
    public GameLogicManager gameLogicManager;

    private readonly int flapStrength = 4;

    private readonly int minPositionY = -950;
    private readonly int maxPositionY = 880;

    void Awake()
    {
        gameLogicManager = FindFirstObjectByType<GameLogicManager>();
    }

    void Update()
    {
        if (gameLogicManager.isGameOnPause)
        {
            bird.simulated = false;
        }
        else
        {
            bird.simulated = true;
        }
    }

    public void FlyUp(InputAction.CallbackContext context)
    {
        if (context.performed && isAlive)
        {
            bird.linearVelocity = Vector2.up * flapStrength;

            if (transform.position.y < minPositionY)
            {
                gameLogicManager.GameOver();
                isAlive = false;
            }

            if (transform.position.y > maxPositionY)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    maxPositionY,
                    transform.position.z
                );
            }
        }
    }

    void OnCollisionEnter2D()
    {
        gameLogicManager.GameOver();
        isAlive = false;
    }
}

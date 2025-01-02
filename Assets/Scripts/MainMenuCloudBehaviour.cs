using UnityEngine;

public class MainMenuCloudBehaviour : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    private readonly float deadZone = -10f;

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

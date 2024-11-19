using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [Header("Cube Settings")]
    [SerializeField] private float moveSpeed = 3.0f;   // Speed of movement
    [SerializeField] private float changeDirectionTime = 2.0f; // Time interval to change direction

    private Vector3 moveDirection;   // The current move direction of the Cube
    private float timeToChangeDirection; // Timer to change the direction

    // Reference to the GameOverManager (to show the "Game Over" screen)
    public GameOverManager gameOverManager;

    private void Start()
    {
        // Set an initial random move direction
        SetRandomDirection();

        // Initialize the timer
        timeToChangeDirection = changeDirectionTime;
    }

    private void Update()
    {
        // Move the cube in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Countdown the time until we change direction
        timeToChangeDirection -= Time.deltaTime;

        // If the time is up, change the direction
        if (timeToChangeDirection <= 0f)
        {
            SetRandomDirection();
            timeToChangeDirection = changeDirectionTime;  // Reset the timer
        }
    }

    // Method to set a random direction for the cube
    private void SetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);  // Random X direction (-1 to 1)
        float randomZ = Random.Range(-1f, 1f);  // Random Z direction (-1 to 1)

        moveDirection = new Vector3(randomX, 0f, randomZ).normalized; // Normalize to keep the same speed
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check if the object that collided with the cube is the ball
        if (other.gameObject.CompareTag("Ball"))
        {
            // Destroy the ball
            Destroy(other.gameObject);

            // Show the game over screen
            gameOverManager.ShowGameOverScreen();
        }
    }
}

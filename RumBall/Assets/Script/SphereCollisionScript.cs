using UnityEngine;

public class SphereCollisionScript : MonoBehaviour
{
    public GameOverManager gameOverManager;  // Reference to the GameOverManager script

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Call the ShowGameOverScreen method when the collision happens
            gameOverManager.ShowGameOverScreen();

            // Destroy the sphere on collision
            Destroy(gameObject);  // This will destroy the sphere when it collides with the cube

            // Pause the game
            Time.timeScale = 0f;
        }
    }
}

using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float playerSpeed = 2.0f;       // Movement speed
    [SerializeField] private float gravityValue = -9.81f;    // Gravity
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>(); // Add CharacterController
    }

    void Update()
    {
        // Check if the player is grounded (detect if the character is on the ground)
        groundedPlayer = controller.isGrounded;

        // If grounded, prevent vertical velocity from being negative (to keep it grounded)
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;  // Keep the player grounded (small negative value)
        }

        // Get horizontal and vertical input for movement (WASD / Arrow keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Apply movement to the player
        Vector3 move = new Vector3(horizontal,0,vertical);
        controller.Move(move*Time.deltaTime*playerSpeed);

        // Apply gravity to the vertical velocity (falling when off the ground)
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move the character with gravity (Y axis)
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

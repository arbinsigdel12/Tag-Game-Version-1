using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform target;          // The target (ball) to follow
    [SerializeField] private float followHeight = 5f;   // Camera height offset above the ball
    [SerializeField] private float followDistance = 7f; // Distance from the ball on the x/z plane
    [SerializeField] private float followSmoothSpeed = 0.1f; // Smooth follow speed

    private Vector3 currentVelocity = Vector3.zero;  // For smooth follow

    private void LateUpdate()
    {
        // If target (ball) is not assigned, exit the update function
        if (target == null) return;

        // Calculate the desired position behind the ball
        Vector3 desiredPosition = target.position - target.forward * followDistance; // Offset position behind the ball
        desiredPosition.y = target.position.y + followHeight;  // Maintain a fixed height

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, followSmoothSpeed);

        // Make the camera look at the ball
        transform.LookAt(target);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the Doofus (Player)
    public Vector3 offset;    // Offset position of the camera relative to the player
    public float smoothSpeed = 1f; // Smoothing speed for the camera movement

    private void LateUpdate()
    {
        if (target != null)
        {
            // Desired camera position based on the player's position plus the offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}

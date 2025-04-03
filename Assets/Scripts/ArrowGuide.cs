using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Transform door; // Reference to the door
    public Vector3 offset; // Offset from the player's position
    public Vector3 forwardDirection = Vector3.forward; // Adjust this in the Inspector
    void Update()
    {
        // Calculate the distance between the player and the door
        float distance = Vector3.Distance(player.position, door.position);

        // Only show and rotate the arrow if the player is far from the door
        if (distance > 1f) // Adjust the threshold as needed
        {
            // Update the arrow's position to follow the player with an offset
            transform.position = player.position + offset;

            // Calculate the direction from the player to the door
            Vector3 direction = door.position - player.position;

            // Rotate the arrow to face the door
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction) * Quaternion.LookRotation(forwardDirection);
            }

            // Show the arrow
            gameObject.SetActive(true);
        }
        else
        {
            // Hide the arrow when the player is close to the door
            gameObject.SetActive(false);
        }
    }
}
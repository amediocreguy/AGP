using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform playerCamera; 
    public Vector3 minBounds; 
    public Vector3 maxBounds; 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((maxBounds + minBounds) / 2, maxBounds - minBounds);
    }

    void Update()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player camera not assigned!");
            return;
        }

        
        Vector3 clampedPosition = playerCamera.position;

        
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBounds.z, maxBounds.z);

        
        playerCamera.position = clampedPosition;
    }
}


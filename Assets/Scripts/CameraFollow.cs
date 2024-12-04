using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag the player object into this field
    public Vector3 offset; // Offset to keep the camera from being exactly on top of the player

    // Update is called once per frame
    void Update()
    {
        // Follow the player's position with the specified offset
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    
    void Update()
    {
        Vector3 camPos = player.position + offset;
        camPos.x = 0;
        transform.position = camPos;
    }
}

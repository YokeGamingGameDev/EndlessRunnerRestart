using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    //  public float Screenwidth = Screen.width * .5f;
    //  void Start()
    //  {
    //      float camdistance = offset.z;
    //      float fov = Mathf.Atan(Screenwidth /camdistance) * Mathf.Deg2Rad * 2f;
    //      GetComponent<Camera>().fieldOfView = fov;
    //  }
    

    
    void Update()
    {
        Vector3 camPos = player.position + offset;
        camPos.x = 0;
        transform.position = camPos;
    }
}

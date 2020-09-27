using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    public float speed;
    public float lerpSpeed;

    private int[] positions = { -5, 0, 5 };
    private int currPosInd;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currPosInd = 1;

        rb.velocity = new Vector3(0,0,speed);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            currPosInd += (int) Input.GetAxisRaw("Horizontal");

            currPosInd = Mathf.Clamp(currPosInd, 0, 2);
        }

        rb.velocity = Vector3.forward * speed;
        Vector3 desiredPos = new Vector3(positions[currPosInd], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * lerpSpeed);
    }
}

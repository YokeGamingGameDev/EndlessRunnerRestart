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

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public float frameMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currPosInd = 1;

        rb.velocity = new Vector3(0,0,speed);

        InvokeRepeating("CheckMobileInput", 0.0f, frameMultiplier * Time.deltaTime);
    }

    void Update()
    {
        //COMPUTER INPUT (Testing)
        if(Input.anyKeyDown)
        {
            currPosInd += (int) Input.GetAxisRaw("Horizontal");

            currPosInd = Mathf.Clamp(currPosInd, 0, 2);
        }

        rb.velocity = Vector3.forward * speed;
        Vector3 desiredPos = new Vector3(positions[currPosInd], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * lerpSpeed);
    }

    void CheckMobileInput()
    {
        //MOBILE INPUT
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = (touch.position - startPos).normalized;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            // Something that uses the chosen direction...
            Vector2 swipeDir;
            if (direction.x >= 0.5)
            {
                swipeDir = new Vector2(1, 0);
            }
            else if (direction.x <= -0.5)
            {
                swipeDir = new Vector2(-1, 0);
            }
            else if (direction.y > 0.5)
            {
                swipeDir = new Vector2(0, 1);
            }
            else
            {
                swipeDir = new Vector2(0, -1);
            }

            currPosInd += (int)swipeDir.x;
            currPosInd = Mathf.Clamp(currPosInd, 0, 2);

            directionChosen = false;        
        }
    }
}

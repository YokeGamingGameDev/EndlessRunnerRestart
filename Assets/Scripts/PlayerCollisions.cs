using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(2);
        }
    }
}

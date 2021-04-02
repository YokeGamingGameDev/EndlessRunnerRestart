using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumlogoTime = 3.0f; //min time of that scene

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha=1;

        if (Time.time < minimumlogoTime)
            loadTime = minimumlogoTime;
        else 
            loadTime = Time.time;
    }
    private void Update()
    {
        if (Time.time < minimumlogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }
        if (Time.time > minimumlogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumlogoTime;
            if (fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}

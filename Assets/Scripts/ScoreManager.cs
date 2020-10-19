using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public bool StillPlaying;

    private float score;
    

    void Start()
    {
        StillPlaying = true;
    }

    void Update()
    {
        if(StillPlaying)
        {
            score += Time.deltaTime;
        }

        ScoreText.text = "Score: " + score.ToString("F2");
    }

    public void CollectedCoin()
    {
        score += 10;
    }
}

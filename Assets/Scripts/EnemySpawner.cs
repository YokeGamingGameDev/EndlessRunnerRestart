using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] ObstacleSources; //0 - Nothing, 1 - Wall, 2 - Light Defender, 3 - Heavy Defender

    //public GameObject[] Obstacles;
    public Transform Player;

    private Vector3[] SpawnPositions;

    //Timer Variables
    private float timer;
    public float timeBetweenSpawns;

    void Start()
    {
        SpawnPositions =  new Vector3[] { new Vector3(-5, 0, 15), new Vector3(5, 0, 15), new Vector3(5, 0, 15) };
        Debug.Log(SpawnPositions);
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        if(timer <= 0)
        {
            for(int i = 0; i < 3; i++)
            {
                int randomInd = Random.Range(0, ObstacleSources.Length);
                Vector3 spawnPos = SpawnPositions[i];
                spawnPos.z += Player.position.z;
                spawnPos.y += (ObstacleSources[randomInd].transform.position.y);
                Instantiate(ObstacleSources[randomInd], spawnPos, ObstacleSources[randomInd].transform.rotation);
            }

            timer = timeBetweenSpawns;
        }
        timer -= Time.deltaTime;
    }
}

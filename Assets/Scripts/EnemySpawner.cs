using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] ObstacleSources; //0 - Nothing, 1 - Wall, 2 - Light Defender, 3 - Heavy Defender
    public List<GameObject> SpawnedObstacles;

    //public GameObject[] Obstacles;
    public Transform Player;

    private Vector3[] SpawnPositions;

    //Timer Variables
    private float timer;
    public float timeBetweenSpawns;

    void Start()
    {
        SpawnPositions =  new Vector3[] { new Vector3(-5, 0, 15), new Vector3(0, 0, 15), new Vector3(5, 0, 15) };
        Debug.Log(SpawnPositions);
        SpawnedObstacles = new List<GameObject>();
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        if(timer <= 0)
        {
            int omittedLane = Random.Range(0, 3);
            for(int i = 0; i < 3; i++)
            {
                if (i != omittedLane)
                {
                    int randomInd = Random.Range(0, ObstacleSources.Length);
                    Vector3 spawnPos = SpawnPositions[i];
                    spawnPos.z += Player.position.z;
                    spawnPos.y += (ObstacleSources[randomInd].transform.position.y);
                    GameObject newObstacle = Instantiate(ObstacleSources[randomInd], spawnPos, ObstacleSources[randomInd].transform.rotation) as GameObject;
                    SpawnedObstacles.Add(newObstacle);
                }
            }

            timer = timeBetweenSpawns;
        }

        if(SpawnedObstacles.Count > 10)
        {
            GameObject temp = SpawnedObstacles[0];
            SpawnedObstacles.RemoveAt(0);
            Destroy(temp);
        }
        timer -= Time.deltaTime;
    }
}

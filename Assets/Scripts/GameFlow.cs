using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    
    public GameObject PathObj;
    public Transform Player;

    public Transform[] Paths;
    private Vector3 PathPos;

    private int currMax = 40;

    void Start()
    {
        //StartCoroutine(PathTiles());
    }

    void Update()
    {
        for(int i = 0; i < Paths.Length; i++)
        {
            if(Player.position.z - Paths[i].position.z > 20)
            {
                currMax += 20;
                Paths[i].position = new Vector3(0, 0, currMax);
            }
        }
    }

    //IEnumerator PathTiles()
    //{
    //    yield return new WaitForSeconds(2);
    //    Instantiate(PathObj, PathPos, PathObj.rotation);
    //    PathPos.z += 20;
    //    Instantiate(PathObj, PathPos, PathObj.rotation);
    //    PathPos.z += 20;
    //    StartCoroutine(PathTiles());
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    private int obstaclesLength;
    public Transform obstaclesParent;
    public GameObject road;
    public Transform roadParent;
    
    // Start is called before the first frame update
    void Start()
    {
        obstaclesLength = obstacles.Length;


        for (int i = 0; i < 50; i++) 
        {
            int x = Random.Range(0, obstaclesLength);
            float f = Random.Range(-11f, -3f); // 
            Instantiate(obstacles[x], new Vector3(f, -1f, -45 * i - 45), new Quaternion(0, f, 0, 0), obstaclesParent);



        }
        /*
        for (int i = 0; i < 1000; i++) 
        {
            Instantiate(road, new Vector3(0, -10, -5 * i), new Quaternion(0, 0, 0, 0), roadParent);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

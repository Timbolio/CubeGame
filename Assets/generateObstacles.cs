using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    private int obstaclesLength;
    public GameObject[] coins;
    private int coinsLength;
    public Transform obstaclesParent;
    public GameObject road;
    public Transform roadParent;
    
    // Start is called before the first frame update
    void Start()
    {
        obstaclesLength = obstacles.Length;


        for (int i = 0; i < 50; i++) // generate cars to dodge
        {
            int x = Random.Range(0, obstaclesLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis
            float randRot = Random.Range(0f, 360f);
            Quaternion randRotQ = Quaternion.Euler(0f, randRot, 0f);
            Instantiate(obstacles[x], new Vector3(f, -1f, -45 * i - 45), randRotQ, obstaclesParent);

        }

        for (int i = 0; i < 50; i++)
        {
            int x = Random.Range(0, coinsLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis
            
            Quaternion randRotQ = Quaternion.Euler(0f, 0f, 90f);
            Instantiate(coins[x], new Vector3(f, -7.8f, -45 * i - 45), randRotQ);

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

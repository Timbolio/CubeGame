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
    public GameObject player;
    public int sectionsComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        obstaclesLength = obstacles.Length;
        PlayerPrefs.SetInt("coins", 99999);
        generate();
        
        
        // code commented below was used to generate the road. Obviously this isn't needed anymore, but I thought i'd leave it commented so you could see how I made it.
        
        /*
        for (int i = 0; i < 1000; i++) 
        {
            Instantiate(road, new Vector3(0, -10, -5 * i), new Quaternion(0, 0, 0, 0), roadParent);
        }
        */

    }


    void generate() 
    {
        for (int i = 0; i < 50; i++) // generate cars to dodge
        {
            int x = Random.Range(0, obstaclesLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis
            float randRot = Random.Range(0f, 360f);
            Quaternion randRotQ = Quaternion.Euler(0f, randRot, 0f);
            Instantiate(obstacles[x], new Vector3(f, -1f, -45 * i - 45 - (sectionsComplete * 2250)), randRotQ, obstaclesParent);

        }

        for (int i = 0; i < 50; i++)
        {
            int x = Random.Range(0, coinsLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis

            Quaternion randRotQ = Quaternion.Euler(0f, 0f, 90f);
            Instantiate(coins[x], new Vector3(f, 0, -45 * i - 45 - (sectionsComplete * 2250)), randRotQ);
            coins[x].SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < -2200 * sectionsComplete) // this is what allows the game to run endlessly, whilst not crashing when starting. Instead, the game loads in chunks of 50 objects at a time, with coins sprinked in.
        {
            sectionsComplete++;
            generate();
        }
    }
}

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
    public Transform coinsParent;
    public GameObject road;
    public Transform roadParent;
    public GameObject player;
    public int sectionsComplete;
    public int roadSectionsComplete;

    public move Move;
    
    // Start is called before the first frame update
    void Start()
    {
        obstaclesLength = obstacles.Length;
        PlayerPrefs.SetInt("coins", 99999);
        generate(); // generate obstacles and coins
        roadSectionsComplete = 0;


    }



    void generate() 
    {
        
        /*
        The generation method generates coins and obstacles in almost exactly the same way. For the cars, it randomly picks a car from the array obstaclesLength.
        This isnt needed for the coins as they all use the same prefab. Both create a random position on the road to spawn, and the cars generate a random orientation.
        For the instantiation, a new Vec3 passes through the rand x position, a set Y value of -1 for cars and 0 for coins (cars have larger scale) and for the Z value
        I space the objects 45f apart by using i. the -45 stops objects spawning directly on the player on start, and the sectionsComplete is used for when generating more chunks
        at a further distance, with each chunk generating objects for a z length of 2250. The 2250 is longer than the distance it generates for, allowing small intervals where the
        player can collect coins. This can run infinitely.
         
         */
        
        for (int i = 0; i < 50; i++) // generate cars to dodge
        {
            int x = Random.Range(0, obstaclesLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis
            float randRot = Random.Range(0f, 360f);
            Quaternion randRotQ = Quaternion.Euler(0f, randRot, 0f); // generates random orientation
            Instantiate(obstacles[x], new Vector3(f, -1f, -35 * i - 120 - (sectionsComplete * 2250)), randRotQ, obstaclesParent);

        }

        for (int i = 0; i < 50; i++) // generates coins to collect
        {
            int x = Random.Range(0, coinsLength);
            float f = Random.Range(-11f, -3f); // ran pos on x axis

            Quaternion randRotQ = Quaternion.Euler(0f, 0f, 90f);
            Instantiate(coins[x], new Vector3(f, -0.7f, -45 * i - 45 - (sectionsComplete * 2250)), randRotQ, coinsParent);
            coins[x].SetActive(true);

        }


        if (player.transform.position.z < 4500 * roadSectionsComplete) 
        {
            roadSectionsComplete++;
            for (int i = 0; i < 1000; i++)
            {
                Instantiate(road, new Vector3(0, -9.3f, -5 * i - 4500 * roadSectionsComplete), new Quaternion(0, 0, 0, 0), roadParent);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < -2200 * sectionsComplete) // this is what allows the game to run endlessly, whilst not crashing when starting. Instead, the game loads in chunks of 50 objects at a time, with coins sprinked in.
        {
            sectionsComplete++;
            Move.increaseSpeed();
            // increase player speed
            generate();
        }
    }
}

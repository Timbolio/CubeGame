using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatePlayer : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    public int selectedPlayer;
    
    // Start is called before the first frame update
    void Awake()
    {
        selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0);
        Instantiate(playerPrefabs[selectedPlayer]);
        playerPrefabs[selectedPlayer].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

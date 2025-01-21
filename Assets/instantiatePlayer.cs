using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatePlayer : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    public int selectedPlayer;
    
    void Awake() // this is in awake method as player needs to exist before start so its tag can be accessed to reference it in other scripts
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

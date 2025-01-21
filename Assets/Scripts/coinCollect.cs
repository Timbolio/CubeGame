using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinCollect : MonoBehaviour // script to collect coins and update coin text
{
    public GameObject self;
    public TMP_Text coinText;
    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0); // retrieves coins from save
        coinText.text = coins.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        increaseCoins(); // when collided, increase by 1
    }

    void increaseCoins() 
    {
        coins++;
        PlayerPrefs.SetInt("coins", coins); // save new amount of coins
        self.SetActive(false); // delete coin when collected
    }


    public void Update()
    {
        coinText.text = coins.ToString(); // update coins text on canvas
        
    }
}

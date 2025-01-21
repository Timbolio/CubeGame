using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class displayCoins : MonoBehaviour
{
    // simple script to display coins during the game.
    public TMP_Text coinText;
    int coins;
    
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    void Update()
    {
        coinText.text = coins.ToString();
    }
}

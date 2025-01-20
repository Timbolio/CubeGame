using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinCollect : MonoBehaviour
{
    public GameObject self;
    public TMP_Text coinText;
    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        increaseCoins();
        
    }

    void increaseCoins() 
    {
        coins++;
        PlayerPrefs.SetInt("coins", coins);
        self.SetActive(false);
    }


    public void Update()
    {
        coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
        
    }
}

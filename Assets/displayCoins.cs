using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class displayCoins : MonoBehaviour
{

    public TMP_Text coinText;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();
    }
}

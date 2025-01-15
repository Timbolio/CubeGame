using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSystem : MonoBehaviour
{
    public int coins;
    public int[] prices;
    public int selectedItem;
    public Texture[] textures;

    
    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        selectedItem = 0;
    }

    public void nextItem() 
    {
        selectedItem++;
    }


    public void previousItem() 
    {
        selectedItem--;
    }

    public void onPurchase() 
    {
        coins = coins - prices[selectedItem];
    }
}

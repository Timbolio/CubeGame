using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSystem : MonoBehaviour
{
    public int coins;
    public int[] prices;
    public int selectedItem;
    public Texture[] textures;
    public GameObject[] skins;
    public int[] ownedSkins;
    public GameObject[] skinsUIUnowned;
    public GameObject[] skinsUIOwned;



    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        selectedItem = 0;
    }

    public void nextItem() 
    {
        skins[selectedItem].SetActive(false);
        skinsUIUnowned[selectedItem].SetActive(false);
        skinsUIOwned[selectedItem].SetActive(false);
        selectedItem++;
        if (selectedItem > skins.Length) 
        {
            selectedItem = 0;
        }
        if (ownedSkins[selectedItem] == 1)
        {
            skinsUIOwned[selectedItem].SetActive(true);
        }
        else 
        {
            skinsUIUnowned[selectedItem].SetActive(true);
        }

        

    }


    public void previousItem() 
    {
        skins[selectedItem].SetActive(false);
        skinsUIUnowned[selectedItem].SetActive(false);
        skinsUIOwned[selectedItem].SetActive(false);
        selectedItem--;
        if (selectedItem < 0)
        {
            selectedItem = skins.Length;
        }
        if (ownedSkins[selectedItem] == 1)
        {
            skinsUIOwned[selectedItem].SetActive(true);
        }
        else
        {
            skinsUIUnowned[selectedItem].SetActive(true);
        }
        skins[selectedItem].SetActive(true);

    }

    public void onPurchase() 
    {
        coins = coins - prices[selectedItem];
        ownedSkins[selectedItem] = 1;
        skinsUIUnowned[selectedItem].SetActive(false);
        skinsUIOwned[selectedItem].SetActive(true);
        // save purchase in playerPrefs???
    }
}

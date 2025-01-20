using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinSystem : MonoBehaviour
{
    public int coins;
    public int[] prices;
    public int selectedItem;
    public int[] ownedSkins;
    public int selectedPlayer;

    public GameObject[] skins;
    public GameObject skinsUIUnowned;
    public GameObject skinsUIOwned;
    public GameObject selectButton;

    public string[] names;

    public TMP_Text priceText;
    public TMP_Text nameText;
    public TMP_Text playerCoins;
    public TMP_Text selectText;




    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0);
        selectedItem = 0;
        skins[selectedItem].SetActive(true);
        playerCoins.text = coins.ToString();
    }

    public void nextItem() 
    {
        skins[selectedItem].SetActive(false);
        skinsUIUnowned.SetActive(false);
        skinsUIOwned.SetActive(false);
        selectedItem++;
        if (selectedItem > skins.Length - 1) 
        {
            selectedItem = 0;
        }
        if (ownedSkins[selectedItem] == 1)
        {
            skinsUIOwned.SetActive(true);
            if (selectedItem == selectedPlayer) 
            {
                Select();
            }
        }
        else 
        {
            skinsUIUnowned.SetActive(true);
            priceText.text = prices[selectedItem].ToString(); 
            nameText.text = names[selectedItem];

        }
        skins[selectedItem].SetActive(true);




    }


    public void previousItem() 
    {
        skins[selectedItem].SetActive(false);
        skinsUIUnowned.SetActive(false);
        skinsUIOwned.SetActive(false);
        selectedItem--;
        if (selectedItem < 0)
        {
            selectedItem = skins.Length - 1;
        }
        if (ownedSkins[selectedItem] == 1)
        {
            skinsUIOwned.SetActive(true);
        }
        else
        {
            skinsUIUnowned.SetActive(true);
            priceText.text = prices[selectedItem].ToString();
            nameText.text = names[selectedItem];
        }
        skins[selectedItem].SetActive(true);

    }

    public void onPurchase() 
    {
        coins = coins - prices[selectedItem];
        ownedSkins[selectedItem] = 1;
        skinsUIUnowned.SetActive(false);
        skinsUIOwned.SetActive(true);
        // save purchase in playerPrefs???
    }



    public void Select() 
    {
        selectButton.SetActive(false);
        selectText.text = "Selected!";
        selectedPlayer = selectedItem;
        PlayerPrefs.SetInt("selectedPlayer", selectedPlayer);
        

    }
}

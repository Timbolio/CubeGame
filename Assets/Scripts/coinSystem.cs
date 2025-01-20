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
    public TMP_Text ownedNameText;
    public TMP_Text playerCoins;
    public TMP_Text selectText;




    void Start()
    {
        
        coins = PlayerPrefs.GetInt("coins", 0);
        selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0);
        selectedItem = 0;
        skins[selectedItem].SetActive(true);
        skinsUIUnowned.SetActive(false);
        skinsUIOwned.SetActive(true);
        playerCoins.text = coins.ToString();
        Time.timeScale = 1f;


        for (int i = 0; i < ownedSkins.Length; i++) 
        {
            if (PlayerPrefs.GetInt(names[i]) == 1) 
            {
                ownedSkins[i] = 1;
            }
        }
    }

    public void nextItem() // For right arrow Button
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
            if (selectedItem == selectedPlayer) // if current item we're looking at is the item the player currently has selected, then select it. (this is mainly for UI purposes)
            {
                Select();
            }
            else
            {
                selectButton.SetActive(true);
                selectText.text = "Select?";
            }
            ownedNameText.text = names[selectedItem] + " (Owned)";
        }
        else 
        {
            skinsUIUnowned.SetActive(true);
            priceText.text = prices[selectedItem].ToString(); 
            nameText.text = names[selectedItem];

        }
        skins[selectedItem].SetActive(true);




    }


    public void previousItem() // similar to right but requires slightly different logic to handle underflow errors in the array
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
            if (selectedItem == selectedPlayer) // if current item we're looking at is the item the player currently has selected, then select it. (this is mainly for UI purposes)
            {
                Select();
            }
            else 
            {
                selectButton.SetActive(true);
                selectText.text = "Select?";
            }
            ownedNameText.text = names[selectedItem] + " (Owned)";
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
        // TODO: If statements checking logic for purchases, enough money, not already owned etc.
        if (coins > prices[selectedItem] && ownedSkins[selectedItem] == 0) 
        {
            coins = coins - prices[selectedItem]; // subtract price from coins
            PlayerPrefs.SetInt("coins", coins); // save new amount of coins
            ownedSkins[selectedItem] = 1;
            skinsUIUnowned.SetActive(false);
            skinsUIOwned.SetActive(true);
            PlayerPrefs.SetInt(names[selectedItem], 1); // save purchase through name of prefab bought
            Select(); // autoselect item that has been bought. 
        }
        
        
    }



    public void Select() 
    {
        selectButton.SetActive(false);
        selectText.text = "Selected!";
        selectedPlayer = selectedItem; // save selected skin for in game
        PlayerPrefs.SetInt("selectedPlayer", selectedPlayer);
        

    }
}

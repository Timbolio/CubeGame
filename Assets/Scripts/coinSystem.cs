using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinSystem : MonoBehaviour
{
    public int coins; // amount of coins the player has
    public int[] prices; // price list for each item
    public int selectedItem; // currently highlighted item
    public int[] ownedSkins; // bool array of owned skins, stored as int as PlayerPrefs does not support bool (uses 0 and 1)
    public int selectedPlayer; // the item the player currently has selected and is playing with.

    public GameObject[] skins; // skins represent prefabs of player with each texture
    public GameObject skinsUIUnowned; // the UI that should be displayed on selecting an item that is unowned (preventselecting item player hasnt bought)
    public GameObject skinsUIOwned; // display UI of item that has been purchased, allowing selection
    public GameObject selectButton; // reference to select button

    public string[] names; // stores the names of the skins which is applied to the nameText

    public TMP_Text priceText; // reference to the text displaying the price of the current item
    public TMP_Text nameText; // reference to the text displaying the name of the current item
    public TMP_Text ownedNameText; // reference to a separate text displayed when the item is owned (appends (Owned) on the end)
    public TMP_Text playerCoins; // reference to the text displaying the amount of coins the player has
    public TMP_Text selectText; // the text that reads "Select!" so can be updated to "Selected" when selected.




    void Start()
    {
        
        coins = PlayerPrefs.GetInt("coins", 0); // grabs saved amount of money
        selectedPlayer = PlayerPrefs.GetInt("selectedPlayer", 0); // grabs player user is currently using
        selectedItem = 0; // on start, highlight Classic skin
        skins[selectedItem].SetActive(true); // display appropriate prefab
        skinsUIUnowned.SetActive(false); // disable unowned UI as base prefab is owned by default
        skinsUIOwned.SetActive(true); // display owned UI
        playerCoins.text = coins.ToString(); // display coins player has
        Time.timeScale = 1f; // Unfreezes time


        for (int i = 0; i < ownedSkins.Length; i++)  // for each item in ownedskins, check if player has bought. If yes, update to 1 (owned)
        {
            if (PlayerPrefs.GetInt(names[i]) == 1) 
            {
                ownedSkins[i] = 1;
            }
        }
    }


    void updateItem() 
    {
        if (ownedSkins[selectedItem] == 1) // checks if player owns newly highlighted item
        {
            skinsUIOwned.SetActive(true);
            if (selectedItem == selectedPlayer) // if current item we're looking at is the item the player currently has selected, then select it. (this is mainly for UI purposes)
            {
                Select();
            }
            else
            {
                selectButton.SetActive(true); // If owned but not selected, display select button to give option to select
                selectText.text = "Select?";
            }
            ownedNameText.text = names[selectedItem] + " (Owned)"; // tell player they own this item
        }
        else
        {
            skinsUIUnowned.SetActive(true); // if not owned, display according UI to allow a purchase
            priceText.text = prices[selectedItem].ToString();
            nameText.text = names[selectedItem];

        }
        skins[selectedItem].SetActive(true); // display prefab of newly highlighted item
    }

    void unselectItem() 
    {
        skins[selectedItem].SetActive(false);
        skinsUIUnowned.SetActive(false);
        skinsUIOwned.SetActive(false); // disable all UI and prefab
    }

    public void nextItem() // For right arrow Button
    {
        unselectItem();
        selectedItem++; // increments selected item
        if (selectedItem > skins.Length - 1) // loops to start to avoid array overflow error
        {
            selectedItem = 0;
        }
        updateItem();
    }

    public void previousItem() // similar to right but requires slightly different logic to handle underflow errors in the array
    {
        unselectItem();
        selectedItem--;
        if (selectedItem < 0) // underflow handler
        {
            selectedItem = skins.Length - 1;
        }
        updateItem();
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

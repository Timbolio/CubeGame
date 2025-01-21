using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour // simple script for canvas buttons to toggle between the various scenes/
{
    public void StartGame() // starts game, this is called on restart button too
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadSettings() // loads settings
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void LoadMenu() // loads main menu
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadShop() // loads shop
    {
        SceneManager.LoadScene("ShopScene");
    }
}

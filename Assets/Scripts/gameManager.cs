using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadSettings() 
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadShop() 
    {
        SceneManager.LoadScene("ShopScene");
    }
}

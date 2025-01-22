using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsSystem : MonoBehaviour
{

    public int inputMethod;
    public GameObject touchIconSelected;
    public GameObject turnIconSelected;

    // Start is called before the first frame update
    void Start()
    {
        inputMethod = PlayerPrefs.GetInt("input", 1);
        touchIconSelected.SetActive(false);
        turnIconSelected.SetActive(false);
        UpdateInput();
    }


    public void TouchInput() 
    {
        inputMethod = 1;
        UpdateInput();
    }

    public void TurnInput() 
    {
        inputMethod = 0;
        UpdateInput();
    }


    public void UpdateInput() 
    {
        if (inputMethod == 0)
        {
            touchIconSelected.SetActive(false);
            turnIconSelected.SetActive(true);
        }
        else 
        {
            touchIconSelected.SetActive(true);
            turnIconSelected.SetActive(false);
        }
        PlayerPrefs.SetInt("input", inputMethod);

    }
}

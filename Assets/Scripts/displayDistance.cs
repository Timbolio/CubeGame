using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class displayDistance : MonoBehaviour
{
    public TMP_Text scoreText; // reference to score text
    GameObject obj; // player reference

    public void Start() 
    {
        obj = GameObject.FindWithTag("Player"); // grabs player by finding "Player" tag
    }


    private void Update()
    {
        float xPos = obj.transform.position.z; // score is players z position
        float xPosRounded = Mathf.Round(xPos); // rounds to whole num

        scoreText.text = Mathf.Abs(xPosRounded).ToString(); // I use Abs because the player is moving in the negative direction but I want the score to be positive
    }
}

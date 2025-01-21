using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float screenWidth = Screen.width; // grabs width of screen regardless of device size and aspect ratio
    private bool dead; // check if dead
    public GameObject deadUI;
    public GameObject playerScoreGame; // stored as GameObject as is only referenced to be enabled and disabled
    public TMP_Text playerScoreDead; // stored as TMP_Text as text is modified to new score value


    private void Start()
    {
        dead = false; // Player can't be dead the moment the game starts
        deadUI.SetActive(false); // disable dead UI
        Time.timeScale = 1f; // enable time
        playerScoreGame = GameObject.Find("Score"); // grab reference to players score
        
    }

    void Update()
    {
        if (!dead) // whilst not dead, move forwards
        {
            rb.velocity = new Vector3(0f, 0f, -speed);
        }


        // TODO: Add checkbox to decide which input method to use, also test accelerometer through android studio by building as apk


        Vector3 accelerometer = Input.acceleration;
        float tilt = accelerometer.x;
        rb.AddForce(tilt * 20000f * Time.deltaTime, 0f, 0f);




        if (Input.touchCount > 0) // when player touches screen
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (screenWidth / 2)) // If player touches right side, move left, if touches left side, moev right. (I like it inverted)
            {
                rb.AddForce(20000f * Time.deltaTime, 0f, 0f); // applies force
            }
            else
            {
                rb.AddForce(-20000f * Time.deltaTime, 0f, 0f);
            }
        }


        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // If object collided with is an obstacle, die.
        {
            dead = true;
            float score = Mathf.Abs(Mathf.Round(transform.position.z));
            deadUI.SetActive(true);
            playerScoreGame.SetActive(false);
            playerScoreDead.text = "Score:" + score;
            Invoke("stopTime", 20); // stops time 2 seconds after death, giving player time to process what happened
            
        }
    }

    void stopTime() 
    {
        Time.timeScale = 0f;
    }

    public void increaseSpeed() 
    {
        speed = speed + 5f;
    }



}

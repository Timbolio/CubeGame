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
    private bool lDown;
    private bool rDown;
    private float screenWidth = Screen.width;
    private bool dead = false;
    public GameObject deadUI;
    public GameObject playerScoreGame;
    public TMP_Text playerScoreDead;
    public GameObject player;
    public float slideFactor;

    private void Start()
    {
        dead = false;
        deadUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!dead) 
        {
            rb.velocity = new Vector3(0f, 0f, -speed);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (screenWidth / 2))
            {
                rb.AddForce(45f, 0f, 0f);
            }
            else
            {
                rb.AddForce(-45f, 0f, 0f);
            }
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            dead = true;
            float score = Mathf.Abs(Mathf.Round(player.transform.position.z));
            deadUI.SetActive(true);
            playerScoreGame.SetActive(false);
            playerScoreDead.text = "Score:" + score;
            
        }
    }



}

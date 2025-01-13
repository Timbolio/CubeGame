using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private bool lDown;
    private bool rDown;
    private float screenWidth = Screen.width;
    private bool dead = false;
    public GameObject deadUI;

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
            rb.AddForce(0f, 0f, -speed);
        }

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (screenWidth / 2))
            {
                rb.AddForce(0f, 0f, speed);
            }
            else
            {
                rb.AddForce(0f, 0f, -speed);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            dead = true;
            deadUI.SetActive(true);
            
        }
    }



}

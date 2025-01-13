using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{

    bool gameover = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {
            gameover = true;
            // stop player movement
            // display you died UI
        }
    }
}

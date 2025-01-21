using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float rotationSpeed = 30f;
    public float bobbingHeight = 0.8f;
    public float bobbingSpeed = 1f;

    

    void FixedUpdate() // I found fixed update to provide better performance and smoother movement as it updates with each rendered frame
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight - 1f; // uses sin wave to "bob" coin up and down. Neat animation.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z); // updates position
    }

}

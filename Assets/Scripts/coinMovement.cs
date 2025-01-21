using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float rotationSpeed = 30f;
    public float bobbingHeight = 0.8f;
    public float bobbingSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight - 1f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

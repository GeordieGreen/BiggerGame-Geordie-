using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(moveX, 0, moveZ);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        
    }
}

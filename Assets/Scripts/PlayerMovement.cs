using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    public float speed = 5.0f;
    public float gravity = 9.81f;
    public float jumpForce = 30f;
    public float doubleJump = 0.5f;

    float directionY;

    private bool isDoubleJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector3 facing = new Vector3(xMovement, 0, yMovement);

        if (controller.isGrounded)
        {
            isDoubleJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpForce;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDoubleJump)
            {
                directionY = jumpForce * doubleJump;
                isDoubleJump = false;
            }
        }

        

        directionY -= gravity * Time.deltaTime;

        facing.y = directionY;

        controller.Move(facing * speed * Time.deltaTime);

        
    }
}

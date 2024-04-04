using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight =  2f;
    public bool isGrounded;

    public float speed;
    public float jumpForce;
    public float gravitySpeed;
    public float groundDrag;
    public float airDrag;


    Rigidbody rb;
    public StaminaBar staminabar;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 2.5f);
        if(Input.GetButtonDown("Horizontal") ||Input.GetButtonDown("Vertical") ){
            FindObjectOfType<AudioManager>().Play("steps");
        }
        if(Input.GetButtonUp("Horizontal") ||Input.GetButtonUp("Vertical") ){
            FindObjectOfType<AudioManager>().Stop("steps");
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = rb.velocity.y;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        rb.velocity = move;

        //       if (Input.GetButtonDown("Jump") && isGrounded)
        //       {
        //           Jump();
        // }
        staminabar.Sprint();
        Gravity();

        
    }

    void ControlDrag()
    {
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    void Gravity()
    {
        rb.AddForce(new Vector2(0, -gravitySpeed));
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            staminabar.DecreaseStamina();
            rb.AddForce(transform.forward * speed * 2, ForceMode.Acceleration);
        }
    }
    public void StopRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            staminabar.DecreaseStamina();
            rb.AddForce(transform.forward * speed * 0, ForceMode.Acceleration);
        }
    }
}

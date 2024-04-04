using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player movement, including walking, running, and gravity.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravitySpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;

    private Rigidbody rb;
    [SerializeField] private StaminaBar staminabar;

    // Initializes the Rigidbody component.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Plays footstep sounds based on player movement input.
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            FindObjectOfType<AudioManager>().Play("steps");
        }
        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            FindObjectOfType<AudioManager>().Stop("steps");
        }
    }

    // Moves the player character based on input and applies gravity.
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = rb.velocity.y;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        rb.velocity = move;
        staminabar.Sprint();
        ApplyGravity();
    }

    // Applies gravity force to the player character.
    private void ApplyGravity()
    {
        rb.AddForce(new Vector2(0, -gravitySpeed));
    }

    // Initiates running when the appropriate input keys are pressed.
    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            staminabar.DecreaseStamina();
            rb.AddForce(transform.forward * speed * 2, ForceMode.Acceleration);
        }
    }

    // Stops running when the appropriate input keys are released.
    public void StopRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            staminabar.DecreaseStamina();
            rb.AddForce(transform.forward * speed * 0, ForceMode.Acceleration);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;       // Horizontal movement speed
    [SerializeField] private float jumpForce = 10f; // Jump force
    [SerializeField] private AudioClip jumpSound;   // Jump sound effect
    private Rigidbody2D body;
    private Animator anim;
    private AudioSource audioSource;
    private bool grounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Handle horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the character sprite depending on direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1); // Move right
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1); // Move left

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        // Update animations
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        grounded = false;

        // Play jump sound
        if (jumpSound != null && audioSource != null)
            audioSource.PlayOneShot(jumpSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            Debug.Log("Player grounded."); // Debug to confirm grounded state
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}



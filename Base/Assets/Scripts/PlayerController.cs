using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; // + vel = right | - vel = left | 0 vel = standing still
    public float jumpSpeed;
    public Rigidbody2D myRigidbody;

    public Transform groundCheck; // Position of the object
    public float groundCheckRadius; // Position radius of the object
    public LayerMask whatIsGround; // Ground Layer

    public bool isGrounded; // True if player is on the ground

    private Animator myPlayerAnim;


    // Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myPlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Create an overlap circle with the given parameters and check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        /* Player's Movement */
        if (Input.GetAxisRaw("Horizontal") > 0f)  // Moving to the right
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        else if (Input.GetAxisRaw("Horizontal") < 0f)  // Moving to the left
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        else // Reduce sliding movement
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);

        /* Player's Jump */
        if (Input.GetButtonDown("Jump") && isGrounded) // If input is jump buttion and isGrounded = true
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
    }
}

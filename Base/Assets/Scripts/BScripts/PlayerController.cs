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

    public Vector3 respawnPosition;

    public LevelManager theLevelManager; // For respawn

    // Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myPlayerAnim = GetComponent<Animator>();

        respawnPosition = transform.position;

        theLevelManager = FindObjectOfType<LevelManager>(); // Find levelManager in the current scence
    }

    // Update is called once per frame
    void Update() {
        // Create an overlap circle with the given parameters and check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        /* Player's Movement */
        if (Input.GetAxisRaw("Horizontal") > 0f) {  // Moving to the right
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f); // x = 1, Scale Player's animation facing right
        } else if (Input.GetAxisRaw("Horizontal") < 0f) { // Moving to the left
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f); // x = -1, Scale Player's animation facing left
        }
        else // Reduce sliding movement
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);

        /* Player's Jump */
        if (Input.GetButtonDown("Jump") && isGrounded) // If input is jump buttion and isGrounded = true
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);

        /* Setting Animations value */
        myPlayerAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myPlayerAnim.SetBool("Grounded", isGrounded);
    }

    // If the player enters the Trigger Area(Plane kill, other)
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "KillPlane") {
            //gameObject.SetActive(false); // Object of the script that is attached to is not active in the scne
            //transform.position = respawnPosition; // Respawn back to checkpoint position
            theLevelManager.Respawn();
        }

        if(other.tag == "Checkpoint") {
            respawnPosition = other.transform.position; // other's position is the checkpoint position, have player respawn at checkpoint's position
        }
    }
}

// <copyright file="PlayerInputModule2D.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>07/14/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for general purpose 2D controls for any object that can move and jump when grounded.
/// </summary>
[RequireComponent (typeof(Rigidbody2D))]
public class PlatformerController2D : MonoBehaviour
{
	[Header ("Controls")]
	[HideInInspector] public Vector2 input;	// horizontal movement
	[HideInInspector] public bool inputJump;	// jumping (whether space is pressed or not)
	[HideInInspector] public bool inputItem;	// Use Item (whether A is pressed or not)



	[Header ("Grounding")]
	[Tooltip ("Offset of the grounding raycasts (red lines)")]
	[SerializeField] Vector2 groundCheckOffset = new Vector2 (0, -0.6f); // set the location of the raycast
	[Tooltip ("Width of the grounding raycasts.")]
	[SerializeField] float groundCheckWidth = 0.7f; // distances between each raycast
	[Tooltip ("Distance of the grounding raycasts.")]
	[SerializeField] float groundCheckDepth = 0.2f; // how long the raycast is
	[Tooltip ("Number of the grounding Raycsts. Will be evenly spread over the width")]
	[SerializeField] int groundCheckRayCount = 3;	// the number of raycast
	[Tooltip ("Layers to be considered ground.")]
	[SerializeField] LayerMask groundLayers = 0;


	public GameObject shieldPrefab;
	private float speed = 5f; 	// horizontal movement speed
	private bool grounded = false; 	// on ground or not
	private float gravity = 5f;
	private Rigidbody2D rb;
	private float jumpForce = 10f;
	// private float lastGroundingTime = 0;


	void Start () {
		inputItem = false;
		// print (inputItem);
		// grounded = false;
		rb = GetComponent <Rigidbody2D> ();
	}

	/// <summary>
	/// Controls the basic update of the controller. This uses fixed update, since the movement is physics driven and has to be synched with the physics step.
	/// </summary>
	void FixedUpdate () {
		UpdateGrounding ();

		Vector2 velocity = rb.velocity;
		// horizontal
		velocity.x = input.x * speed;
		if (inputJump && grounded) {
			// velocity.y = jumpForce; // amount of jump
			velocity = ApplyJump (velocity);

			// grounded = false;
			// print ("attempt jump");
		}

		velocity.y += -gravity * Time.deltaTime;
		rb.velocity = velocity;

	}

	void Update () {
		// if (Coins.instance.canUseItem && inputItem) {
		if (CoinPanel.instance.canUseItem() && inputItem) {
			UseItem ();

			// print ("Use the item");
		}	
	}

	Vector2 ApplyJump (Vector2 velocity) {
		velocity.y = jumpForce; // amount of jump
		grounded = false;
		return velocity;
	}

	void UseItem () {
		Player player = GetComponent<Player> ();
		CoinPanel.instance.removeCoins ();
		Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);

	}

	/*
	void OnCollisionStay2D() {
		// print ("grounded");
		grounded = true;
	}
	*/

	/// <summary>
	/// Updates grounded and lastGroundingTime.
	/// </summary>
	void UpdateGrounding ()
	{
		
		Vector2 groudCheckCenter = new Vector2 (transform.position.x + groundCheckOffset.x, transform.position.y + groundCheckOffset.y);
		Vector2 groundCheckStart = groudCheckCenter + Vector2.left * groundCheckWidth * 0.5f;
		if (groundCheckRayCount > 1) {
			for (int i = 0; i < groundCheckRayCount; i++) {
				
				RaycastHit2D hit = Physics2D.Raycast (groundCheckStart, Vector2.down, groundCheckDepth, groundLayers);
				// print ("update grounding");
				if (hit.collider != null) {
					print ("update grounding");
					grounded = true;
					return;
				}

				groundCheckStart += Vector2.right * (1.0f / (groundCheckRayCount - 1.0f)) * groundCheckWidth;
			}
		}
		/*
		if (grounded) {
			lastGroundingTime = Time.time;
		}
*/
		grounded = false;

	}


	/// <summary>
	/// Used to draw the red lines for the grounding raycast. Only active in the editor and when the instance is selected.
	/// </summary>
	void OnDrawGizmosSelected(){
		Vector2 groudCheckCenter = new Vector2 (transform.position.x + groundCheckOffset.x, transform.position.y + groundCheckOffset.y);
		Vector2 groundCheckStart = groudCheckCenter + Vector2.left * groundCheckWidth * 0.5f;
		if (groundCheckRayCount > 1) {
			for (int i = 0; i < groundCheckRayCount; i++) {
				Debug.DrawLine (groundCheckStart, groundCheckStart + Vector2.down * groundCheckDepth, Color.red);
				groundCheckStart += Vector2.right * (1.0f / (groundCheckRayCount - 1.0f)) * groundCheckWidth;
			}
		}
	}


}
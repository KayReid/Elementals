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
	[HideInInspector] public Vector2 input;	// horizontal movement
	[HideInInspector] public bool inputJump;	// jumping (whether space is pressed or not)
	[HideInInspector] public bool inputItem;	// Use Item (whether A is pressed or not)

	public GameObject shieldPrefab;


	private float speed = 5f; 	// horizontal movement speed
	private bool grounded; 	// on ground or not
	private float gravity = 5f;
	// public bool canMove;	// whether this object can move or not

	Rigidbody2D rb;
	float jumpForce = 10f;

	void Start () {
		inputItem = false;
		// print (inputItem);
		grounded = false;
		rb = GetComponent <Rigidbody2D> ();
	}

	/// <summary>
	/// Controls the basic update of the controller. This uses fixed update, since the movement is physics driven and has to be synched with the physics step.
	/// </summary>
	void FixedUpdate () {

		Vector2 velocity = rb.velocity;
		// horizontal
		velocity.x = input.x * speed;
		if (inputJump && grounded) {
			// velocity.y = jumpForce; // amount of jump
			velocity = ApplyJump (velocity);


			// print ("attempt jump");
		}
		grounded = false;
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
		return velocity;
	}

	void UseItem () {
		Player player = GetComponent<Player> ();
		CoinPanel.instance.removeCoins ();
		Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);

	}


	void OnCollisionStay2D() {
		// print ("grounded");
		grounded = true;
	}


}
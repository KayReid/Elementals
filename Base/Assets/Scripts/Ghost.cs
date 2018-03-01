﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Killable {


	[Tooltip("Prefab to be instantiated when shooting (Snowball)")]
	public GameObject snowballPrefab;
	[Tooltip("The individual sprites of the animation")]
	public Sprite[] frames;
	[Tooltip("How fast does the animation play")]
	public float seconds;

	SpriteRenderer spriteRenderer;
	public int dir = -1;
	public float speed;
	public float rateOfFire;
	private float lastTimeFired = 0;
	public Collider2D body;
	public int numShoot = 3;

	public GameObject deathEffect;
    public AudioClip deathSound;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = true;
		StartCoroutine(PlayAnimation());
	}

	// Update is called once per frame
	void Update () {


	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.CompareTag ("shield")) {
			Die ();
		}
		if (col.collider.CompareTag("Player"))
		{
			Player player = col.transform.root.GetComponentInChildren<Player>();
			player.Die();
		}

	}
		
	public override void Die()
	{
		StartCoroutine(explosionEffect());
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Invoke ("Remove" , 1);

	}
	public void Remove (){
		Destroy (gameObject);
	}


	IEnumerator explosionEffect() {
		gameObject.SetActive(false);
		Instantiate(deathEffect, transform.position, transform.rotation);
		yield return new WaitForSeconds(1);
	}


	IEnumerator PlayAnimation() {
		int currentFrameIndex = 0;
		while (true) {
			spriteRenderer.sprite = frames [currentFrameIndex];
			// yield return new WaitForSeconds(1f / framesPerSecond);
			yield return new WaitForSeconds(seconds);
			currentFrameIndex++;
			currentFrameIndex = currentFrameIndex%frames.Length;
			if (currentFrameIndex == 1) {
				Shoot ();
			}
			
		}

	}

	void Shoot () {
		// Create the new projectile a bit in front of the spaceship and store the reference to the new gameobject.
		// the Instatiate function creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.

		GameObject snowballObject = Instantiate(snowballPrefab, transform.position + new Vector3 (dir, 0, 0), Quaternion.identity) as GameObject;
		// Get access to the script on the new snowbball using GetComponent to modify it.
		SnowBall snowball = snowballObject.GetComponent<SnowBall> ();
		snowball.direction.x = dir;

	}
}

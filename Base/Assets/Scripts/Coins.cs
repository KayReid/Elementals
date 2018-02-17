﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour {


	[Tooltip("The individual sprites of the animation")]
	// frames of coins (Rotating)
	public Sprite[] frames;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine (PlayAnimation (0.15f));
	}
		

	void OnTriggerEnter2D (Collider2D other) {
		// if the other object has the player tag...
		if (other.CompareTag ("Player")) {
			Player player = other.GetComponent<Player> ();
			player.CollectCoins ();
			Destroy (gameObject);
		}
	}
		


	/// <summary>
	/// This is a coroutine that cycles through the sprites of coin animation. It needs to be started using StartCoroutine().
	/// </summary>
	IEnumerator PlayAnimation(float seconds) {
		int currentFrameIndex = 0;
		while (true) {
			spriteRenderer.sprite = frames [currentFrameIndex];
			// yield return new WaitForSeconds(1f / framesPerSecond);
			yield return new WaitForSeconds(seconds);
			currentFrameIndex++;
			currentFrameIndex = currentFrameIndex%frames.Length;
		}

	}


}

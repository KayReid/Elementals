using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatforms : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("player")) {
			Weak ();
		}
	}

	/// <summary>
	/// Destroy the platform, play animation
	/// </summary>
	public void Weak ()
	{
		Invoke ("Remove" , 3);
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}
}

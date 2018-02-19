using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatforms : MonoBehaviour {


	void OnCollisionEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Weak ();
		}
	}

	/// <summary>
	/// Destroy the platform, play animation
	/// </summary>
	public void Weak ()
	{
		print ("touching");
		Invoke ("Remove" , 3);
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}
}

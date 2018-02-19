using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatforms : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Invoke("Remove", 2);
		}
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}
}

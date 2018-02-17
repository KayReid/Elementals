using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
[RequireComponent (typeof(PlatformerController2D))]
public class Player : MonoBehaviour
{

	Renderer rend;
	public Text coinText;
	public int numCoins;

	void Awake ()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		numCoins = 0;
		setCoinText ();
	}
		
	IEnumerator blinkCoroutine (int numBlinks, float seconds) {
		for (int i=0; i<numBlinks*2; i++) { 	// *2 is necessary because we want renderer.enabled = true and false 
			// back and forth 3 times
			//toggle renderer
			rend.enabled = !rend.enabled;
			rend.material.color = Color.red;
			//wait for a bit
			yield return new WaitForSeconds(seconds);
		}

		//make sure renderer is enabled when we exit
		rend.enabled = true;
		rend.material.color = Color.white;

	}

	/// <summary>
	/// collision with spikes invokes death
	/// </summary>

	void OnTriggerEnter2D (Collider2D other) {
		// if the other object has the MainCamera tag, destroy the shits
		if (other.CompareTag ("spikes")) {
			Die ();
		}
	}

	/// <summary>
	/// Destroy the player and spawn the death animation.
	/// </summary>
	public void Die ()
	{
		// Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		StartCoroutine (blinkCoroutine (3, 0.2f));
		Invoke ("Remove" , 3);
		// restart level here? Thanks.
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}

	public void CollectCoins () {
		numCoins++;
		setCoinText ();
	
	}
	void setCoinText () {
		coinText.text = numCoins.ToString ();

	}

}

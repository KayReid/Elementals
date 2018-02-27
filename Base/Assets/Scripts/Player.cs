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
	public static Player instance;

    // PlatformerController2D controller;
    //public bool ground;


	void Awake ()
	{
		instance = this;
		rend = GetComponent<Renderer>();
		rend.enabled = true;

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
	/// Destroy the player and spawn the death animation.
	/// </summary>
	public void Die ()
	{
		// Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		StartCoroutine (blinkCoroutine (3, 0.2f));
		Invoke ("Remove" , 1);
        // restart level here
        GameManager.instance.RestartTheGameAfterSeconds(2);
    }

    /// <summary>
    /// Restart the level when the player exits the screen - results in a faster restart, since death animation doesn't play.
    /// </summary>
    public void ExitScreen()
    {
        Invoke("Remove", 0.5f);
        GameManager.instance.RestartTheGameAfterSeconds(1.5f);
    }

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}
		



}

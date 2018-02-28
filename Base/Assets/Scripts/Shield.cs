using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlatformerController2D))]
public class Shield : MonoBehaviour {

	[Tooltip ("After how many seconds is the Shield destroyed")]
	public float lifeTime = 5;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// circle.enabled = false;
		StartCoroutine (KillAfterSeconds (lifeTime));
		// controller = GetComponent<PlatformerController2D> ();
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.instance != null) {
			transform.position = Player.instance.transform.position;

			// print (transform.position.x);
		}
			
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		/*
		// force is how forcefully we will push the player away from the enemy.
		float force = 3;
		// If the object we hit is the enemy
		if (col.gameObject.tag == "enemy") {
			
			// Calculate Angle Between the collision point and the players
			Vector3 dir = col.contacts[0].point - transform.position;
			// We then get the opposite (-Vector3) and normalize it
			dir = -dir.normalized;
			// And finally we add force in the direction of dir and multiply it by force. 
			// This will push back the player
			GetComponent<Rigidbody> ().AddForce (dir * force);
		}
		*/
		if (col.gameObject.tag == "spikes") {
			// how much the character should be knocked back
			var magnitude = 5000;
			// calculate force vector
			var force = transform.position - col.transform.position;
			// normalize force vector to get direction only and trim magnitude
			force.Normalize ();
			rb.AddForce (force * magnitude);
		}

	}

	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
		// PlatformerController2D.instance.groundCheckOffset.y = -0.6f;
		// circle.enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {


	[Tooltip ("How fast is the snowball moving")]
	public float speed = 2;
	[Tooltip ("After how many seconds is the snowball destroyed")]
	public float lifeTime = 3;
	[Tooltip ("The direction the snowball travels")]
	public Vector2 direction;
	[SerializeField] LayerMask shieldLayers = 0;
	public Collider2D check = null; // 

	void Start ()
	{
		direction.Normalize ();
		StartCoroutine (KillAfterSeconds (lifeTime));
	}


	void Update ()
	{
		if (check.IsTouchingLayers (shieldLayers)) {
			print ("touch");
			direction.x *= 1;
			Destroy (gameObject);
		}
		transform.position += new Vector3 (direction.x, 0, 0) * speed * Time.deltaTime;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) { // This checks if we hit an asteroid. The asteroid needs the "Asteroid" tag for this to work!!
			Player player = other.GetComponent<Player> (); // Grab the asteroid script from the hit GameObject
			player.Die (); // notify the asteroid it got hit
			Destroy (gameObject); // Destory this projectile
		}
	}


	/// <summary>
	/// Destroys the projectile after seconds. This is a coroutine that needs be started using StartCoroutine().
	/// </summary>
	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlatformerController2D))]
public class Shield : MonoBehaviour {

	[Tooltip ("After how many seconds is the Shield destroyed")]
	public float lifeTime = 5;



	// Use this for initialization
	void Start () {
		StartCoroutine (KillAfterSeconds (lifeTime));
		// controller = GetComponent<PlatformerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.instance != null) {
			transform.position = Player.instance.transform.position;

			// print (transform.position.x);
		}


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("enemy")) {
			Enemy enemy = other.GetComponent<Enemy> ();
			if (enemy.dir == 1) {
				enemy.dir = -1;
			} else {
				enemy.dir = 1;
			}
			print (enemy.dir);
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

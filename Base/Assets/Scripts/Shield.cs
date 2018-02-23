using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlatformerController2D))]
public class Shield : MonoBehaviour {

	[Tooltip ("After how many seconds is the Shield destroyed")]
	public float lifeTime = 3;
	// public CircleCollider2D circle;
	// PlatformerController2D controller;
	// public Transform target;


	// Use this for initialization
	void Start () {
		StartCoroutine (KillAfterSeconds (lifeTime));
		// controller = GetComponent<PlatformerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.instance.transform.position;


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

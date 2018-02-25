using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlatformerController2D))]
public class Shield : MonoBehaviour {

	[Tooltip ("After how many seconds is the Shield destroyed")]
	public float lifeTime = 5;
	public CircleCollider2D circle;


	// Use this for initialization
	void Start () {
		// circle.enabled = false;
		StartCoroutine (KillAfterSeconds (lifeTime));
		// controller = GetComponent<PlatformerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.instance != null) {
			transform.position = Player.instance.transform.position;

			// print (transform.position.x);
		}

		print (circle.enabled);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("enemy")) {
			circle.enabled = true;
			print (circle.enabled);
			print ("Enemy Attack");
			Enemy enemy = other.GetComponent<Enemy> ();
			enemy.leftCheck.isTrigger = false;
			enemy.rightCheck.isTrigger = false;
			enemy.body.isTrigger = false;
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("enemy")) {
			Enemy enemy = other.GetComponent<Enemy> ();
			enemy.leftCheck.isTrigger = true;
			enemy.rightCheck.isTrigger = true;
			enemy.body.isTrigger = true;
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

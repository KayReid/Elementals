using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	
	/// <summary>The objects initial position.</summary>
	private Vector2 startPosition;
	/// <summary>The objects updated position for the next frame.</summary>
	private Vector2 newPosition;

	/// <summary>The speed at which the object moves.</summary>
	[SerializeField] private int speed = 3;
	/// <summary>The maximum distance the object may move in either y direction.</summary>
	[SerializeField] private int maxDistance = 1;

	void Start()
	{
		startPosition = transform.position;
		newPosition = transform.position;
	}

	void Update()
	{
		newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
		transform.position = newPosition;
	}

	/*
	//if character collides with the platform, make it a child.
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			MakeChild ();   
		}
	}
	//Once it leaves the platform, become a normal object again.
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			ReleaseChild(); 
		}
	}

	void MakeChild(){
		Player player = GetComponent<Player> ();
		player.transform.parent = transform;
	}

	void ReleaseChild(){
		Player player = GetComponent<Player> ();
		player.transform.parent = null;
	}   
	*/

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "Player") {
			other.transform.parent = transform;
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if (other.transform.tag == "Player") {
			other.transform.parent = null;
		}
	}
}



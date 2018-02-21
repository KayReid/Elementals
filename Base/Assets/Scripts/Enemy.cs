using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[Tooltip ("Trigger to be placed slightly to the left of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D leftWallCheck = null;
	[Tooltip ("Trigger to be placed slightly to the right of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D rightWallCheck = null;

	private int dir = 1;
	public float speed = 3;
	PlatformerController2D controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlatformerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.right * dir * speed * Time.deltaTime;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("spikes")) {
			dir *= -1;

		}
		if (other.CompareTag ("Player")) {
			Player.instance.Die ();
			dir *= -1;
		}

		print (dir);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[Tooltip ("Trigger to be placed slightly to the left of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D leftWallCheck = null;
	[Tooltip ("Trigger to be placed slightly to the right of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D rightWallCheck = null;
	[Tooltip ("Layers to be considered ground for groundchecks and collision checks when checking for change of direction.")]
	[SerializeField] LayerMask groundLayers = 0;

	public int dir = 1;
	public float speed = 3;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (leftWallCheck.IsTouchingLayers (groundLayers)) {
			dir = 1;
		}

		if (rightWallCheck.IsTouchingLayers (groundLayers)) {
			dir = -1;
		}
		// print (dir);
		transform.position += Vector3.right * dir * speed * Time.deltaTime;



	}


	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Player")) {
			Player.instance.Die ();

		}
			
	}

}

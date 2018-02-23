using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	// public PolygonCollider2D spikeCollider;
	// Use this for initialization
	void Start () {
		// spikeCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Player player = other.GetComponent<Player> ();
			player.Die ();
		}
			
	}



}

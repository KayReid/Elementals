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

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Player player = col.transform.root.GetComponentInChildren<Player>();
            player.Die();
        }
    }

}

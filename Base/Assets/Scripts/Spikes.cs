using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	// public PolygonCollider2D spikeCollider;
	// Use this for initialization
	// public LayerMask shieldLayers = 0;
	public Collider2D check = null; // 

	void Start () {
		// spikeCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		//if (check.IsTouchingLayers (shieldLayers)) {
		//	check.isTrigger = false;
		//}
	}

    void OnCollisionStay2D(Collision2D col)
    {
		if (col.collider.CompareTag ("shield")) {			
			// Player.instance.transform.position.y += 0.3f;
		}
        if (col.collider.CompareTag("Player"))
        {
            Player player = col.transform.root.GetComponentInChildren<Player>();
            player.Die();
        }

    }

}

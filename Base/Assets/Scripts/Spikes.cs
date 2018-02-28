using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    
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

        if (col.collider.CompareTag("Player"))
        {
            Player player = col.transform.root.GetComponentInChildren<Player>();
            player.Die();
        }

    }
    
}

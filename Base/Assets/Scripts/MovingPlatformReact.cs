using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformReact : MonoBehaviour {

	void OnCollisionEnter2D(Collider other){
		if(other.gameObject.tag == "moving_platform")
		{
			//This will make the player a child of the Obstacle
			this.gameObject.transform.parent = other.gameObject.transform; //Change "myPlayer" to your player
		}
	}
}


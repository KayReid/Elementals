using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatforms : MonoBehaviour {
	/// <summary>
	/// Platform falls after a given time interval
	/// </summary>
	public float fallDelay = 1f;
	public float removeDelay = 4f;

	private Rigidbody2D weakPlatform;

	void Awake(){
		weakPlatform = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player")){
			Invoke ("Fall", fallDelay);
		}
	}

	void Fall(){
		weakPlatform.isKinematic = false;
		Invoke ("Remove", removeDelay);
	}

	void Remove(){
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {


	[Tooltip ("After how many seconds is the Shield destroyed")]
	public float lifeTime = 3;
	// public Transform target;


	// Use this for initialization
	void Start () {
		StartCoroutine (KillAfterSeconds (lifeTime));
	

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.instance.transform.position;

	}

	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}

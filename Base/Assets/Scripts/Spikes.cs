using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	public GameObject deathEffect;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.CompareTag("Player"))
		{
			Player player = col.transform.root.GetComponentInChildren<Player>();
			player.Die();
		}
		if (col.gameObject.tag == "shield") {
			StartCoroutine (explosionEffect ());
			Destroy(gameObject);

		}

	}

	IEnumerator explosionEffect() {
		gameObject.SetActive(false);
		Instantiate(deathEffect, transform.position, transform.rotation);
		yield return new WaitForSeconds(1);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float timeToRespawn;
    public PlayerController thePlayer;

    public GameObject deathEffect;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>(); // Find object of type 'PlayerController' in the current active scene

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn() {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine() {
        thePlayer.gameObject.SetActive(false); // Make the whole gameobject player to be deactivated
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(timeToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition; // Player goes back to spawn position
        thePlayer.gameObject.SetActive(true);
    }
}

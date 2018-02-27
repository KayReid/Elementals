using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer spriteRenderer;
    public bool checkpointActive;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // If player passed a checkpoint
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            spriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}

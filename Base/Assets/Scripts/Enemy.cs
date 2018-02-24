using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[Tooltip ("Trigger to be placed slightly to the left of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D leftWallCheck = null;
	[Tooltip ("Trigger to be placed slightly to the right of the NPC collider. A collision will cause the NPC to turn around.")]
	[SerializeField] Collider2D rightWallCheck = null;
	[Tooltip ("Layers to be considered ground for groundchecks and collision checks when checking for change of direction.")]
	[SerializeField] LayerMask groundLayers = 0;

	[Tooltip("The individual sprites of the animation")]
	public Sprite[] frames;
	[Tooltip("How fast does the animation play")]
	public float seconds;

	SpriteRenderer spriteRenderer;
	public int dir = 1;
	public float speed = 3;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(PlayAnimation());
	}
	
	// Update is called once per frame
	void Update () {

		if (leftWallCheck.IsTouchingLayers (groundLayers)) {
			dir = 1;
			spriteRenderer.flipX = false;
		}

		if (rightWallCheck.IsTouchingLayers (groundLayers)) {
			dir = -1;
			spriteRenderer.flipX = true;
		}
		// print (dir);
		transform.position += Vector3.right * dir * speed * Time.deltaTime;



	}


	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Player")) {
			Player player = other.GetComponent<Player> ();
			player.Die ();

		}
			
	}


	IEnumerator PlayAnimation() {
		int currentFrameIndex = 0;
		while (true) {
			spriteRenderer.sprite = frames [currentFrameIndex];
			// yield return new WaitForSeconds(1f / framesPerSecond);
			yield return new WaitForSeconds(seconds);
			currentFrameIndex++;
			currentFrameIndex = currentFrameIndex%frames.Length;
		}

	}


}

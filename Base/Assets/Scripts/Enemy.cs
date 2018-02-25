using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {



	[Tooltip ("Layers to be considered obstacles for obstacle checks and collision checks when checking for change of direction.")]
	[SerializeField] LayerMask obstacleLayers = 0;

	[Tooltip("The individual sprites of the animation")]
	public Sprite[] frames;
	[Tooltip("How fast does the animation play")]
	public float seconds;

	SpriteRenderer spriteRenderer;
	public int dir = 1;
	public float speed = 3;
	public CircleCollider2D body;
	public Collider2D leftCheck = null;
	public Collider2D rightCheck = null;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(PlayAnimation());
	}
	
	// Update is called once per frame
	void Update () {

		if (leftCheck.IsTouchingLayers (obstacleLayers)) {
			dir = 1;
			spriteRenderer.flipX = false;
		}

		if (rightCheck.IsTouchingLayers (obstacleLayers)) {
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

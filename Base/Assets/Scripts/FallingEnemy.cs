using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour {

	[Tooltip("The individual sprites of the animation")]
	public Sprite[] frames;
	SpriteRenderer spriteRenderer;
	private float speed;
	public float minSpeed = 2;
	public float maxSpeed = 5;
	[Tooltip("How fast does the animation play")]
	public float seconds;
	public GameObject deadPrefab;
	[SerializeField] LayerMask shieldLayers = 0;
	public Collider2D body = null; // 


	// Use this for initialization
	void Start () {
		speed = Random.Range (minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (body != null) {
			if (body.IsTouchingLayers (shieldLayers)) {
				Destroy (gameObject);

			}
		}
		transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
	}


	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{
			Player player = col.transform.root.GetComponentInChildren<Player>();
			player.Die();
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
	IEnumerator blinkCoroutine (int numBlinks, float seconds) {
		for (int i=0; i<numBlinks*2; i++) { 	// *2 is necessary because we want renderer.enabled = true and false 
			// back and forth 3 times
			//toggle renderer
			spriteRenderer.enabled = !spriteRenderer.enabled;
			spriteRenderer.material.color = Color.red;
			//wait for a bit
			yield return new WaitForSeconds(seconds);
		}

		//make sure renderer is enabled when we exit
		spriteRenderer.enabled = true;
		spriteRenderer.material.color = Color.white;

	}

	public void Die()
	{
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		StartCoroutine(blinkCoroutine(3, 0.2f));
		Invoke("Remove", 2);
	}

}

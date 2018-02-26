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
	[Tooltip("Prefab to be instantiated when shooting (Snowball)")]
	public GameObject snowballPrefab;
	public GameObject deadPrefab;


	SpriteRenderer spriteRenderer;
	public int dir = 1;
	public float speed;
	public Collider2D body;
	public Collider2D leftCheck = null; // 
	public Collider2D rightCheck = null;
	public bool canShoot; 	// Birds cannot shoot, Ghosts can shoot (Set bird's canShoot as false and ghost's as true)
	// public bool canMove; // Birds can move, enemies falling from the sky cannot;
	public float rateOfFire;
	private float lastTimeFired = 0;

	// public float minSpeed = 2;
	// public float maxSpeed = 5;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = true;
		StartCoroutine(PlayAnimation());
		// speed = Random.Range (minSpeed, maxSpeed);

	}
	
	// Update is called once per frame
	void Update () {
		
		// Enemy Type: Birds
		if (leftCheck != null && rightCheck != null) {
			if (leftCheck.IsTouchingLayers (obstacleLayers)) {
				dir = 1;
				spriteRenderer.flipX = false;
			}

			if (rightCheck.IsTouchingLayers (obstacleLayers)) {
				dir = -1;
				spriteRenderer.flipX = true;
			}
			transform.position += Vector3.right * dir * speed * Time.deltaTime;
		}

		// Enemy Type: Ghosts that move and shoot
		if (canShoot && (lastTimeFired + 1 / rateOfFire) < Time.time) {
			lastTimeFired = Time.time;
			Shoot ();
		}
			

	}


    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Player player = col.transform.root.GetComponentInChildren<Player>();
            player.Die();
        }
    }

    /// <summary>
    /// Destroy the enemy and spawn the death animation.
    /// </summary>
    public void Die()
    {
        Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
        StartCoroutine(blinkCoroutine(3, 0.2f));
        Invoke("Remove", 2);
    }

    /// <summary>
	/// Remove the enemy.
	/// </summary>
	public void Remove()
    {
        Destroy(gameObject);
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

	void Shoot () {
		// Create the new projectile a bit in front of the spaceship and store the reference to the new gameobject.
		// the Instatiate function creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.

		GameObject snowballObject = Instantiate(snowballPrefab, transform.position + new Vector3 (dir, 0, 0), Quaternion.identity) as GameObject;
		// Get access to the script on the new snowbball using GetComponent to modify it.
		SnowBall snowball = snowballObject.GetComponent<SnowBall> ();
		snowball.direction.x = dir;

	}

}

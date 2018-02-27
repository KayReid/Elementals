using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCT : MonoBehaviour {

    public GameObject target; // Referenced to the Player
    public float cameraFollowAheadOfPlayer;
    private Vector3 targetPosition;
    public float smoothingCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* Setting the values we want the camera to move to target position
         x = player's position | y = camera's position to stay in range | z = camera's position, don't change it */
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z); 

        // These conditions move the target of the camera ahead of the player
        if(target.transform.localScale.x > 0f) { // If player is facing right, move the camera to the right ahead a little
            targetPosition = new Vector3(targetPosition.x + cameraFollowAheadOfPlayer, targetPosition.y, targetPosition.z);
        } else { // Player is facing left, scale < 0f
            targetPosition = new Vector3(targetPosition.x - cameraFollowAheadOfPlayer, targetPosition.y, targetPosition.z);
        }

        /* Reference the target position back to the camera position, Use Lerp for smoothness
         a = current camera position | b = target camera position | float = time for a to reach b | 30 fps, deltaTime = 1/30 fps */
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingCamera * Time.deltaTime);
	}
}

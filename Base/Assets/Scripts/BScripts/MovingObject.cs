using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
        currentTarget = endPoint.position; // When it first started, currentTarget Position should be at the end point

	}
	
	// Update is called once per frame
	void Update () {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, speed * Time.deltaTime);
        if (objectToMove.transform.position == endPoint.position) { // If our object position is == to the endpoint position
            currentTarget = startPoint.position;
        }
        if (objectToMove.transform.position == startPoint.position) {
            currentTarget = endPoint.position;
        }
	}
}

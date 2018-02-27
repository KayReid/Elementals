using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    public float objectLifeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        objectLifeTime = objectLifeTime - Time.deltaTime; // Deducts object time every frame until it gets to 0
        //Debug.Log(Time.deltaTime);
        if (objectLifeTime <= 0f) {
            Destroy(gameObject);
        }
	}
}

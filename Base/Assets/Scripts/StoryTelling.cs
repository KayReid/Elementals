using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTelling : MonoBehaviour {

	[TextArea (4, 30)]
	public string[] page;
	int PageNumber = -1;
	Text view;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		view = GetComponent<Text> ();
		Invoke ("PageTurn", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Invoke ("PageTurn", 0.2f);
		}

	}

	void PageTurn() {
		PageNumber++;
		if (PageNumber < page.Length) {
			view.text = page [PageNumber];
		
		} else {
			SceneManager.LoadScene(levelToLoad);
		}
	
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public string firstLevel;

    public GameObject mainMenu;

	// Use this for initialization
	void Start () {
        mainMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            mainMenu.SetActive(true);
        }
		
	}

    public void NewGame() {
        SceneManager.LoadScene(firstLevel);    
    }
    public void ContinueGame() {
        mainMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }


}

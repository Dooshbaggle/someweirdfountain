using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    public string levelName = "Level1";

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().
            onClick.AddListener(ButtonPressed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
     
    }

    private void ButtonPressed()
    {
        GameManager.Lives = 3;
        GameManager.Points = 0;

        SceneManager.LoadScene(levelName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

    public string levelName = "CharacterSelect1";

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
        SceneManager.LoadScene(levelName);
    }

}

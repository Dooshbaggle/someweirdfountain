using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<Button>().
            onClick.AddListener(ButtonPressed);
		
	}

	private void OnMouseUp()
	{

	}

	private void ButtonPressed()
	{
    Application.Quit();
	Debug.Log("ugaseno");
	}

}

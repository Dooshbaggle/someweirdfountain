using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPoints : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Text>().text
            = "POINTS: "
            + GameManager.Points.ToString();
    }

}

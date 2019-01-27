using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.Points++;
            SoundManager.PlaySound("songg.mp3");

        }
        else if (collision.transform.tag == "Player1")
        {
            GameManager.Points2++;
            SoundManager.PlaySound("songg.mp3");
            Destroy(gameObject);
        }


    }
}

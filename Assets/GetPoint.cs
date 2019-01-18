using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.Points++;
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Player1")
        {
            GameManager.Points2++;
            Destroy(gameObject);
        }


    }
}

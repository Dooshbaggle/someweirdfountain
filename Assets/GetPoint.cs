﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.Points++;
            SoundManager.PlaySound("garand");

        }
        else if (collision.transform.tag == "Player1")
        {
            GameManager.Points2++;
            SoundManager.PlaySound("garand");
            Destroy(gameObject);
        }


    }
}

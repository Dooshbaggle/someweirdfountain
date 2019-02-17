using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            collision.gameObject.GetComponent<CharMovement2>().Die();   
        }

        if (collision.transform.tag == "PlayerProjectile")
        {
           Destroy(GetComponent<BoxCollider2D>());
        }


    }


}

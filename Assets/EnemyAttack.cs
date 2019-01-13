using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<CharMovement2>().Die();
            collision.gameObject.GetComponent<CharMovement>().Die();   
        }

        if (collision.transform.tag == "PlayerProjectile")
        {
           Destroy(GetComponent<BoxCollider2D>());
        }






    }
}

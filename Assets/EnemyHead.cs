using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.parent.parent.GetComponent<DumbEnemy>().Die();
        }
        else if (collision.tag == "GravityObject")
        {
            transform.parent.parent.GetComponent<DumbEnemy>().Die();
        }
    }
}
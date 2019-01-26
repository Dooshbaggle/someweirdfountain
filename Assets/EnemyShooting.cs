using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;

    private bool onRange = false;

    public Transform projectile;

    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {

        if (onRange)
        {

            Transform bullet = Instantiate(projectile);
            projectile.transform.position = transform.position;
            projectile.gameObject.GetComponent<Projectile>().strength = bulletImpulse;
            Destroy(bullet.gameObject, 2);
        }


    }

    void Update()
    {

        onRange = Vector2.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }


}

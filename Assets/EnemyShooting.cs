using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20f;

    private bool onRange = false;

    public Transform projectile;

    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {

        if (onRange && player != null && transform.position.x < player.position.x) // y koordinata ne valja
        {

            Transform proj = Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.gameObject.GetComponent<Projectile>().strength = bulletImpulse;
            Destroy(proj.gameObject, 2);

            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().Play();
        }

        else if (onRange && player != null && transform.position.x > player.position.x)
        {

            Transform proj = Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.gameObject.GetComponent<Projectile>().strength = -bulletImpulse;
            Destroy(proj.gameObject, 2);

            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().Play();
        }

    }

    void Update()
    {

        onRange = Vector2.Distance(transform.position, player.position) < range;

        if (onRange && transform.position.x > player.position.x)
        {
            GetComponent<EnemyMovement2>().whichWay = -1;
        }
        else if (onRange && transform.position.x < player.position.x)
        {
            GetComponent<EnemyMovement2>().whichWay = 1;
        }


    }


}

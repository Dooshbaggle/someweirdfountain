using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTile : MonoBehaviour
{



    Tilemap tilemap;
    private static int shot = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Tilemap1") != null)
        {
            tilemap = GameObject.FindGameObjectWithTag("Tilemap1").GetComponent<Tilemap>();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        shot++;

        Debug.Log(shot);

        

            Vector3 hitPosition = Vector3.zero;
            if (tilemap != null && GameObject.FindGameObjectWithTag("Tilemap1") == collision.gameObject)
            {
                if (shot >= 2)
                {
                    foreach (ContactPoint2D hit in collision.contacts)
                    {
                        hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                        hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                        tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                    }
                shot = 0;
                }
            }

        Destroy(gameObject);
    }

}

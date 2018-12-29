using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector2 direction = new Vector2(1,0);
    public float strength = 10f;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().
            AddForce(direction * strength, ForceMode2D.Impulse);

            Destroy(gameObject, 2);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Enemy")
        {
            collision.gameObject.GetComponent<DumbEnemy>().Die();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

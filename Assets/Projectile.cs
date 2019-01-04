using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector2 direction = new Vector2(0,0);
    public float strength = 20f;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().
            AddForce(direction * strength, ForceMode2D.Impulse);

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<DumbEnemy>().Die();
        }
 
    }
    // Update is called once per frame
    void Update() {

    {
        
    }
}
 }


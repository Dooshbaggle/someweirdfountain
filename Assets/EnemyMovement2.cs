using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{

    public Transform leftSide;
    public Transform rightSide;
    public float enemySpeed = 5f;
    public float speedUp = 25f;
    public float whichWay = -1;
    private float currentEnemySpeed = 0;
    private Vector2 speed = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        currentEnemySpeed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Rigidbody2D>().velocity;
        
            if (transform.position.x < leftSide.position.x) //   i ako nije on range, inace ako je transform.position.x < leftSide.position.x i jeste on range 
            {                                               // onda currentEnemySpeed = currentEnemySpeed + speedUp * Time.deltaTime;
            whichWay = 1;
            }
            else if (transform.position.x > rightSide.position.x)
            {

                
                whichWay = -1;
            }
            currentEnemySpeed = currentEnemySpeed + whichWay * speedUp * Time.deltaTime;
            if(currentEnemySpeed<-enemySpeed) currentEnemySpeed = -enemySpeed;
            if (currentEnemySpeed > enemySpeed) currentEnemySpeed = enemySpeed;

            speed.x = currentEnemySpeed;

            gameObject.GetComponent<Rigidbody2D>().velocity = speed;

        if (speed.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (-0.61f, -1.028959f) ;

        }
        else if (speed.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }   

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlayerProjectile")
        {
            gameObject.GetComponent<Animator>().SetBool("EnemyisDead", true);
			enemySpeed = 0;
        }

		if(collision.transform.tag == "Player")
		{
            gameObject.GetComponent<Animator>().SetBool("EnemyisShooting", true);		
		}

    }

	private void OnCollisionExit2D(Collision2D collision)
	{
            gameObject.GetComponent<Animator>().SetBool("EnemyisShooting", false);		
	}

    public void Die()
    {
        //   GetComponent<BoxCollider2D>().size = new Vector2(5.217395f, 0.06f);
        //    GetComponent<BoxCollider2D>().offset = new Vector2(1.52f, -4.71f);
        Destroy(gameObject);
	}

}

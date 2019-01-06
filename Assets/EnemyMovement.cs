using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
        
            if (transform.position.x < leftSide.position.x)
            {
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

        }
        else if (speed.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }   

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlayerProjectiles")
        {
            gameObject.GetComponent<Animator>().SetBool("EnemyisDead", true);
        }else
		{
            gameObject.GetComponent<Animator>().SetBool("EnemyisDead", false);		
		}

		if(collision.transform.tag == "Player")
		{
            gameObject.GetComponent<Animator>().SetBool("EnemyisAttacking", true);		
		}else
		{
            gameObject.GetComponent<Animator>().SetBool("EnemyisAttacking", false);		
		}

    }
    
}







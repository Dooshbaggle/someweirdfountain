﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMovement2 : MonoBehaviour
{

    public float speedX = 5f;
    public float speedY = 20f;
    public float inertion = 1f;
    private Vector2 speed = new Vector2(0f, 0f);
    public bool onGround = false;
    public int jumpNumber = 1;
    public int maxJumpNumber = 1;
    private bool canShoot = true;
    public float shootSpeed = 10f;
    Rigidbody2D theRB;
    public Transform projectile;
    public Transform shootPoint;
	private bool facingRight;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        speed = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.x = speedX;
			facingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.x = -speedX;
			facingRight = false;
        }
        else
        {
            speed.x = 0f;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (onGround)
            {
                speed.y = speedY;
            }
            else if (jumpNumber > 0)
            {
                speed.y = speedY;
                jumpNumber = jumpNumber - 1;

            }

         if (speed.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (speed.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }   


        if (Input.GetKey(KeyCode.L))
        {
           if(facingRight == true)
		   {
		        Transform proj = Instantiate(projectile);
	            proj.transform.position = transform.position;
                proj.gameObject.GetComponent<Projectile>().strength = shootSpeed;
			}else if (facingRight == false)
			{
		        Transform proj = Instantiate(projectile);
	            proj.transform.position = transform.position;
                proj.gameObject.GetComponent<Projectile>().strength = -shootSpeed;
			}


        }


        if (Mathf.Abs(speed.x) > 0.05f)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunning", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunning", false);
        }
        speed.x = Mathf.Lerp(gameObject.GetComponent<Rigidbody2D>().velocity.x, speed.x, Time.deltaTime * inertion);
        gameObject.GetComponent<Rigidbody2D>().velocity = speed;

        if (Mathf.Abs(speed.y) > 0.05f)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumping", true);
        }
        else if (onGround)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumping", false);
        }

        if (Mathf.Abs(speed.y) > 25f)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisDoubleJumping", true);
        }
        else if (onGround)
        {
     
            gameObject.GetComponent<Animator>().SetBool("PlayerisDoubleJumping", false);
        }
    }

    public void Die()
    {
        GameManager.Lives--;
        Debug.Log("Player has" + GameManager.Lives.ToString() + "lives'");
        if (GameManager.Lives >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}

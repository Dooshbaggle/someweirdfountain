﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CharMovement : MonoBehaviour
{

    public float speedX = 5f;
    public float speedY = 20f;
    public float abilitySpeed = 50f;
    public float inertion = 1f;
    public Vector2 speed = new Vector2(0f, 0f);
    public bool onGround = false;
    public int jumpNumber = 1;
    public int maxJumpNumber = 1;
    public float shootSpeed = 10f;
    public Transform projectile;
	private bool facingRight;
    public bool dead;
    Animator m_Animator;
    public Transform deadBody;

    // Use this for initialization
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKey(KeyCode.D))
        {
            speed.x = speedX;
			facingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed.x = -speedX;
			facingRight = false;
        }
        else
        {
            speed.x = 0f;
        }


        if (Input.GetKeyDown(KeyCode.W))
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
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (1.34f, 0f) ;

        }
        else if (speed.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (-1.3f, 0f) ;
        }   

		if(Input.GetKeyDown(KeyCode.V) && Mathf.Abs(speed.x) == 0)
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisIdleShooting", true);		
		}else
		{
			gameObject.GetComponent<Animator>().SetBool("PlayerisIdleShooting", false);	
		}

        if (Input.GetKeyDown(KeyCode.V))
        {

           if(facingRight == true)
		   {
		   // proj.transform.position = new Vector3 (transform.position.x, 8.8f, transform.position.z); projektil puca iz puske
		        Transform proj = Instantiate(projectile);
	            proj.transform.position = transform.position;
                proj.gameObject.GetComponent<Projectile>().strength = shootSpeed;
			}else if (facingRight == false)
			{
		        Transform proj = Instantiate(projectile);
	            proj.transform.position = transform.position;
                proj.gameObject.GetComponent<Projectile>().strength = -shootSpeed;
			}
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Play();

        }
		
		if(Mathf.Abs(speed.x) > 0.05f && Input.GetKeyDown(KeyCode.V) && Mathf.Abs(speed.y) == 0f)	
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunningShooting", true);					
		}
		else
		{
	        gameObject.GetComponent<Animator>().SetBool("PlayerisRunningShooting", false);	
		}

        if(Mathf.Abs(speed.y) > 0.05f && Input.GetKeyDown(KeyCode.V))
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumpingShooting", true);					
		}
		else
		{
	        gameObject.GetComponent<Animator>().SetBool("PlayerisJumpingShooting", false);	
		}


        if (Mathf.Abs(speed.x) > 0.1f)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunning", true);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunning", false);
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

        if (GameManager.abilityTrue == true)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                m_Animator.SetTrigger("Ability");
                GameManager.Points -= 1;
            }
            else
            {
                m_Animator.ResetTrigger("Ability");
            }

            if(Input.GetKey(KeyCode.A))
            {
                speed.x = -abilitySpeed;
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                speed.x = abilitySpeed;
            }


        }

    }

    public void Die()
    {
        Debug.Log("UMRO PRVI");
        dead = true;

        Transform dB = Instantiate(deadBody);
        dB.transform.position = transform.position;


        Destroy(gameObject);
    }

}


/*public void Die()
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

		if(code == good)
		{
			gameObject.GetComponent<Jovan>().Mood(good);
		}else if (code != good)
		{
			gameObject.GetComponent<Jovan>().Mood(bad);		
		}



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


	*/
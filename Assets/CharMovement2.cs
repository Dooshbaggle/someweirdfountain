using System.Collections;
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
    public float shootSpeed = 10f;
    public Transform projectile;
	private bool facingRight;
    public bool dead2;
    public Transform deadBody;

    // Use this for initialization
    void Start()
    {
        
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
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (1.74f, 0f) ;

        }
        else if (speed.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (-1.601292f, 0f) ;
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
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager1").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager1").GetComponent<AudioSource>().Play();

        }
		
		if(Input.GetKey(KeyCode.L))
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisIdleShooting", true);		
		}
		else
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisIdleShooting", false);	
		}		

		if(Mathf.Abs(speed.x) > 0.05f && Input.GetKey(KeyCode.L))	
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunningShooting", true);					
		}
		else
		{
	        gameObject.GetComponent<Animator>().SetBool("PlayerisRunningShooting", false);	
		}

        if(onGround == false && Input.GetKey(KeyCode.L))
		{
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumpingShooting", true);					
		}
		else
		{
	        gameObject.GetComponent<Animator>().SetBool("PlayerisJumpingShooting", false);	
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

        if (onGround == false)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumping", true);
            gameObject.GetComponent<Animator>().SetBool("PlayerisRunning", false);
        }
        else if (onGround)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerisJumping", false);
        }

    }

    public void Die()
    {
	    Debug.Log("UMRO DRUGI");
        dead2 = true;

        Transform dB = Instantiate(deadBody);
        dB.transform.position = transform.position;

        Destroy(gameObject);
    }

}


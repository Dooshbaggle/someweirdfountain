using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMovement : MonoBehaviour
{

    public float speedX = 5f;
    public float speedY = 20f;
    public float inertion = 1f;
    private Vector2 speed = new Vector2(0f, 0f);
    public bool onGround = false;
    public int jumpNumber = 1;
    public int maxJumpNumber = 1;
    public bool canShoot;
    public float shootSpeed;
    public Transform projectile;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        speed = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            speed.x = speedX;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            speed.x = -speedX;

        }
        else
        {
            speed.x = 0f;
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))

            if (onGround)
            {
                speed.y = speedY;
            }
            else if (jumpNumber > 0)
            {
                speed.y = speedY;
                jumpNumber = jumpNumber - 1;

            }

        if(Input.GetMouseButtonDown(0))
        {
            Transform proj= Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.gameObject.GetComponent<Projectile>().strength = shootSpeed;

            Vector3 screenPoint = Input.mousePosition;
            Vector3 worldPoint = 
                Camera.main.ScreenToWorldPoint(screenPoint);
            Vector2 direction = new Vector2(0, 0);
            direction.y = worldPoint.y - transform.position.y;
            direction.x = worldPoint.x - transform.position.x;
            float corner = Mathf.Atan2(direction.y, direction.x);

            proj.gameObject.GetComponent<Projectile>().direction =
                new Vector2(Mathf.Cos(corner), Mathf.Sin(corner));
        }

        if (speed.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (speed.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

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


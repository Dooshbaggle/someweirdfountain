using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponentInParent<CharMovement2>().onGround = true;
        gameObject.GetComponentInParent<CharMovement2>().jumpNumber =
            gameObject.GetComponentInParent<CharMovement2>().maxJumpNumber;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponentInParent<CharMovement2>().onGround = false;
    }
}

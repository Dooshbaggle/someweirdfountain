using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponentInParent<CharMovement>().onGround = true;
        gameObject.GetComponentInParent<CharMovement>().jumpNumber =
            gameObject.GetComponentInParent<CharMovement>().maxJumpNumber;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponentInParent<CharMovement>().onGround = false;
    }
}

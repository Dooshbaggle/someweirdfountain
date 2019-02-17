using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (MainCamera.GetComponent<CharMovement>().dead == true)
        {
            Destroy(GetComponent<CameraFollowsPlayers>());
            MainCamera.AddComponent<CameraFollowsPlayer2>();
            GetComponent<CharMovement>().dead = false;
            Debug.Log("ahahhaqhahahhahahah");
        }
        else if (MainCamera.GetComponent<CharMovement2>().dead2 == true)
        {
            Destroy(GetComponent<CameraFollowsPlayers>());
            MainCamera.AddComponent<CameraFollowsPlayer>();
            GetComponent<CharMovement>().dead = false;

        }


    }
}

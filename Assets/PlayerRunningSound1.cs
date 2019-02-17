using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningSound1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager4").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager4").GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager4").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager4").GetComponent<AudioSource>().Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AudioClip clip;
            clip = gameObject.GetComponent<AudioSource>().clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().clip = clip;
            GameObject.Find("AudioManager3").GetComponent<AudioSource>().Play();
        }
        
    }
}

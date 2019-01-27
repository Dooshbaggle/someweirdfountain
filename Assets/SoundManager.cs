using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, playerWalkSound1 , playerWalkSound2, fireSound1, fireSound2, enemyFireSound, getPointClip;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("");
        playerWalkSound1 = Resources.Load<AudioClip>("");
        playerWalkSound2 = Resources.Load<AudioClip>("");
        fireSound1 = Resources.Load<AudioClip>("");
        fireSound2 = Resources.Load<AudioClip>("");
        enemyFireSound = Resources.Load<AudioClip>("");
        getPointClip = Resources.Load<AudioClip>("songg.mp3");

    }

    // Update is called once per frame
    void Update()
    {


        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
 /*           case "fire":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "fire":
                audioSrc.Play(playerWalkSound1);
                break;
            case "fire":
                audioSrc.PlayOneShot(playerWalkSound2);
                break;
            case "fire":
                audioSrc.PlayOneShot(fireSound1);
                break;
            case "fire":
                audioSrc.PlayOneShot(fireSound2);
                break;
            case "fire":
                audioSrc.PlayOneShot(enemyFireSound);
                break; */
            case "songg.mp3":
                audioSrc.PlayOneShot(getPointClip);
                Debug.Log("PUCAJ");
                break;
                

        }
    }




}

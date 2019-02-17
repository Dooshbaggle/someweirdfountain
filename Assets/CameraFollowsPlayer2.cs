﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer2 : MonoBehaviour
{
    public Transform Player2;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float deadZoneX = 0f;
    public float deadZoneY = 0f;
    public float cameraSpeed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Player2 != null)
        {
            float newX = Player2.position.x + offsetX;
            float newY = Player2.position.y + offsetY;
            if (Mathf.Abs(transform.position.x - newX) < deadZoneX)
            {
                newX = transform.position.x;
            }
            if (Mathf.Abs(transform.position.y - newY) < deadZoneY)
            {
                newY = transform.position.y;
            }
            newX = Mathf.Lerp(transform.position.x, newX, cameraSpeed * Time.deltaTime);
            newY = Mathf.Lerp(transform.position.y, newY, cameraSpeed * Time.deltaTime);

            transform.position = new Vector3(newX, newY, transform.position.z);
        }

    }
}

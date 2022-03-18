using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPlatform : MonoBehaviour
{
    public Transform leftWheel, rightWheel;

    private bool isCarStarted, isWheelsStopped;

    public static RollingPlatform _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerBehaviour._instance.isReadyToStartCar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isCarStarted = true;
                leftWheel.GetComponent<WheelJoint2D>().enabled = true;
                rightWheel.GetComponent<WheelJoint2D>().enabled = true;
            }
        } else if (!isWheelsStopped)
        {
            StopWheels();
        }
    }

    public void StopWheels ()
    {
        leftWheel.GetComponent<WheelJoint2D>().enabled = false;
        rightWheel.GetComponent<WheelJoint2D>().enabled = false;

        leftWheel.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rightWheel.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        isWheelsStopped = true;
    }
}

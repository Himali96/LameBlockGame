using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStoppingController : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Car")
        {
            RollingPlatform._instance.StopWheels();
        }
    }

}

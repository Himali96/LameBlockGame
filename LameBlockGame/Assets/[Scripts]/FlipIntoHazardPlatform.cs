using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipIntoHazardPlatform : MonoBehaviour
{

    public bool isFlipped;

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 1500 == 0)
        {
            isFlipped = !isFlipped;
            if (isFlipped) transform.eulerAngles = new Vector3(0, 0, 180);
            else transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}

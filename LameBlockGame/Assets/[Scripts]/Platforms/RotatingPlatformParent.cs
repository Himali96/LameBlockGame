using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformParent : MonoBehaviour
{
    public List<Transform> rotatingChilds;

    private float speed, timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 10)
        {
            if (timer < 5)
            {
                speed = 30 * Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, -speed));
                for (int i = 0; i < rotatingChilds.Count; i++)
                {
                    rotatingChilds[i].Rotate(new Vector3(0, 0, speed));
                }
            }
            timer += 0.0335f;
        }
        else timer = 0;
    }
}

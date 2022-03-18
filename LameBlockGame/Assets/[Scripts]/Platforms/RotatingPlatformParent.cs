using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformParent : MonoBehaviour
{
    public List<Transform> rotatingChilds;

    private float speed;

    // Update is called once per frame
    void Update()
    {
        speed = 30 * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -speed));
        for (int i = 0; i < rotatingChilds.Count; i++)
        {
            rotatingChilds[i].Rotate(new Vector3(0, 0, speed));
        }
    }
}

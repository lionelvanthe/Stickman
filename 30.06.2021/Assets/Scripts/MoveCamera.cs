using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform pl1, pl2;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool check;
    // Update is called once per frame

    void LateUpdate()
    {
        if (check)
        {
            // transform.position = pl1.position + offset;
            Vector3 desiredPosition = pl1.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            //  transform.LookAt(pl1);
        }
        else
        {
            Vector3 desiredPosition2 = pl2.position + offset;
            Vector3 smoothedPosition2 = Vector3.Lerp(transform.position, desiredPosition2, smoothSpeed);
            transform.position = smoothedPosition2;
            //transform.LookAt(pl2);
        }

    }

}
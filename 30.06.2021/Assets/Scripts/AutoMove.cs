using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Vector3 start, vdes;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    bool isLoop= false;
   public float speed;
    void Move()
    {
        if (!isLoop)
        {
            if (Vector3.Distance(transform.position, vdes) <= 0.1f)
            {

                isLoop = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vdes, Time.deltaTime * speed);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, start) <= 0.1f)
            {
                isLoop = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);
            }
        }
    }
}

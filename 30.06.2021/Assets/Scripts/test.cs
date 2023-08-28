using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Vector3 vitricu;
    public float speed = 5f;

    public Vector3 vCurrent;
    public Vector3 vDes;
    

    // Start is called before the first frame update
    void Start()
    {
        vCurrent = transform.position;
        //vitricu = new Vector3(-24, 1);
    }

    // Update is called once per frame
    void Update()
    {
      
        Moving();
    }

    private bool moveBack = false;
    private void Moving()
    {
        if (!moveBack)
        {
            if (Vector3.Distance(transform.position, vDes) <= 0.1f)
            {
                moveBack = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vDes, Time.deltaTime * speed);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, vCurrent) <= 0.1f)
            {
                moveBack = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vCurrent, Time.deltaTime * speed);
            }
        }
    }
}

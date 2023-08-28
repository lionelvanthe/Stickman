using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopWater : MonoBehaviour
{
    public float speed;
    public float moveRange;



private Vector3 oldPosiotion;
    // Start is called before the first frame update
    void Start()
    {
        oldPosiotion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.1f * Time.deltaTime * speed, 0);
        if (Vector3.Distance(oldPosiotion, transform.position) > moveRange)
        {
            transform.position = oldPosiotion;
        }

    }

    //public void Taomua(){
    //    Instantiate(Mua, new Vector3(Random.Range(-15, 15), 17), Quaternion.identity);
    //}qqqqqqq
}

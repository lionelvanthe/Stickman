using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCongTac : MonoBehaviour
{
   //public Best best;
    public List<Transform> congTac;
    public bool isMovingDown, isMovingUp;
    public List<Vector3> vStart;
    public List<Vector3> Vend;
    public float speed;

  
   // public bool player;
    // Start is called before the first frame update
    void Start()
    {
       
            for (int i = 0; i < congTac.Count; i++)

            {
                vStart[i] = congTac[i].position;
            }
    }
    public bool checkeed = false;
   // public bool yes;

    // Update is called once per frame
    void Update()
    {
       
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CongTac1"))
        {
            checkeed = true;
         
        }

       
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("CongTac1"))
        {
            checkeed = false;
        }
       

    }

    public void Move()
    {
        for (int i = 0; i < congTac.Count; i++)

        {          
            if (isMovingDown)
            {
                congTac[i].position = Vector3.MoveTowards(congTac[i].position, Vend[i], speed * Time.deltaTime);
            }
            if (isMovingUp)
            {
                congTac[i].position = Vector3.MoveTowards(congTac[i].position, vStart[i], speed * Time.deltaTime);
            }
        }
    }
}




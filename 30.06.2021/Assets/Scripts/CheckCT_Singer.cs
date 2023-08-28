using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCT_Singer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool downded = false;
    //public bool yes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = true;
            }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = false;
            }
        
    }
}

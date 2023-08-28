using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuliCongTac : MonoBehaviour
{
    public CongTac congtac1, congtac3;
  
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //congtac1.yeallow = true;
        //congtac1.isMovingRight = true;
        //congtac1.isMovingLeft = true;

        //congtac1.yeallow = false;
        //congtac3.isMovingRight = false;
        //congtac3.isMovingLeft = false;

        //congtac3.yeallow = true;
        //congtac3.isMovingLeft = true;
        //congtac3.isMovingRight = true;

        //congtac3.yeallow = false;
        //congtac3.isMovingLeft = false;
        //congtac3.isMovingRight = false;


       if(Input.GetKey(KeyCode.Alpha3)){
            congtac1.yeallow = true;
            congtac3.yeallow = false;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            congtac1.yeallow = false;
            congtac3.yeallow = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
       
        
    }
   

}
   


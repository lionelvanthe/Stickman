using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int num;
    public int num2;

  
    public Text CountBlue;
    public Text CountRed;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getScore1(){
        num--;
        CountBlue.text =   num.ToString();
       
    }
    public void getScore2(){
        num2 --;
        CountRed.text =   num2.ToString();
       
    }


    
   
}

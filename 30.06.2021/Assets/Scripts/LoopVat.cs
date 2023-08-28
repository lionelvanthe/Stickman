using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopVat : MonoBehaviour
{
    public GameObject player;
    public MoveAni mAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platform")){
            player.transform.parent = collision.gameObject.transform;                           
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}

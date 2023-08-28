using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // if (transform.position.x > AdsManager.Instance.vRevive.x)
            {
               AdsManager.Instance.vRevive = transform.position;
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
   // public int RayCount = 2;

    public LayerMask layersToHit;

    // Update is called once per frame
    void Update()
    { 
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 50f, layersToHit);
        if (hit.collider == null)
        {
            transform.localScale = new Vector3(  transform.localScale.x, 10f, 1);
            return;
        }
        transform.localScale = new Vector3(transform.localScale.x, hit.distance, 1);
        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider.tag.Equals("Player"))
        {
            Destroy(hit.collider.gameObject);
            Debug.Log("CC");
        }
     
    }




    
}
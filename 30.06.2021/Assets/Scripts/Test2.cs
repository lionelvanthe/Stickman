using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
   public float scrollSpeed ;
    public float length;
    Vector2 starPos;
    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time* scrollSpeed, length);
        transform.position = starPos + Vector2.right * newPos;
    }
}

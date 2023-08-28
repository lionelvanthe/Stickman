using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongAnimation : MonoBehaviour
{
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // OpenDoor1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoor1()
    {
        anim.SetBool("OpenBlue", true);
    }
    public void CloseDoor1()
    {
        anim.SetBool("OpenBlue", false);
    }
    public void OpenDoor2()
    {
        anim.SetBool("OpenRed", true);
    }
    public void CloseDoor2()
    {
        anim.SetBool("OpenRed", false);
    }
}

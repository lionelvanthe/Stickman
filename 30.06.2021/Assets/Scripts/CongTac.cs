using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongTac : MonoBehaviour
{
   // public CheckCT_Singer check_single1, check_single2;

    public MoveAni player_1, player_2;
    public float Autospeed;
    public float speed;
    public Vector3 vStart, vEnd, vitri1_1, vitri2_1;
    public Transform  tamVan ;
   
    // Start is called before the first frame update
    void Start()
    {
        vStart = transform.position;
        vitri1_1 = tamVan.position;
       // vitri1_2 = TamVan2.position;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (isMovingDown)
        {

            transform.position = Vector3.MoveTowards(transform.position, vEnd, speed * Time.deltaTime);
        }


        if (isMovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, vStart, speed * Time.deltaTime);
        }


        MoveTamvanTim();

        MoveTamVanXanh();

        MoveTamvantim2();
           
        MoveTamVanVang();
    }


    private bool   isMovingLeft, isMovingRight, isMovingLeft2, isMovingRight2, isTimdown2, isTimup2;
    public bool yeallow, red, red2, green, green2, isTimdown, isMovingDown, isMovingUp, isTimup;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !player_1.downded || !player_2.downded )
        {
           
            isMovingDown = true;
            isMovingUp = false;



            if (yeallow)
            {
                isMovingRight = true;
                isMovingLeft = false;

            }
            if (red)
            {

                isTimup = true;
                isTimdown = false;

            }
            if (green)
            {
                isTimdown = true;
                isTimup = false;
            }
            if (green2)
            {
                isMovingLeft2 = true;
                isMovingRight2 = false;
            }
            if (red2)
            {
                isTimup2 = true;
                isTimdown2 = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") &&  !player_1.downded && !player_2.downded)

        {
           
            isMovingDown = false;
            isMovingUp = true;

            if (yeallow)
            {
                isMovingRight = false;
                isMovingLeft = true;

            }
            if (red)
            {

                isTimdown = true;
                isTimup = false;
            }
            if (green)
            {
                isTimdown = false;
                isTimup = true; ;
            }
            if (green2)
            {
                isMovingLeft2 = false;
                isMovingRight2 = true;
            }
            if (red2)
            {
                isTimup2 = false;
                isTimdown2 = true;
            }
        }
    }

    public void MoveTamVanVang()
    {

        if (isMovingRight)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri2_1, Autospeed * Time.deltaTime);
        }

        if (isMovingLeft)
        {
           tamVan.position = Vector3.MoveTowards(tamVan.position, vitri1_1, Autospeed * Time.deltaTime);
        }
    }
    public void MoveTamvanTim()
    {
        if (isTimdown)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri2_1, Autospeed * Time.deltaTime);

        }
        if (isTimup)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri1_1, Autospeed * Time.deltaTime);

        }
    }
    public void MoveTamVanXanh()
    {

        if (isMovingRight2)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri1_1, Autospeed * Time.deltaTime);
        }

        if (isMovingLeft2)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri2_1, Autospeed * Time.deltaTime);
        }
    }

    public void MoveTamvantim2()
    {
        if (isTimdown2)
        {
           tamVan.position = Vector3.MoveTowards(tamVan.position, vitri1_1, Autospeed * Time.deltaTime);
        }
        if (isTimup2)
        {
            tamVan.position = Vector3.MoveTowards(tamVan.position, vitri2_1, Autospeed * Time.deltaTime);
        }
    }

}

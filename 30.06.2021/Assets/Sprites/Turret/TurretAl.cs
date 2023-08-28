using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAl : MonoBehaviour
{

    public int curHealth = 100;

    public float distance;
    public float wakerange;
    public float shootinterval;
    public float bulletspeed ;
    public float bullettimer;

    public bool awake = false;
    public bool lookingRight = true;
    public bool check;

    public GameObject bullet;
    public Transform target1, target2;
    private Animator anim;
    public Transform shootpointL, shootpointR;


    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

      //  RangeCheck();
        if (target1 && check)
        {
            if (target1.transform.position.x > transform.position.x)
            {
                lookingRight = true;
            }
            if (target1.transform.position.x < transform.position.x)
            {
                lookingRight = false;
            }
        }
        if (target2 && !check)
        {
            if (target2.transform.position.x > transform.position.x)
            {
                lookingRight = true;
            }
            if (target2.transform.position.x < transform.position.x)
            {
                lookingRight = false;
            }
        }
        if (curHealth < 0)
        {

            Destroy(gameObject);
        }
    }
    public void turret_Sleep()
    {
        awake = false;
    }
    public void turret_Awake()
    {
        awake = true;
    }

    //void RangeCheck()
    //{
    //    distance = Vector2.Distance(transform.position, target.transform.position);

    //    if (distance < wakerange)
    //        awake = true;

    //    if (distance > wakerange)
    //        awake = false;
    //}

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)
        {
            Vector2 direction = target1.transform.position - transform.position;
            direction.Normalize();

            Vector2 dir2 = target2.position - transform.position;
            dir2.Normalize();
            if (attackright)
            {
                if (check)
                {
                    GameObject bulletclone;
                    bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                    bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                    bullettimer = 0;
                }
                else
                {
                    GameObject bulletclone;
                    bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                    bulletclone.GetComponent<Rigidbody2D>().velocity = dir2 * bulletspeed;

                    bullettimer = 0;
                }
            }
            if (!attackright)
            {
                if (check)
                {
                    GameObject bulletclone;
                    bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                    bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                    bullettimer = 0;
                }
                else
                {
                    GameObject bulletclone;
                    bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                    bulletclone.GetComponent<Rigidbody2D>().velocity = dir2 * bulletspeed;

                    bullettimer = 0;
                }
            }
        }
    }


}

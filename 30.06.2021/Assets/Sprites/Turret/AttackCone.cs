using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public TurretAl turret;
    public bool isLeft = false;


    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAl>();

    }
    public float StopShoot = 0;
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (isLeft)
                turret.Attack(false);

            else
                turret.Attack(true);


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanCongTac : MonoBehaviour
{
    public LayerMask lmPlayer;
    //  public Transform leftPoint, rightPoint;
    public Transform _trParent;
    public bool isLeft;

    public Transform TamvanTim;
    public Vector3 Vstar, Vend;
    public float speed;

    private AudioSource audioS;
    public AudioClip cancongtac;
    // public float speedRotate;

    //  Vector3 alo = new Vector3(0, 0, 40);
    // Start is called before the first frame update
    void Start()
    {
        Vstar = TamvanTim.position;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.05f, lmPlayer))
        {
            if (isLeft)
            {
                audioS.clip = cancongtac;
                audioS.Play();

               //_trParent.eulerAngles = new Vector3(0, 0, -40);
                //float angle = Mathf.Atan2(_trParent.y, joystick.joysiickVec.x) * Mathf.Rad2Deg;
                Quaternion target = Quaternion.Euler(0, 0, -40);
                _trParent.rotation = Quaternion.Lerp(_trParent.rotation, target, Time.deltaTime);
            }
            else
            {
                audioS.clip = cancongtac;
                audioS.Play();
               //  _trParent.eulerAngles = new Vector3(0, 0, 40);
                Quaternion target = Quaternion.Euler(0, 0, 40);
                _trParent.rotation = Quaternion.Lerp(_trParent.rotation, target, Time.deltaTime);
            }
        }
        if (_trParent.rotation.z > 0)
        {
            TamvanTim.position = Vector3.MoveTowards(TamvanTim.position, Vend, Time.deltaTime * speed);
           
        }
        else
        {

            TamvanTim.position = Vector3.MoveTowards(TamvanTim.position, Vstar, Time.deltaTime * speed);
           
        }
        //  Push();
    }
    public bool check = true;
    private void Push()
    {
        if (check)
        {

            //

            _trParent.rotation *= Quaternion.Euler(0, 0, -1);
        }

        else
        {
            _trParent.rotation *= Quaternion.Euler(0, 0, 0);
        }
    }

}


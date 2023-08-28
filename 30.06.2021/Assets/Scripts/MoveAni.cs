using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Spine;
public class MoveAni : MonoBehaviour
{
    public FollowCamera flcam;
    public bool choose, check, Opening, die;
    public bool win = false;
    public GameController gamecontroller;
    public CongAnimation dooranmation;
    public TurretAl turret;

    public GameObject Panel_GameOver;
    public GameObject gameOver;
    public GameObject watch_Video;

    public SkeletonAnimation anim;
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    //Kiem tra va cham --> Jump
    bool isGrounded;
    public Transform groundCehck;
    public LayerMask groundLayer;

    //kiem tra di chuyen
    bool moveRight, moveleft;

    public bool downded = false; // check cong tac da dc dam~ xuong'
    public Vector3 vstart;

    private AudioSource audioS;
    public AudioSource water_loop;
    public AudioClip Select_Diamon, hoi_sinh, audio_die, jump, water, yeah, quatgio, congtac;

    [SpineAnimation] public string IdleAnim; //cac hanh dong
    [SpineAnimation] public string walkAnim;
    [SpineAnimation] public string jumpAnim;
    [SpineAnimation] public string isDie;
    [SpineAnimation] public string happy;
    [SpineAnimation] public string Win;
    [SpineAnimation] public string Fall_Down;

    [SpineAtlasRegion] public SpineSkin skin;


    [SpineSkin]
    public string one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelf, thirteen, fourteen, fifteen,
sixteen, seventeen, eightteen, nineteen, twentie, twenty_first, twenty_second, twenty_third, twenty_four, twenty_five;
    public int n;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveRight = false;
        moveleft = false;
        GetComponent<Image>();

        audioS = GetComponent<AudioSource>();



        //vstart = transform.position;   
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            PlayerPrefs.SetInt("selectOption", 1);
            Load();
        }
        else
        {
            Load();
        }
        Choose_skin();
    }
    //private void OnDisable()
    //{

    //    if (AdsManager.Instance != null)
    //    {
    //        AdsManager.Instance.acVideoComplete -= Revive;
    //        Debug.Log("turn off Revive");
    //    }
    //}

    
    // Update is called once per frame
    void Update()
    {
        Choose_skin();
        if (!choose)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }
        Handmove();

        HandJump();
        MoveManage();

        isGrounded = Physics2D.OverlapCircle(groundCehck.position, 0.2f, groundLayer);

        if (rb.velocity == Vector2.zero && !die && cam_Fail & Time.timeScale != 0)
        {
            flcam.hyo = true;
        }
     
    }
    bool cam_Fail = true;
    public void PlayAninmation(string _strAnim)
    {
        if (!anim.AnimationName.Equals(_strAnim))
        {

            anim.AnimationState.SetAnimation(0, _strAnim, true);
        }
    }
    public void PlayAninmationDie(string _strAnim)
    {
        if (!anim.AnimationName.Equals(_strAnim))
        {

            anim.AnimationState.SetAnimation(0, _strAnim, false);
        }
    }

    public static void ChangeSkin(SkeletonAnimation skAnim, string ssSkinChange)
    {
        var skeleton = skAnim.Skeleton;
        var skeletonData = skeleton.Data;
        var newSkin = new Skin("new-skin");

        newSkin.AddSkin(skeletonData.FindSkin(ssSkinChange));

        newSkin.AddSkin(skAnim.Skeleton.Skin);
        skeleton.SetSkin(newSkin);
        skeleton.SetSlotsToSetupPose();
        skAnim.AnimationState.Apply(skeleton);
    }

    private void Load()
    {
        n = PlayerPrefs.GetInt("selectOption");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (check)
        {
            if (collision.gameObject.tag == "Dimon2")
            {
                Destroy(collision.gameObject);
                gamecontroller.getScore2();

                audioS.clip = Select_Diamon;
                audioS.Play();

                int Money = PlayerPrefs.GetInt("SUMDIAMON", 0) + 1;
                PlayerPrefs.SetInt("SUMDIAMON", Money);
            }
            if (collision.gameObject.tag == "Finish2" && gamecontroller.num2 == 0)
            {
                dooranmation.OpenDoor2();
                Opening = true;
                if (!win)
                {
                    audioS.clip = yeah;
                    audioS.Play();
                }
            }
            if (collision.gameObject.tag.Equals("DieRed"))
            {
                water_loop.clip = water;
                water_loop.Play();

            }
            if (collision.gameObject.tag.Equals("Dieblue") || collision.gameObject.tag.Equals("Die")
                                                    || (collision.gameObject.tag.Equals("trap")))
            {
                rb.velocity = new Vector3(0f, 0f);
                Died();
                die = true;
                PlayAninmationDie(isDie);
                StartCoroutine(Dieing());
                // Panel_GameOver.SetActive(true);
                audioS.clip = audio_die;
                audioS.Play();
                //  StartCoroutine(Destroy_Player());

            }
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                turret.bulletspeed = 0;
                rb.velocity = new Vector3(0f, 0f);
                Died();
                die = true;
                PlayAninmationDie(isDie);
                StartCoroutine(Dieing());
                // Panel_GameOver.SetActive(true);
                audioS.clip = audio_die;
                audioS.Play();
            }


            //check cong tac
            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = true;
                audioS.clip = congtac;
                audioS.Play();
            }
            if (collision.gameObject.tag.Equals("Swich1"))
            {
                audioS.clip = congtac;
                audioS.Play();

            }
            //check enemy
            if (collision.gameObject.tag.Equals("Enemy") && !die)
            {
                turret.turret_Awake();
                turret.check = false;

            }

            //check gio
            if (collision.gameObject.tag.Equals("Wind"))
            {
                if (rb.velocity.y == 0)
                {
                    rb.velocity = Vector2.up * 10f;

                }
                else
                {

                    rb.velocity = Vector2.up * 1.5f;
                }
                PlayAninmationDie(Fall_Down);
                rb.velocity = new Vector2(0f, rb.velocity.y);
                audioS.clip = quatgio;
                audioS.Play();
            }
        }


        else
        {
            if (collision.gameObject.tag == "Dimon")
            {
                Destroy(collision.gameObject);
                gamecontroller.getScore1();

                audioS.clip = Select_Diamon;
                audioS.Play();


                int Money = PlayerPrefs.GetInt("SUMDIAMON", 0) + 1;

                PlayerPrefs.SetInt("SUMDIAMON", Money);
            }
            if (collision.gameObject.tag == "Finish" && gamecontroller.num == 0)
            {
                dooranmation.OpenDoor1();
                Opening = true;

                if (!win)
                {
                    audioS.clip = yeah;
                    audioS.Play();
                }
            }

            if (collision.gameObject.tag.Equals("Dieblue"))
            {
                water_loop.clip = water;
                water_loop.Play();

            }

            if (collision.gameObject.tag.Equals("DieRed") || collision.gameObject.tag.Equals("Die")
                                                    || (collision.gameObject.tag.Equals("trap")))

            {
                rb.velocity = new Vector3(0f, 0f);
                Died();
                die = true;
                PlayAninmationDie(isDie);
                StartCoroutine(Dieing());

                audioS.clip = audio_die;
                audioS.Play();
                //  StartCoroutine(Destroy_Player());

            }
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                turret.bulletspeed = 0;
                rb.velocity = new Vector3(0f, 0f);
                Died();
                die = true;
                PlayAninmationDie(isDie);
                StartCoroutine(Dieing());

                audioS.clip = audio_die;
                audioS.Play();
            }

            //check cong tac
            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = true;
                audioS.clip = congtac;
                audioS.Play();
            }
            if (collision.gameObject.tag.Equals("Swich1"))
            {
                audioS.clip = congtac;
                audioS.Play();

            }
            //check enemy
            if (collision.gameObject.tag.Equals("Enemy"))
            {

                turret.turret_Awake();
                turret.check = true;
            }

            //check gio
            if (collision.gameObject.tag.Equals("Wind"))
            {
                if (rb.velocity.y == 0)
                {
                    rb.velocity = Vector2.up * 10f;

                }
                else
                {

                    rb.velocity = Vector2.up * 1.5f;
                }
                PlayAninmationDie(Fall_Down);
                rb.velocity = new Vector2(0f, rb.velocity.y);
                audioS.clip = quatgio;
                audioS.Play();
            }
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wind"))
        {
            rb.velocity = Vector2.up * 1.5f;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            PlayAninmationDie(Fall_Down);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (check)
        {
            if (collision.gameObject.tag == "Finish2")
            {
                dooranmation.CloseDoor2();
                Opening = false;

            }


            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = false;
            }

            if (collision.gameObject.tag.Equals("Enemy"))
            {
                turret.turret_Sleep();
            }
            if (collision.gameObject.tag.Equals("DieRed"))
            {
                water_loop.Pause();
            }
            if (collision.gameObject.tag.Equals("Wind"))
            {
                audioS.Pause();
            }

        }
        else
        {
            if (collision.gameObject.tag == "Finish")
            {
                dooranmation.CloseDoor1();
                Opening = false;
            }


            if (collision.gameObject.tag.Equals("Swich2"))
            {
                downded = false;
            }

            if (collision.gameObject.tag.Equals("Enemy"))
            {
                turret.turret_Sleep();
            }
            if (collision.gameObject.tag.Equals("Dieblue"))
            {
                water_loop.Pause();
            }
            if (collision.gameObject.tag.Equals("Wind"))
            {
                audioS.Pause();
            }
        }

    }

    private void MoveManage()
    {
        if (moveRight)
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            anim.skeleton.ScaleX = 1;
            if (isGrounded)
            {
                PlayAninmation(walkAnim);
            }
            else
            {
                PlayAninmationDie(Fall_Down);
            }
        }
        //else
        //{
        //    rb.velocity = new Vector2(0f, rb.velocity.y);
        //}

        if (moveleft)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
            anim.skeleton.ScaleX = -1;
            if (isGrounded)
            {
                PlayAninmation(walkAnim);
            }
            else
            {
                PlayAninmationDie(Fall_Down);
            }
        }
    }
    public void MoveLeft()
    {

        if (!die)
        {
            moveleft = true;

            flcam.hyo = false;

        }
    }

    public void MoveRight()
    {
        if (!die)
        {
            moveRight = true;

            flcam.hyo = false;
        }
    }

    public bool falldown;
    public void Jump()
    {

        if (!choose) return;
        if (!die)
        {

            if (isGrounded)
            {
                PlayAninmation(jumpAnim);
                rb.velocity = Vector2.up * jumpForce;
                flcam.hyo = false;
                isGrounded = false;
                falldown = true;
                audioS.clip = jump;
                audioS.Play();
            }
            cam_Fail = false;
        }
    }
    public void stopjum()
    {

        if (!choose) return;
        if (!die)
        {

            if (falldown)
            {
                PlayAninmationDie(Fall_Down);

            }
            if (rb.velocity.x == 0)
            {
                falldown = false;
                PlayAninmation(IdleAnim);
            }
            cam_Fail = true;
        }
    }

    public void StopMoving()
    {
        if (!die)
        {
            moveleft = false;
            moveRight = false;

            PlayAninmation(IdleAnim);

        }
    }

    public void Handmove()
    {
        if (!die)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(+speed, rb.velocity.y);
                // anim.skeleton.FlipX = false;
                anim.skeleton.ScaleX = 1;

                if (isGrounded)
                {
                    PlayAninmation(walkAnim);
                }
                else
                {
                    PlayAninmationDie(Fall_Down);
                }
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                PlayAninmation(IdleAnim);
            }
            else
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                //  PlayAninmation(IdleAnim);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                // anim.skeleton.FlipX = true;
                anim.skeleton.ScaleX = -1;
                if (isGrounded)
                {
                    PlayAninmation(walkAnim);

                }
                else
                {
                    PlayAninmationDie(Fall_Down);
                }
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {

                PlayAninmation(IdleAnim);

            }

            if (Input.GetKey(KeyCode.H))
            {
                PlayAninmation(happy);
            }
            if (Input.GetKey(KeyCode.P))
            {
                PlayAninmation(Win);
            }
        }
    }

    bool dbjump;
    private void HandJump()
    {
        if (!die)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    //if (rb.velocity.y == 0)

                    rb.velocity = Vector2.up * jumpForce;
                    PlayAninmation(jumpAnim);
                    dbjump = true;
                    falldown = true;
                    isGrounded = false;
                    audioS.clip = jump;
                    audioS.Play();
                }
                else if (dbjump)
                {
                    jumpForce = jumpForce / 1.5f;
                    rb.velocity = Vector2.up * jumpForce;
                    PlayAninmation(jumpAnim);
                    dbjump = false;
                    jumpForce = jumpForce * 1.5f;
                    audioS.clip = jump;
                    audioS.Play();
                }

            }

            else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (falldown)
                {
                    PlayAninmationDie(Fall_Down);
                }

                if (rb.velocity.x == 0)
                {
                    falldown = false;
                    PlayAninmation(IdleAnim);
                }
            }
        }
    }

    IEnumerator Dieing()
    {
        yield return new WaitForSeconds(1.5f);

        // AdsManager.Instance.ShowVideoReward();

        Panel_GameOver.SetActive(true);

    }

    public void Died()
    {
        moveleft = false;
        moveRight = false;
        flcam.hyo = false;
    }

   // public void WatchVideo() /// ham goi quang cao 
   // {
   //     AdsManager.Instance.ShowVideoReward((b) =>
   //    {
   //        //if (b)
   //        //{
   //        if (choose)
   //        {
   //            if (b)
   //            {
   //                Revive();
   //                Debug.LogWarning("Revive");
   //            }
   //        }
           
   //        //}
   //    });

   //}


   public void Revive() /// sau khi xem xong video se hoi sinh nhan vat
    {
        if (choose)
        {
            die = false;
            flcam.hyo = true;
            PlayAninmation(IdleAnim);
            transform.position = AdsManager.Instance.vRevive;

            Panel_GameOver.SetActive(false);

            turret.bulletspeed = 5;
            audioS.clip = hoi_sinh;
            audioS.Play();

            //OnDisable();
        }

    }

    public void Close_WatchVideo() /// dong quang cao
    {
        gameOver.SetActive(true);
        watch_Video.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Snow"))
        {
            Debug.Log("Snowmotion");

            speed = 1;
            jumpForce = 4;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Snow"))
        {
            Debug.Log("Snowmotion");

            speed = 1;
            jumpForce = 4;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Snow"))
        {
            Debug.Log("Not Snowmotion");

            speed = 4;
            jumpForce = 9;

        }
    }

    public void Choose_skin()
    {
        switch (n)
        {
            case 1:
                ChangeSkin(anim, one);
                break;
            case 2:
                ChangeSkin(anim, two);
                break;
            case 3:
                ChangeSkin(anim, three);
                break;
            case 4:
                ChangeSkin(anim, four);
                break;
            case 5:
                ChangeSkin(anim, five);
                break;
            case 6:
                ChangeSkin(anim, six);
                break;
            case 7:
                ChangeSkin(anim, seven);
                break;
            case 8:
                ChangeSkin(anim, eight);
                break;
            case 9:
                ChangeSkin(anim, nine);
                break;
            case 10:
                ChangeSkin(anim, ten);
                break;
            case 11:
                ChangeSkin(anim, eleven);
                break;
            case 12:
                ChangeSkin(anim, twelf);
                break;
            case 13:
                ChangeSkin(anim, thirteen);
                break;
            case 14:
                ChangeSkin(anim, fourteen);
                break;
            case 15:
                ChangeSkin(anim, fifteen);
                break;
            case 16:
                ChangeSkin(anim, sixteen);
                break;
            case 17:
                ChangeSkin(anim, seventeen);
                break;
            case 18:
                ChangeSkin(anim, eightteen);
                break;
            case 19:
                ChangeSkin(anim, nineteen);
                break;
            case 20:
                ChangeSkin(anim, twentie);
                break;
            case 21:
                ChangeSkin(anim, twenty_first);
                break;
            case 22:
                ChangeSkin(anim, twenty_second);
                break;
            case 23:
                ChangeSkin(anim, twenty_third);
                break;
            case 24:
                ChangeSkin(anim, twenty_four);
                break;
            case 25:
                ChangeSkin(anim, twenty_five);
                break;
        }

    }
}






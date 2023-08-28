using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationNvNu : MonoBehaviour
{
    public event EventHandler OnAnimationloopedFirstTime;
    public event EventHandler OnAnimation;

    [SerializeField] private Sprite[] frameArray;
    private int currenFramer;
    private float timer;
    private float framerate = .1f;
    public SpriteRenderer spriteRenderer;
    private bool loop = true;
    private bool isPlaying = true;
    private int loopCounter = 0;

   
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public Transform check;
    public float checkRadius;
    public LayerMask groundLayer;
    private bool isTouchingMatdat;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //  Vitricu = new Vector3(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isPlaying)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > framerate)
        {
            timer -= framerate;
            currenFramer = (currenFramer + 1) % frameArray.Length;
            if (!loop && currenFramer == 0)
            {
                StopPlaying();
            }
            else
            {
                spriteRenderer.sprite = frameArray[currenFramer];
            }
            if (currenFramer == 0)
            {
                loopCounter++;
                if (loopCounter == 1)
                {
                    if (OnAnimationloopedFirstTime != null) OnAnimationloopedFirstTime(this, EventArgs.Empty);
                }
                if (OnAnimation != null) OnAnimation(this, EventArgs.Empty);
            }
        }
      
    }
    private void StopPlaying()
    {
        isPlaying = false;
    }
    public void PlayAnimation(Sprite[] frameArray, float framerate)
    {
        this.frameArray = frameArray;
        this.framerate = framerate;
        currenFramer = 0;
        timer = 0f;
        spriteRenderer.sprite = frameArray[currenFramer];
    }
  
        
    }
 
    



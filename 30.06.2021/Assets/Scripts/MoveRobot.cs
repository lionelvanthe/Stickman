using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    SpriteRenderer spri;
    Animator anim;
    Rigidbody2D rb;
    float xInput;
    float yInput;
    bool fire;
    public float speed ;
    bool isGround, dbjump;
    public Transform groundCehck;
    public LayerMask groundLayer;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rb.velocity = Vector2.up * jumpForce;
                dbjump = true;
                Debug.Log("dbJump: " + dbjump);
                anim.SetBool("Jump", true);

            }
            else if (dbjump)
            {
                jumpForce = jumpForce / 1.5f;
                rb.velocity = Vector2.up * jumpForce;
                dbjump = false;
                Debug.Log("dbjump: " + dbjump);
                jumpForce = jumpForce * 1.5f;
            }
        }
     fire  = Input.GetButtonDown("Fire1");
        anim.SetBool("Fire", fire);
    }
    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
      //  yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput *Time.deltaTime * speed, 0, 0);
        anim.SetFloat("Runnnnnn", Mathf.Abs(xInput));
    isGround = Physics2D.OverlapCircle(groundCehck.position, 0.2f, groundLayer);
        Platform();
        AutoDirec();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger("Die");
        }
    }
private void AutoDirec(){
        if (rb.velocity.x < -1)
        {
            spri.flipX = true;
        }
        else if(rb.velocity.x > 1)
        {
            spri.flipX = false;
        }
    }
void Platform(){
        rb.velocity = new Vector2(speed * xInput, rb.velocity.y);
    }
    
    
        
    
}

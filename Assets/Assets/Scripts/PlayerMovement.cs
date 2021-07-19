using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed,playerJumpForce,playerRadius;
    AudioSource audiocoin;
    public AudioClip coinaudio;
    public AudioClip jumpaudio;
    Rigidbody2D rb;
    ScoreText score;
    bool facingRight;
    public bool isGrounded;
    public LayerMask layerMask;
    public Transform groundcheck;
    public float xinput;
    public int jumps, maxnumberofjumps;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        jumps = maxnumberofjumps;
        score =GameObject.Find("ScoreManager").GetComponent<ScoreText>();
        audiocoin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            jumps = maxnumberofjumps;
           
        }
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, playerRadius, layerMask);
        xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * playerspeed, rb.velocity.y);

        if (facingRight == false && xinput > 0)
        {
            Flip();
        }
        else if (facingRight == true && xinput < 0)
        {
            Flip();
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.velocity = Vector2.up * playerJumpForce;
            maxnumberofjumps -= 1;
            audiocoin.clip = jumpaudio;
            audiocoin.Play();
        }
        if (Input.GetButtonDown("Jump") && jumps == 0&&isGrounded==true)
        {
            rb.velocity = Vector2.up * playerJumpForce;
            audiocoin.clip = jumpaudio;
            audiocoin.Play();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180.0f, 0);
    }
    public void SuperJump()
    {
        rb.velocity = Vector2.up * playerJumpForce*1.25f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "coin")
        {
            audiocoin.clip = coinaudio;
            audiocoin.Play();
            Destroy(collision.gameObject);
            score.Decrement();
        }
    }
}

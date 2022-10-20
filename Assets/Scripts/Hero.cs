using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 17f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public Playground playground;
    public bool onGround;
    public bool onElement;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetDamage(bool effect) {
        if (effect)
        {
            lives += 1;
        }
        else
        {
            lives -= 1;
        }

        playground.SetScore(lives);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround) State = States.Idle;

        if (Input.GetButton("Horizontal"))
            Run();

        if (onGround && Input.GetButtonDown("Jump"))
            Jump();

        CheckingGround();
    }

    private void Run()
    {
        if (onGround) State = States.Run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        // Debug.Log("dir: " + dir);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        if (!onGround) State = States.Jump;
    }

    public enum States
    {
     Idle,
     Run,
     Jump   
    }
    
    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }
}

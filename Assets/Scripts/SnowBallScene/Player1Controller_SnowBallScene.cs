using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller_SnowBallScene : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;

    public AudioSource throwSound;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left)){   //send character left
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }else if (Input.GetKey(right)){   //send character right
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }else{   //keep character from sliding around
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded){   //check is grounded before allowing jump
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(shoot)){
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            throwSound.Play();
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x)); //Mathf.Absolute, if minus value, ignore
        anim.SetBool("Grounded", isGrounded);

    }
}

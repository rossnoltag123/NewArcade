using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller_JungleScene : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

	//UI
	public Text livesText;

	private Rigidbody2D theRB;
	private int lives = 3;
	public JungleManager jungleManager;

    //private Animator anim;

	//audio
	public AudioSource audio;
	public AudioClip jumpSound;
    public AudioClip meteorSound;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
		//anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }

        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			audio.PlayOneShot (jumpSound, 1f);
        }

/*        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
/*

        /*anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);*/
    }

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.CompareTag ("Meteor")) 
		{
			audio.PlayOneShot(meteorSound, 1f);
			loseLife();
			Destroy(obj.gameObject);
		}
	}

	private void loseLife()
	{
		if (lives <= 1) 
		{
			jungleManager.gameOver(1);
		}

		else 
		{
			lives--;
			livesText.text = ("P2 : " + lives);
		}
	}
}

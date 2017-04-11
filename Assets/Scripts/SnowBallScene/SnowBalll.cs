using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBalll : MonoBehaviour
{

    public float ballSpeed;

    private Rigidbody2D theRB;

    public GameObject snowBallEffect;

    
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player 1")
        {
            FindObjectOfType<SnowBallManager>().HurtP1();
        }

        if (other.tag == "Player 2")
        {
            FindObjectOfType<SnowBallManager>().HurtP2();
        }


        Instantiate(snowBallEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

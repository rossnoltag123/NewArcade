using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float rocketSpeed;

    private Rigidbody2D theRB;

    public GameObject rocketEffect;


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        theRB.velocity = new Vector2(rocketSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            FindObjectOfType<RobotManager>().HurtP1();
        }

        if (other.tag == "Player 2")
        {
            FindObjectOfType<RobotManager>().HurtP2();
        }


        Instantiate(rocketEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

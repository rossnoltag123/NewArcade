using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBallManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

  //  public GameObject pausedMenu;

    public int P1Life;
    public int P2Life;

    public GameObject gameOver;

    public GameObject[] P1Sticks;
    public GameObject[] P2Sticks;

    public GameObject P1Wins;
    public GameObject P2Wins;

    public AudioSource hurtSound;

    GameObject pause;

    public string mainMenu;
    public string nextScene;

   // public PauseMenu pazMenu;


    void Start()
    {
    //  pazMenu =  GetComponent<PauseMenu>();
     
    }

    void Update()
    { 
        //Debug.LogWarning("Test");



        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //    pausedMenu.SetActive(true);
        //    pazMenu.pausGame();
        //    pausedMenu.SetActive(true);
        //    if(pausedMenu.isActive  )
        //    player1.SetActive(false);
        //    player2.SetActive(false);   
        //  };
        

        if (P1Life <= 0)
        {
            player1.SetActive(false);
            P1Wins.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextScene);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(mainMenu);
            }
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
            P2Wins.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextScene);
            }

            //    if (Input.GetKeyDown(KeyCode.Escape))
            //    {
            //       SceneManager.LoadScene(mainMenu);
            //  }
        }


    }

    public void HurtP1()
    {
        P1Life -= 1;

        for (int i = 0; i < P1Sticks.Length; i++)
        {
            if (P1Life > i)
            {
                P1Sticks[i].SetActive(true);
            }
            else
            {
                P1Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;

        for (int i = 0; i < P2Sticks.Length; i++)
        {
            if (P2Life > i)
            {
                P2Sticks[i].SetActive(true);
            }
            else
            {
                P2Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }


}
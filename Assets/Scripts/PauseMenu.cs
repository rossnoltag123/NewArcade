using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu: MonoBehaviour
{

    public string mainMenu;
    public GameObject pMenu;

    void Start()
    {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pMenu.SetActive(true);
        }
    }

   public void ReturntoGame()
    {
        Time.timeScale = 1f;
        pMenu.SetActive(false);

    }

    public void RestartGame()
    {
        
    }

    public void LoadGame()
    {

    }

    public void SaveGame()
    {

    }

    public void Controlls()
    {

    }

    public void Audio()
    {

    }

    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenu);
    }
}

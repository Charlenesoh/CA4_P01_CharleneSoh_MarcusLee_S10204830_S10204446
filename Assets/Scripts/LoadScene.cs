using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void HTPButton()
    {
        SceneManager.LoadScene("HTP");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        menu.SetActive(false);
        player.GetComponent<SamplePlayer>().rotationSpeed = 60;
        player.GetComponent<SamplePlayer>().moveSpeed = 5;
    }
}

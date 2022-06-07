using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    public void StartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("Game");
        
    }
    public void Menu()
    {
        clickSound.Play();
        SceneManager.LoadScene("StartScreen");
        
    }
}

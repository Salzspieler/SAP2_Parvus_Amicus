using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]private GameObject optionsMenu;
    //Spiel geht weiter
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        optionsMenu.SetActive(true);
    }
    //Spiel wird beendet
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
    }
}

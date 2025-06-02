using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //zurück zum Titelbildschirm
    public void BackToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level_1");
    }
    //Spiel wird beendet
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

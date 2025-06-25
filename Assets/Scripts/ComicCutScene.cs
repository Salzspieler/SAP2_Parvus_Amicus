using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicCutScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

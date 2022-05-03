using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void OnPlayButton()
    {
        SceneManager.LoadScene("DeadRising");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnOptionButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(5);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnKeysAndPropsButton()
    {
        SceneManager.LoadScene(4);
    }
}

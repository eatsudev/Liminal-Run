using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public void PlayButton()
    {
        clickSound.Play();
        SceneManager.LoadScene("Scene1");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsMenu");
        clickSound.Play();
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("quitted");
        clickSound.Play();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        clickSound.Play();
    }

}

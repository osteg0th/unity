using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Quit");
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("Settings");
    }
    public void BackButton()
    {
        FindObjectOfType<AudioManager>().Play("Back");
    }
}

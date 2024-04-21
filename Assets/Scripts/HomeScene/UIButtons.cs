using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour 
{
    
    public void PlayButtonUI ()
    {
        SceneManager.LoadSceneAsync("Levels");
    }

    public void QuitButtonUI ()
    {
        Application.Quit();
    }

    public void ToggleBackgroundMusic ()
    {
        bool isMusicPlaying = BackgroundMusic.instance.GetComponent<AudioSource>().isPlaying;

        if (isMusicPlaying)
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();
        else
            BackgroundMusic.instance.GetComponent<AudioSource>().Play();
    }

}

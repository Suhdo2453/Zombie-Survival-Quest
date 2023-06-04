using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    private void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                SoundManager.Instance.PlayDefaultMusic("MenuStart");
                break;
            case 1:
                SoundManager.Instance.PlayDefaultMusic("PlayScene");
                break;
        }
    }
    
    public void LoadPlayScene()
    {
        StartCoroutine(LoadScene(1));
        SoundManager.Instance.PlayMusic("PlayScene");
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadScene(0));
        SoundManager.Instance.PlayMusic("MenuStart");
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        SoundManager.Instance.FadeOut();

        yield return new WaitForSecondsRealtime(transitionTime);

        Time.timeScale = 1;
        SoundManager.Instance.UnPauseMusic();
        SceneManager.LoadScene(sceneIndex);
    }
}

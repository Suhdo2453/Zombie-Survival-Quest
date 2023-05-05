using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadPlayScene()
    {
        StartCoroutine(LoadScene(1));
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadScene(0));
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

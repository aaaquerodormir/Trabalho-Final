using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitor;

    public void Transition(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitor.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName);  
    }
}

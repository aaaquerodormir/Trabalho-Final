using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyLoading : MonoBehaviour
{
    AsyncOperation operation;
    static string level;
    static string level2;
    static string level3;
    public Slider slider;

    private void Start()
    {
        operation = SceneManager.LoadSceneAsync(level);
        operation.allowSceneActivation = false;
        Invoke("AllowScene", 1);
    }

    void AllowScene()
    {
        operation.allowSceneActivation = true;
    }
    /// <summary>
    /// Call this to load a level instead of SceneManager
    /// </summary>
    /// <param name="nextlevel"></param>
    public static void LoadLevel(string nextlevel)
    {
        level = nextlevel;
        SceneManager.LoadScene("Loading");
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, operation.progress, Time.deltaTime * 6);
    }
}

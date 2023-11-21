using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string SceneName;

    public LevelLoader levelLoader;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.DeleteAll();
            levelLoader.Transition(SceneName);
        }
    }
}

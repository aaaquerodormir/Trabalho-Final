using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }

    public void Opçoes()
    {
        SceneManager.LoadScene("Opçoes");
    }

    public void SairControles()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void PlayGame()
    {
        MyLoading.LoadLevel("Floresta");
    }

}

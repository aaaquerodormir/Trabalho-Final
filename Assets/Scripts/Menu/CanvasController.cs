using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private GameManagerController _GameController;

    //Canvas
    [Header("Pause")]
    public GameObject PanelPause;
    bool isPaused = false;

    //Canvas fim de jogo
    public GameObject PanelGameOver;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndPlay();
        }
    }

    public void PauseAndPlay()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        PanelPause.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        PanelPause.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Sair()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        _GameController.fxGame.mute = true;
        _GameController.fxGame.Stop();

        _GameController.fxGameOver.mute = false;
        _GameController.fxGameOver.Play();


        Time.timeScale = 0;

        PanelGameOver.SetActive(true);

    }

}

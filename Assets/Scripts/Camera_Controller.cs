using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Camera mainCamera;
    private Miro_Cam player;

    public float insideMazeSize = 0.8f;
    public float outsideMazeSize = 2.5f;

    private void Start()
    {
        player = FindObjectOfType<Miro_Cam>(); // Encontra o script do jogador
    }

    void Update()
    {
        if (player != null)
        {
            bool insideMaze = player.IsInsideMaze();

            if (insideMaze)
            {
                mainCamera.orthographicSize = insideMazeSize;
            }
            else
            {
                mainCamera.orthographicSize = outsideMazeSize;
            }
        }
    }
}

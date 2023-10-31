using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Camera mainCamera;
    private Miro_Cam player;

    public float insideMazeSize = 0.8f;
    public float outsideMazeSize = 2.5f;
    public GameObject Cam;

    public Material novoMaterial;
    public Material Original;

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
                Cam.SetActive(true);
                Miro.sprite.material = novoMaterial; // troque o material do miro para um diferente
            }
            else
            {
                Miro.sprite.material = Original;
                Cam.SetActive(false);
                mainCamera.orthographicSize = outsideMazeSize;
            }
        }
    }
}

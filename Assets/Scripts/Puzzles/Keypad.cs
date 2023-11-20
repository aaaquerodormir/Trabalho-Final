using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    [SerializeField] GameObject minigame;

    private bool isMinigameOpen = false;
    


    
    public void PlayMiniGame()
    {
        minigame.SetActive(true);
        isMinigameOpen = true;
    }

    public void CloseMiniGame()
    {
        minigame.SetActive(false);
        isMinigameOpen = false;
    }
}

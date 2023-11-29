using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharCarta : MonoBehaviour
{
    public GameObject cartaUI;
    AudioManager audioManager;


    private void Awake()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void FecharCartaUI()
    {
        if (cartaUI != null)
        {
            audioManager.PlaySFX(audioManager.button);
            cartaUI.SetActive(false);
        }
    }
}

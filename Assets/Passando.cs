using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passando : MonoBehaviour
{
    public GameObject porta;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if(TouchControl.youWin && TouchControl2.vitoria && TouchControl3.alanis)
        {
            audioManager.PlaySFX(audioManager.puzzle);
            Destroy(porta);
            Debug.Log("DeuCerto");
        }
    }
}

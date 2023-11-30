using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public GameObject UIMensagem;



    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            other.GetComponent<Miro>().temColetavel = true;
            Destroy(this.gameObject);
        }

        if (UIMensagem != null)
        {
            UIMensagem.SetActive(true);
        }
    }
}

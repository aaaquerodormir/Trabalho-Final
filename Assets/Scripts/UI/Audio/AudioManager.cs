using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("--------------- Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------------- Audio Clip ------------")]
    public AudioClip background;
    public AudioClip interacao;
    public AudioClip coletavel;
    public AudioClip viagem;
    public AudioClip ataque;
    public AudioClip inventario;
    public AudioClip puzzle;
    public AudioClip dash;
    public AudioClip button;
    


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

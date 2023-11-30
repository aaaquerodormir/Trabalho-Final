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
    public AudioClip sache;
    public AudioClip tristezaid;
    public AudioClip tristezaatk;
    public AudioClip medoatk;
    public AudioClip bossrindo;
    public AudioClip bossatk;
    public AudioClip slime;
    public AudioClip bombinha;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void Pausar(AudioClip clip)
    {
        musicSource.Pause();
    }

    public void GO(AudioClip clip)
    {
        musicSource.Play();
    }

    public void ChangeMusic(float volume)
    {
        musicSource.volume = volume;    

    }

    public void ChangeSFX(float vol)
    {
        SFXSource.volume = vol;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Configuraçoes : MonoBehaviour
{

    //Variáveis
    public bool     isFullscreen;
    public int      resolutionIndex;
    public int      qualityTexture;
    public float    musicVolume;

    //Objetos
    public Toggle fullScreenToogle;
    public Dropdown resolutionDropdown;
    public Dropdown qualityTextureDropdown;
    public Slider musicVolumeSlider;

    public Resolution[] resolutions;

    private void OnEnable()
    {
        resolutions = Screen.resolutions;
        foreach (Resolution reso in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(reso.ToString()));
        }

        // o chamado das funções
        fullScreenToogle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        qualityTextureDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFullScreenToggle()
    {
        Screen.fullScreen = fullScreenToogle.isOn;
        OnResolutionChange();
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullScreenToogle.isOn);
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.SetQualityLevel(qualityTextureDropdown.value);
    }

    public void OnMusicVolumeChange()
    {

    }



}

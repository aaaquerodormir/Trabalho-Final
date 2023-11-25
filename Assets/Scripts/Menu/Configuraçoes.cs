using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // Obtenha todas as resoluções suportadas pelo sistema
        resolutions = Screen.resolutions;

        // Limpe as opções do Dropdown
        resolutionDropdown.ClearOptions();

        // Filtrar as resoluções para as 5 mais utilizadas em jogos pixel art 2D
        var filteredResolutions = GetTopResolutions(resolutions, 5);

        // Adicionar as resoluções ao Dropdown
        foreach (Resolution reso in filteredResolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(reso.ToString()));
        }

        // Chame as funções
        fullScreenToogle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        qualityTextureDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
    }

    // ...

    // Função para obter as top N resoluções mais utilizadas
    private Resolution[] GetTopResolutions(Resolution[] allResolutions, int topCount)
    {
        // Classifique as resoluções pelo número total de pixels (width * height) em ordem decrescente
        var sortedResolutions = allResolutions.OrderByDescending(res => res.width * res.height).ToArray();

        // Pegue as primeiras topCount resoluções
        var topResolutions = sortedResolutions.Take(topCount).ToArray();

        return topResolutions;
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

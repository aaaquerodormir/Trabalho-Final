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
    public float    musicVolume;

    //Objetos
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Slider musicVolumeSlider;

    private List<Resolution> customResolutions = new List<Resolution>
    {
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 1600, height = 1200 },
        new Resolution { width = 1600, height = 900 }
        // Adicione mais resoluções, se necessário
    };

    private void OnEnable()
    {
        // Limpe as opções do Dropdown
        resolutionDropdown.ClearOptions();

        // Crie uma lista de strings para armazenar as opções do Dropdown
        var resolutionOptions = new List<string>();

        // Adicione as resoluções customizadas à lista de opções e ao Dropdown
        foreach (Resolution reso in customResolutions)
        {
            resolutionOptions.Add(reso.ToString());
        }

        // Adicione as opções ao Dropdown
        resolutionDropdown.AddOptions(resolutionOptions);

        // Chame as funções
        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
               musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
    }

    // Restante do seu código...

    public void OnFullScreenToggle()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        OnResolutionChange();
    }

    public void OnResolutionChange()
    {
        Resolution selectedResolution = customResolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreenToggle.isOn);
    }
     public void OnMusicVolumeChange()
    {

    }



}

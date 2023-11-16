using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "710";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text uiText = null;

    public GameObject Keypad;
    [SerializeField] private GameObject endPanel;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr+Numbers;
        uiText.text = Nr;
    }

    public void Enter()
    {
        if(Nr == Code)
        {
           Keypad.SetActive(false);
           endPanel.SetActive(false);
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        uiText.text = Nr;
    }

    public void Close()
    {
        Keypad.SetActive(false);
    }
      
}

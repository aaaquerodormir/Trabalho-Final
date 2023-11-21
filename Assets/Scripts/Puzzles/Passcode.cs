using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "110100";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text uiText = null;

    public GameObject Keypad;
    [SerializeField] private GameObject endPanel;

    public GameObject passardetela;

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
            Casa.Abriu();
            passardetela.SetActive(true);
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

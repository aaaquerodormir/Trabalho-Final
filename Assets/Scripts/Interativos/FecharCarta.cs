using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharCarta : MonoBehaviour
{
    public GameObject cartaUI;
    
    public void FecharCartaUI()
    {
        if (cartaUI != null)
        {
            cartaUI.SetActive(false);
        }
    }
}

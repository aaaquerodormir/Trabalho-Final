using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public GameObject RatoOn;
    public GameObject BolaOn;
    public GameObject BingBongOn;
    public GameObject BallOn;
    public GameObject VaraOn;
    public GameObject CaixaLeiteOn;



    private void Update()
    {
        if (Miro.Bola == true)
        {
            BolaOn.SetActive(true);
        }
        if (Miro.Rato == true)
        {
            RatoOn.SetActive(true);
        }
        if (Miro.BingBong == true)
        {
            BingBongOn.SetActive(true);
        }
        if (Miro.Ball == true)
        {
            BallOn.SetActive(true);
        }
        if (Miro.Vara == true)
        {
            VaraOn.SetActive(true);
        }
        if (Miro.CaixaLeite == true)
        {
            CaixaLeiteOn.SetActive(true);
        }
    }

  
}
